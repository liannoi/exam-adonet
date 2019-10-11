using AddressPlan.FormUI.Presenters;
using System;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class Dashboard : Form
    {
        public ComboBox StreetsComboBox => streetsComboBox;

        public ComboBox SubdivisionsComboBox => subdivisionsComboBox;

        public Button RemoveButton => removeButton;

        public Button AddButton => addButton;

        public DataGridView AddressesDataGridView
        {
            get => addressesDataGridView;
            set => addressesDataGridView = value;
        }

        public EventHandler WinLoad;

        public EventHandler StreetsComboBoxSelectedIndexChanged;

        public EventHandler SubdivisionsComboBoxSelectedIndexChanged;

        public EventHandler RemoveButtonClick;

        public EventHandler AddButtonClick;

        public DataGridViewCellEventHandler GridViewCellDoubleClick;

        public Dashboard()
        {
            InitializeComponent();

            Load += Dashboard_Load;
            streetsComboBox.SelectedIndexChanged += StreetsComboBox_SelectedIndexChanged;
            subdivisionsComboBox.SelectedIndexChanged += SubdivisionsComboBox_SelectedIndexChanged;
            removeButton.Click += RemoveButton_Click;
            addButton.Click += AddButton_Click;
            addressesDataGridView.CellContentDoubleClick += AddressesDataGridView_CellDoubleClick;

            new DashboardPresenter(this);
        }

        private void AddressesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GridViewCellDoubleClick(this, e);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddButtonClick(this, e);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            RemoveButtonClick(this, e);
        }

        private void SubdivisionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubdivisionsComboBoxSelectedIndexChanged(this, e);
        }

        private void StreetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StreetsComboBoxSelectedIndexChanged(this, e);
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            WinLoad(this, e);
        }
    }
}
