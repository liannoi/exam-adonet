// Copyright 2020 Maksym Liannoi
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
