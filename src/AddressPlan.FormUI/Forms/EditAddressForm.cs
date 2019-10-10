using AddressPlan.BL.BusinessObjects;
using AddressPlan.FormUI.Presenters;
using System;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class EditAddressForm : Form
    {
        public EventHandler WinLoad;

        public EventHandler EditButtonClick;

        public TextBox HouseNumberTextBox => houseNumberTextBox;

        public ComboBox SubdivisionsComboBox => subdivisionsComboBox;

        public ComboBox StreetsComboBox => streetsComboBox;

        public EditAddressForm(AddressDetailsBusinessObject transfered)
        {
            InitializeComponent();

            editButton.Click += EditButton_Click;
            Load += EditAddressForm_Load;

            new EditAddressPresenter(this, transfered);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            EditButtonClick(this, e);
        }

        private void EditAddressForm_Load(object sender, EventArgs e)
        {
            WinLoad(this, e);
        }
    }
}
