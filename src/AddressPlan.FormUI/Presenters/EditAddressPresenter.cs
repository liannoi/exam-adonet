using AddressPlan.BL.BusinessObjects;
using AddressPlan.FormUI.Forms;
using System;

namespace AddressPlan.FormUI.Presenters
{
    public sealed class EditAddressPresenter : BasePresenter<EditAddressForm>
    {
        private readonly AddressDetailsBusinessObject transfered;

        public EditAddressPresenter(EditAddressForm form, AddressDetailsBusinessObject transfered) : base(form)
        {
            this.transfered = transfered;
            InitializeEvents();
        }

        protected override void InitializeEvents()
        {
            Form.WinLoad += FormOnLoad;
            Form.EditButtonClick += FormOnEditButtonClick;
        }

        private void FormOnEditButtonClick(object sender, EventArgs e)
        {
            transfered.HouseNumber = Form.HouseNumberTextBox.Text;
            transfered.StreetId = GetSelectedValue(Form.StreetsComboBox);
            transfered.SubdivisionId = GetSelectedValue(Form.SubdivisionsComboBox);
            AddressBusinessService.Update(transfered);
            Form.Close();
        }

        private void FormOnLoad(object sender, EventArgs e)
        {
            InitializeSubdivisions(Form.SubdivisionsComboBox, false);
            InitializeStreets(Form.StreetsComboBox, false);
            Form.HouseNumberTextBox.Text = transfered.HouseNumber;
            Form.SubdivisionsComboBox.SelectedValue = transfered.SubdivisionId;
            Form.StreetsComboBox.SelectedValue = transfered.StreetId;
        }
    }
}
