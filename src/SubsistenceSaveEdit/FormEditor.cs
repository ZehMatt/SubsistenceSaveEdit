using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubsistenceSaveEdit
{
	public partial class frmMain : Form
	{
		private SubsistenceSaveData _saveData = null;
		private Int32 _currentSelection = -1;
		private Int32 _valueSelection = -1;

		public frmMain()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void PopulateFields()
		{
			listProperties.Items.Clear();

			var props = _saveData.GetProperties();
			for (Int32 i = 0; i < props.Count; i++)
			{
				var elem = props.ElementAt(i);
				if (elem.Name == "None")
					continue; // Skip terminator.

				var item = listProperties.Items.Add(elem.Name.Value);
				if(elem.GetPairType() == KeyValuePairType.String)
				{
					item.SubItems.Add("String");
				}
				else if(elem.GetPairType() == KeyValuePairType.Array)
				{
					item.SubItems.Add("Array");
				}
			}
		}

		private void PopulateValues()
		{
			listValues.Items.Clear();

			var props = _saveData.GetProperties();
			if (_currentSelection > props.Count || _currentSelection == -1)
				return;

			var elem = props.ElementAt(_currentSelection);
			if(elem.GetPairType() == KeyValuePairType.String)
			{
				var item = listValues.Items.Add("0");
				item.SubItems.Add(((KeyValuePairString)elem).Value.Value);
			}
			else if(elem.GetPairType() == KeyValuePairType.Array)
			{
				var arr = (KeyValuePairArray)elem;
				for(Int32 n = 0; n < arr.Values.Count; n++)
				{
					var item = listValues.Items.Add(n.ToString());
					var prop = arr.Values[n];
					item.SubItems.Add(prop.Value);
				}
			}
		}

		private void btLoad_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "Save Files (*.sav)|*.sav";
			openDlg.RestoreDirectory = true;
			openDlg.Multiselect = false;

			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				_saveData = new SubsistenceSaveData();
				using (System.IO.Stream stream = openDlg.OpenFile())
				{
					if(_saveData.LoadFile(stream))
					{
						_currentSelection = -1;
						_valueSelection = -1;

						btModify.Enabled = false;
						btSave.Enabled = true;

						PopulateFields();
						PopulateValues();
					}
				}
			}
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			if (_saveData == null)
				return;

			SaveFileDialog openDlg = new SaveFileDialog();
			openDlg.Filter = "Save Files (*.sav)|*.sav";
			openDlg.RestoreDirectory = true;
			openDlg.CheckFileExists = false;

			if (openDlg.ShowDialog() == DialogResult.OK)
			{
				using (System.IO.Stream stream = openDlg.OpenFile())
				{
					_saveData.SaveFile(stream);
				}
			}
		}

		private void OnPropertyItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.IsSelected == false)
			{
				listValues.Items.Clear();
				btModify.Enabled = false;
				_currentSelection = -1;
				return;
			}

			_currentSelection = e.ItemIndex;
			PopulateValues();
		}

		private void OnPropertyValueItemSelected(object sender, ListViewItemSelectionChangedEventArgs e)
		{
			if(e.IsSelected == false)
			{
				_valueSelection = -1;
				btModify.Enabled = false;
				return;
			}

			_valueSelection = e.ItemIndex;
			btModify.Enabled = _currentSelection != -1;
		}

		private static DialogResult ShowInputDialog(ref string input)
		{
			System.Drawing.Size size = new System.Drawing.Size(500, 300);
			Form inputBox = new Form();
			inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			inputBox.ClientSize = size;
			inputBox.Text = "Modify value";
			inputBox.StartPosition = FormStartPosition.CenterScreen;

			System.Windows.Forms.TextBox textBox = new TextBox();
			textBox.Size = new System.Drawing.Size(size.Width - 10, size.Height - 40);
			textBox.Location = new System.Drawing.Point(5, 5);
			textBox.Multiline = true;
			textBox.Text = input;
			textBox.Font = new Font("Consolas", 10);

			textBox.SelectionLength = 0;

			inputBox.Controls.Add(textBox);

			Button okButton = new Button();
			okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			okButton.Name = "okButton";
			okButton.Size = new System.Drawing.Size(75, 23);
			okButton.Text = "&OK";
			okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, size.Height - 32);
			inputBox.Controls.Add(okButton);

			Button cancelButton = new Button();
			cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			cancelButton.Name = "cancelButton";
			cancelButton.Size = new System.Drawing.Size(75, 23);
			cancelButton.Text = "&Cancel";
			cancelButton.Location = new System.Drawing.Point(size.Width - 80, size.Height - 32);
			inputBox.Controls.Add(cancelButton);

			inputBox.AcceptButton = okButton;
			inputBox.CancelButton = cancelButton;

			DialogResult result = inputBox.ShowDialog();
			input = textBox.Text;

			return result;
		}

		private void ModifySelectedValue()
		{
			if (_currentSelection == -1 || _valueSelection == -1)
				return;

			var props = _saveData.GetProperties();
			if (_currentSelection > props.Count)
				return;

			string newValue = "";

			var elem = props.ElementAt(_currentSelection);
			if (elem.GetPairType() == KeyValuePairType.String)
			{
				// Value is always the element its self.
				newValue = ((KeyValuePairString)elem).Value.Value;
			}
			else if (elem.GetPairType() == KeyValuePairType.Array)
			{
				var arr = (KeyValuePairArray)elem;
				var prop = arr.Values[_valueSelection];
				newValue = prop.Value;
			}

			if (ShowInputDialog(ref newValue) != DialogResult.OK)
				return;

			// Update record.
			if (elem.GetPairType() == KeyValuePairType.String)
			{
				// Value is always the element its self.
				((KeyValuePairString)elem).Value.Value = newValue;

				var selectedItem = listValues.Items[0];
				selectedItem.SubItems[1].Text = newValue;
			}
			else if (elem.GetPairType() == KeyValuePairType.Array)
			{
				var arr = (KeyValuePairArray)elem;
				arr.Values[_valueSelection].Value = newValue;

				var selectedItem = listValues.Items[_valueSelection];
				selectedItem.SubItems[1].Text = newValue;
			}
		}

		private void btModify_Click(object sender, EventArgs e)
		{
			ModifySelectedValue();
		}

		private void OnValueEditDblClick(object sender, EventArgs e)
		{
			ModifySelectedValue();
		}
	}
}
