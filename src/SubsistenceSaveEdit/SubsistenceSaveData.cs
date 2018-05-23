using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SubsistenceSaveEdit
{
	public enum StringFieldEncoding
	{
		ASCII = 0,
		UNICODE,
	}

	public class StringField : Object
	{
		public StringField(string val = "")
		{
			Value = val;
			Encoding = StringFieldEncoding.ASCII;
		}
		public static bool operator ==(StringField prop, string val)
		{
			return prop.Value == val;
		}
		public static bool operator !=(StringField prop, string val)
		{
			return prop.Value != val;
		}
		public override bool Equals(Object obj)
		{
			if (obj.GetType() == GetType())
			{
				StringField a = (StringField)this;
				StringField b = (StringField)obj;
				return a.Value == b.Value && a.Encoding == b.Encoding;
			}
			else if (obj is string)
			{
				return Value == (string)obj;
			}
			return false;
		}
		public override int GetHashCode()
		{
			return Tuple.Create(Value, Encoding).GetHashCode();
		}

		public string Value;
		public StringFieldEncoding Encoding;
	}

	public enum KeyValuePairType
	{
		None = 0,
		String,
		Array,
	}

	public class KeyValuePair
	{
		public StringField Name = new StringField("");

		public virtual KeyValuePairType GetPairType()
		{
			return KeyValuePairType.None;
		}
	}

	public class KeyValuePairString : KeyValuePair
	{
		public StringField Value = new StringField("");

		public override KeyValuePairType GetPairType()
		{
			return KeyValuePairType.String;
		}
	}

	public class KeyValuePairArray : KeyValuePair
	{
		public List<StringField> Values = new List<StringField>();

		public override KeyValuePairType GetPairType()
		{
			return KeyValuePairType.Array;
		}
	}

	class SubsistenceSaveData
	{
		private const UInt32 k_MagicValue = 0xFFFFFFFF;

		private UInt32 Version = 1;
		private UInt32 Magic = k_MagicValue;

		List<KeyValuePair> _properties = new List<KeyValuePair>();

		public bool LoadFile(Stream stream)
		{
			using (BinaryReader reader = new BinaryReader(stream))
			{
				Serialize(reader);
			}
			return true;
		}

		public bool LoadFile(string fileName)
		{
			using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
			{
				Serialize(reader);
			}
			return true;
		}

		public bool SaveFile(string fileName)
		{
			using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.CreateNew)))
			{
				Deserialize(writer);
			}
			return true;
		}

		public bool SaveFile(Stream stream)
		{
			using (BinaryWriter writer = new BinaryWriter(stream))
			{
				Deserialize(writer);
			}
			return true;
		}

		private bool ReadString(BinaryReader stream, ref StringField stringOut)
		{
			Int32 stringLen = stream.ReadInt32();

			if(stringLen < 0)
			{
				// Unicode.
				stringLen = Math.Abs(stringLen);
				int bytesToRead = stringLen * 2;

				byte[] buf = stream.ReadBytes(bytesToRead);
				stringOut.Value = Encoding.Unicode.GetString(buf, 0, bytesToRead - 2);
				stringOut.Encoding = StringFieldEncoding.UNICODE;
			}
			else 
			{
				// ASCII.
				if (stream.BaseStream.Position + stringLen > stream.BaseStream.Length)
					return false;

				byte[] buf = stream.ReadBytes((int)stringLen);
				stringOut.Value = Encoding.UTF8.GetString(buf, 0, buf.Length - 1);
				stringOut.Encoding = StringFieldEncoding.ASCII;
			}

			return true;
		}

		private bool ReadProperty(BinaryReader stream)
		{
			StringField pairName = new StringField("None");
			if(!ReadString(stream, ref pairName))
			{
				return false;
			}
			
			if(pairName != "None")
			{
				StringField propertyType = new StringField("");
				if(!ReadString(stream, ref propertyType))
				{
					return false;
				}

				// Unused for now.
				UInt64 propertyLength = stream.ReadUInt64();

				if (propertyType == "StrProperty")
				{
					KeyValuePairString pair = new KeyValuePairString();
					pair.Name = pairName;

					if(!ReadString(stream, ref pair.Value))
					{
						return false;
					}

					_properties.Add(pair);
				}
				else if(propertyType == "ArrayProperty")
				{
					KeyValuePairArray pair = new KeyValuePairArray();
					pair.Name = pairName;

					UInt32 numElements = stream.ReadUInt32();
					for(UInt32 n = 0; n < numElements; n++)
					{
						StringField elem = new StringField("");
						if (!ReadString(stream, ref elem))
						{
							return false;
						}
						pair.Values.Add(elem);
					}

					_properties.Add(pair);
				}
			}
			else 
			{
				KeyValuePair pair = new KeyValuePair();
				pair.Name = pairName;

				_properties.Add(pair);
			}

			return true;
		}

		public bool WriteString(BinaryWriter stream, StringField prop)
		{
			if(prop.Encoding == StringFieldEncoding.UNICODE)
			{
				Int32 len = -(prop.Value.Length + 1);
				stream.Write(len);

				byte[] buf = Encoding.Unicode.GetBytes(prop.Value);
				stream.Write(buf);

				// 0 terminate.
				stream.Write((Int16)0);
			}
			else if(prop.Encoding == StringFieldEncoding.ASCII)
			{
				Int32 len = (prop.Value.Length + 1);
				stream.Write(len);

				byte[] buf = Encoding.ASCII.GetBytes(prop.Value);
				stream.Write(buf);

				// 0 terminate.
				stream.Write((byte)0);
			}

			return true;
		}

		private bool WriteProperty(BinaryWriter stream, ref KeyValuePair pair)
		{
			WriteString(stream, pair.Name);

			if (pair.Name == "None")
				return true;

			MemoryStream chunk = new MemoryStream();
			BinaryWriter chunkStream = new BinaryWriter(chunk);

			if (pair.GetPairType() == KeyValuePairType.String)
			{
				KeyValuePairString str = (KeyValuePairString)pair;
				WriteString(stream, new StringField("StrProperty"));

				WriteString(chunkStream, str.Value);
			}
			else if (pair.GetPairType() == KeyValuePairType.Array)
			{
				KeyValuePairArray arr = (KeyValuePairArray)pair;
				WriteString(stream, new StringField("ArrayProperty"));

				UInt32 numElements = (UInt32)arr.Values.Count;
				chunkStream.Write(numElements);

				foreach (var elem in arr.Values)
				{
					WriteString(chunkStream, elem);
				}
			}

			UInt64 totalLength = (UInt64)chunk.Length;
			stream.Write(totalLength);
			stream.Write(chunk.GetBuffer(), 0, (int)chunk.Length);

			return true;
		}

		private bool Serialize(BinaryReader stream)
		{
			Version = stream.ReadUInt32();
			if(Version != 1)
			{
				throw new System.InvalidOperationException("Invalid version");
			}

			Magic = stream.ReadUInt32();
			if(Magic != k_MagicValue)
			{
				throw new System.InvalidOperationException("Invalid magic");
			}

			while(stream.BaseStream.Position != stream.BaseStream.Length)
			{
				if(ReadProperty(stream) == false)
				{
					throw new System.InvalidOperationException("Unable to read property");
				}
			}

			return true;
		}

		private bool Deserialize(BinaryWriter stream)
		{
			stream.Write(Version);
			stream.Write(Magic);

			for(Int32 i = 0; i < _properties.Count; i++)
			{
				var pair = _properties.ElementAt(i);
				if(WriteProperty(stream, ref pair) == false)
				{
					throw new System.InvalidOperationException("Unable to write property");
				}
			}

			return true;
		}

		public List<KeyValuePair> GetProperties()
		{
			return _properties;
		}
	}
}
