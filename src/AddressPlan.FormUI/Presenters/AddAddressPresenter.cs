using AddressPlan.BL.BusinessObjects;
using AddressPlan.FormUI.Forms;
using System;

namespace AddressPlan.FormUI.Presenters
{
    public sealed class AddAddressPresenter : BasePresenter<AddAddressForm>
    {
        public AddAddressPresenter(AddAddressForm form) : base(form)
        {
            InitializeEvents();
        }

        protected override void InitializeEvents()
        {
            Form.WinLoad += FormOnWinLoad;
            Form.AddButtonClick += AddButtonOnClick;
        }

        private void AddButtonOnClick(object sender, EventArgs e)
        {
            AddressBusinessService.Add(new AddressDetailsBusinessObject
            {
                HouseNumber = Form.HouseNumberTextBox.Text,
                StreetId = GetSelectedValue(Form.StreetsComboBox),
                SubdivisionId = GetSelectedValue(Form.SubdivisionsComboBox)
            });
            Form.Close();
        }

        private void FormOnWinLoad(object sender, EventArgs e)
        {
            InitializeSubdivisions(Form.SubdivisionsComboBox, false);
            InitializeStreets(Form.StreetsComboBox, false);
        }
    }
}
