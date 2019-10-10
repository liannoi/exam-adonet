using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Forms
{
    public partial class EditAddressForm : Form
    {
        private AddressBusinessService addressBusinessService;
        private StreetBusinessService streetBusinessService;
        private SubdivisionBusinessService subdivisionBusinessService;
        private readonly AddressDetailsBusinessObject addressDetails;

        public EditAddressForm(AddressDetailsBusinessObject addressDetails)
        {
            this.addressDetails = addressDetails;
            InitializeComponent();
            InitializeServices();
        }

        #region Events

        private void EditButton_Click(object sender, EventArgs e)
        {
            addressDetails.HouseNumber = houseNumberTextBox.Text;
            addressDetails.StreetId = GetStreetIndex();
            addressDetails.SubdivisionId = GetSubdivisionIndex();
            addressBusinessService.Update(addressDetails);
            Close();
        }

        private void EditAddressForm_Load(object sender, EventArgs e)
        {
            InitializeSubdivisions();
            InitializeStreets();
            houseNumberTextBox.Text = addressDetails.HouseNumber;            
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
            streetsComboBox.SelectedValue = addressDetails.StreetId;
        }

        private void InitializeSubdivisions()
        {
            IEnumerable<SubdivisionBusinessObject> subdivisions = subdivisionBusinessService.GetSubdivisions(false);
            subdivisionsComboBox.DataSource = subdivisions;
            subdivisionsComboBox.ValueMember = "SubdivisionId";
            subdivisionsComboBox.DisplayMember = "SubdivisionName";
            subdivisionsComboBox.SelectedValue = addressDetails.SubdivisionId;
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
