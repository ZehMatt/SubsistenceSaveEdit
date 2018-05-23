namespace SubsistenceSaveEdit
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.listProperties = new System.Windows.Forms.ListView();
			this.clName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.clType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btModify = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.btSave = new System.Windows.Forms.Button();
			this.btLoad = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.listValues = new System.Windows.Forms.ListView();
			this.ctValueIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.ctValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// listProperties
			// 
			this.listProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clName,
            this.clType});
			this.listProperties.FullRowSelect = true;
			this.listProperties.GridLines = true;
			this.listProperties.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listProperties.Location = new System.Drawing.Point(3, 3);
			this.listProperties.MultiSelect = false;
			this.listProperties.Name = "listProperties";
			this.listProperties.Size = new System.Drawing.Size(274, 348);
			this.listProperties.TabIndex = 4;
			this.listProperties.UseCompatibleStateImageBehavior = false;
			this.listProperties.View = System.Windows.Forms.View.Details;
			this.listProperties.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnPropertyItemSelected);
			// 
			// clName
			// 
			this.clName.Text = "Name";
			this.clName.Width = 150;
			// 
			// clType
			// 
			this.clType.Text = "Type";
			this.clType.Width = 100;
			// 
			// btModify
			// 
			this.btModify.Enabled = false;
			this.btModify.Location = new System.Drawing.Point(3, 327);
			this.btModify.Name = "btModify";
			this.btModify.Size = new System.Drawing.Size(109, 21);
			this.btModify.TabIndex = 6;
			this.btModify.Text = "Modify Value";
			this.btModify.UseVisualStyleBackColor = true;
			this.btModify.Click += new System.EventHandler(this.btModify_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.18182F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.81818F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 396);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// btSave
			// 
			this.btSave.Enabled = false;
			this.btSave.Location = new System.Drawing.Point(83, 6);
			this.btSave.Name = "btSave";
			this.btSave.Size = new System.Drawing.Size(75, 21);
			this.btSave.TabIndex = 5;
			this.btSave.Text = "Save";
			this.btSave.UseVisualStyleBackColor = true;
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// btLoad
			// 
			this.btLoad.Location = new System.Drawing.Point(3, 6);
			this.btLoad.Name = "btLoad";
			this.btLoad.Size = new System.Drawing.Size(74, 21);
			this.btLoad.TabIndex = 6;
			this.btLoad.Text = "Load";
			this.btLoad.UseVisualStyleBackColor = true;
			this.btLoad.Click += new System.EventHandler(this.btLoad_Click);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btSave);
			this.panel1.Controls.Add(this.btLoad);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(170, 27);
			this.panel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.listProperties, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 45);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(788, 354);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Controls.Add(this.btModify, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.listValues, 0, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(280, 0);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(508, 354);
			this.tableLayoutPanel3.TabIndex = 5;
			// 
			// listValues
			// 
			this.listValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listValues.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ctValueIndex,
            this.ctValue});
			this.listValues.FullRowSelect = true;
			this.listValues.GridLines = true;
			this.listValues.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listValues.Location = new System.Drawing.Point(3, 3);
			this.listValues.Name = "listValues";
			this.listValues.Size = new System.Drawing.Size(502, 318);
			this.listValues.TabIndex = 5;
			this.listValues.UseCompatibleStateImageBehavior = false;
			this.listValues.View = System.Windows.Forms.View.Details;
			this.listValues.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.OnPropertyValueItemSelected);
			this.listValues.DoubleClick += new System.EventHandler(this.OnValueEditDblClick);
			// 
			// ctValueIndex
			// 
			this.ctValueIndex.Text = "#";
			this.ctValueIndex.Width = 50;
			// 
			// ctValue
			// 
			this.ctValue.Text = "Value";
			this.ctValue.Width = 450;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(811, 407);
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Subsistence Save Edit";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ListView listProperties;
		private System.Windows.Forms.ColumnHeader clName;
		private System.Windows.Forms.ColumnHeader clType;
		private System.Windows.Forms.Button btModify;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.Button btLoad;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ListView listValues;
		private System.Windows.Forms.ColumnHeader ctValueIndex;
		private System.Windows.Forms.ColumnHeader ctValue;
	}
}

