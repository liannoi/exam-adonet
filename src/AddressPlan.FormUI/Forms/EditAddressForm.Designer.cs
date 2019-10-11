namespace AddressPlan.FormUI.Forms
{
    partial class EditAddressForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.houseNumberTextBox = new System.Windows.Forms.TextBox();
            this.subdivisionsComboBox = new System.Windows.Forms.ComboBox();
            this.streetsComboBox = new System.Windows.Forms.ComboBox();
            this.editButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Номер дома";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Подразделение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Улица";
            // 
            // houseNumberTextBox
            // 
            this.houseNumberTextBox.Location = new System.Drawing.Point(28, 273);
            this.houseNumberTextBox.Name = "houseNumberTextBox";
            this.houseNumberTextBox.Size = new System.Drawing.Size(200, 20);
            this.houseNumberTextBox.TabIndex = 10;
            // 
            // subdivisionsComboBox
            // 
            this.subdivisionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subdivisionsComboBox.FormattingEnabled = true;
            this.subdivisionsComboBox.Location = new System.Drawing.Point(28, 164);
            this.subdivisionsComboBox.Name = "subdivisionsComboBox";
            this.subdivisionsComboBox.Size = new System.Drawing.Size(200, 21);
            this.subdivisionsComboBox.TabIndex = 9;
            // 
            // streetsComboBox
            // 
            this.streetsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.streetsComboBox.FormattingEnabled = true;
            this.streetsComboBox.Location = new System.Drawing.Point(28, 54);
            this.streetsComboBox.Name = "streetsComboBox";
            this.streetsComboBox.Size = new System.Drawing.Size(200, 21);
            this.streetsComboBox.TabIndex = 8;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(390, 415);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(95, 23);
            this.editButton.TabIndex = 7;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // EditAddressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.houseNumberTextBox);
            this.Controls.Add(this.subdivisionsComboBox);
            this.Controls.Add(this.streetsComboBox);
            this.Controls.Add(this.editButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditAddressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изменение адреса - Address Form";
            this.Load += new System.EventHandler(this.EditAddressForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox houseNumberTextBox;
        private System.Windows.Forms.ComboBox subdivisionsComboBox;
        private System.Windows.Forms.ComboBox streetsComboBox;
        private System.Windows.Forms.Button editButton;
    }
}