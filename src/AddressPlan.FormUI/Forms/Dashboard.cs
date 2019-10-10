using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class Dashboard : Form
    {
        private AddressBusinessService addressBusinessService;
        private StreetBusinessService streetBusinessService;
        private SubdivisionBusinessService subdivisionBusinessService;
        private bool isLoad;

        public BindingSource BindingAddress { get; private set; }

        public Dashboard()
        {
            isLoad = false;
            InitializeComponent();
            InitializeServices();
        }

        #region Events

        private void Dashboard_Load(object sender, EventArgs e)
        {
            InitializeSubdivisions();
            InitializeStreets();
            RefreshDataGrid();
            isLoad = true;
        }

        private void StreetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void SubdivisionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ShowWarning("Вы уверены, что хотите удалить эту запись?\n\nВЫ НЕ СМОЖЕТЕ ЕЕ ВОСТАНОВИТЬ.", "Удаление адреса - Address Plan", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            AddressBusinessObject current = BindingAddress.Current as AddressBusinessObject;
            addressBusinessService.Remove(current.AddressId);
            RefreshAfterLoad();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddAddressForm addAddressForm = new AddAddressForm();
            addAddressForm.ShowDialog();
            RefreshAfterLoad();
            GC.SuppressFinalize(addAddressForm);
        }

        private void AddressesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // TODO: Describe the "abstract" logic for editing an address.
        }

        #endregion

        #region Helpers

        private void InitializeServices()
        {
            addressBusinessService = new AddressBusinessService();
            streetBusinessService = new StreetBusinessService();
            subdivisionBusinessService = new SubdivisionBusinessService();
        }

        private void InitializeStreets()
        {
            IEnumerable<StreetBusinessObject> streets = streetBusinessService.GetStreets(true);
            streetsComboBox.DataSource = streets;
            streetsComboBox.ValueMember = "StreetId";
            streetsComboBox.DisplayMember = "StreetName";
        }

        private void InitializeSubdivisions()
        {
            IEnumerable<SubdivisionBusinessObject> subdivisions = subdivisionBusinessService.GetSubdivisions(true);
            subdivisionsComboBox.DataSource = subdivisions;
            subdivisionsComboBox.ValueMember = "SubdivisionId";
            subdivisionsComboBox.DisplayMember = "SubdivisionName";
        }

        private int GetSubdivisionIndex()
        {
            return Convert.ToInt32(subdivisionsComboBox.SelectedValue);
        }

        private int GetStreetIndex()
        {
            return Convert.ToInt32(streetsComboBox.SelectedValue);
        }

        private void RefreshDataGrid()
        {
            BindingAddress?.ResetBindings(true);
            BindingAddress = new BindingSource
            {
                DataSource = addressBusinessService.GetAddresses(GetStreetIndex(), GetSubdivisionIndex())
            };
            addressesDataGridView.DataSource = BindingAddress;
        }

        private void RefreshAfterLoad()
        {
            if (!isLoad)
            {
                return;
            }

            RefreshDataGrid();
        }

        public DialogResult ShowWarning(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Exclamation)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult ShowError(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Hand)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult ShowQuestion(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.YesNo, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public DialogResult ShowAlert(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        #endregion
    }
}
