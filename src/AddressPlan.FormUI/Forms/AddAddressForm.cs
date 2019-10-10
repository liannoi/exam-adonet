using AddressPlan.FormUI.Presenters;
using System;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class AddAddressForm : Form
    {
        public TextBox HouseNumberTextBox => houseNumberTextBox;

        public ComboBox SubdivisionsComboBox => subdivisionsComboBox;

        public ComboBox StreetsComboBox => streetsComboBox;

        public EventHandler AddButtonClick;

        public EventHandler WinLoad;

        public AddAddressForm()
        {
            InitializeComponent();

            addButton.Click += AddButton_Click;
            Load += AddAddressForm_Load;

            new AddAddressPresenter(this);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddButtonClick(this, e);
        }

        private void AddAddressForm_Load(object sender, EventArgs e)
        {
            WinLoad(this, e);
        }
    }
}
