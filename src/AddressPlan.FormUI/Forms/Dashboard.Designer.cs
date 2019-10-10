namespace AddressPlan.FormUI.Forms
{
    partial class Dashboard
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
            this.subdivisionsComboBox = new System.Windows.Forms.ComboBox();
            this.streetsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.addressesDataGridView = new System.Windows.Forms.DataGridView();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.addressesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // subdivisionsComboBox
            // 
            this.subdivisionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subdivisionsComboBox.FormattingEnabled = true;
            this.subdivisionsComboBox.Location = new System.Drawing.Point(1002, 37);
            this.subdivisionsComboBox.Name = "subdivisionsComboBox";
            this.subdivisionsComboBox.Size = new System.Drawing.Size(250, 21);
            this.subdivisionsComboBox.TabIndex = 1;
            this.subdivisionsComboBox.SelectedIndexChanged += new System.EventHandler(this.SubdivisionsComboBox_SelectedIndexChanged);
            // 
            // streetsComboBox
            // 
            this.streetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.streetsComboBox.FormattingEnabled = true;
            this.streetsComboBox.Location = new System.Drawing.Point(1002, 107);
            this.streetsComboBox.Name = "streetsComboBox";
            this.streetsComboBox.Size = new System.Drawing.Size(250, 21);
            this.streetsComboBox.TabIndex = 2;
            this.streetsComboBox.SelectedIndexChanged += new System.EventHandler(this.StreetsComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(999, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Подразделения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(999, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Улицы";
            // 
            // addressesDataGridView
            // 
            this.addressesDataGridView.AllowUserToAddRows = false;
            this.addressesDataGridView.AllowUserToDeleteRows = false;
            this.addressesDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.addressesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.addressesDataGridView.GridColor = System.Drawing.Color.White;
            this.addressesDataGridView.Location = new System.Drawing.Point(12, 12);
            this.addressesDataGridView.MultiSelect = false;
            this.addressesDataGridView.Name = "addressesDataGridView";
            this.addressesDataGridView.ReadOnly = true;
            this.addressesDataGridView.Size = new System.Drawing.Size(969, 658);
            this.addressesDataGridView.TabIndex = 5;
            this.addressesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AddressesDataGridView_CellDoubleClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(1127, 647);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(125, 23);
            this.addButton.TabIndex = 6;
            this.addButton.Text = "Добавить";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(996, 647);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(125, 23);
            this.removeButton.TabIndex = 9;
            this.removeButton.Text = "Удалить";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.addressesDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.streetsComboBox);
            this.Controls.Add(this.subdivisionsComboBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Address Plan";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.addressesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox subdivisionsComboBox;
        private System.Windows.Forms.ComboBox streetsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView addressesDataGridView;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
    }
}