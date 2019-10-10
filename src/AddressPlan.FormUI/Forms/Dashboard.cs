using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class Dashboard : Form
    {
        private BindingSource bindingAddress;
        private AddressPlanBusinessService addressPlanBusinessService;
        private bool isLoad;

        public Dashboard()
        {
            isLoad = false;
            InitializeComponent();
            addressPlanBusinessService = new AddressPlanBusinessService();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            IEnumerable<SubdivisionBusinessObject> subdivisions = addressPlanBusinessService.GetSubdivisions(true);

            subdivisionsComboBox.DataSource = subdivisions;
            subdivisionsComboBox.ValueMember = "SubdivisionId";
            subdivisionsComboBox.DisplayMember = "SubdivisionName";

            IEnumerable<StreetBusinessObject> streets = addressPlanBusinessService.GetStreets(true);
            // TODO: Edit streets.
            streetsComboBox.DataSource = streets;
            streetsComboBox.ValueMember = "AddressId";
            streetsComboBox.DisplayMember = "StreetName";

            RefreshDataGrid();
            isLoad = true;
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
            bindingAddress?.ResetBindings(true);

            bindingAddress = new BindingSource
            {
                DataSource = addressPlanBusinessService.GetStreets(GetSubdivisionIndex(), GetStreetIndex())
            };
            addressesDataGridView.DataSource = bindingAddress;
        }

        private void StreetsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void SubdivisionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void RefreshAfterLoad()
        {
            if (isLoad)
            {
                RefreshDataGrid();
            }
        }
    }
}
