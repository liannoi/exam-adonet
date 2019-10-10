using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class AddAddressForm : Form
    {
        private AddressBusinessService addressBusinessService;
        private StreetBusinessService streetBusinessService;
        private SubdivisionBusinessService subdivisionBusinessService;

        public AddAddressForm()
        {
            InitializeComponent();
            InitializeServices();
        }

        #region Events

        private void AddButton_Click(object sender, EventArgs e)
        {
            addressBusinessService.Add(houseNumberTextBox.Text, GetStreetIndex(), GetSubdivisionIndex());
            Close();
        }

        private void AddAddressForm_Load(object sender, EventArgs e)
        {
            InitializeSubdivisions();
            InitializeStreets();
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
            IEnumerable<StreetBusinessObject> streets = streetBusinessService.GetStreets(false);
            streetsComboBox.DataSource = streets;
            streetsComboBox.ValueMember = "StreetId";
            streetsComboBox.DisplayMember = "StreetName";
        }

        private void InitializeSubdivisions()
        {
            IEnumerable<SubdivisionBusinessObject> subdivisions = subdivisionBusinessService.GetSubdivisions(false);
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

        #endregion
    }
}
