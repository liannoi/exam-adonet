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
using AddressPlan.BL.BusinessServices;
using AddressPlan.FormUI.Forms;
using System;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Presenters
{
    public sealed class DashboardPresenter : BasePresenter<Dashboard>
    {
        private bool isLoad;

        public BindingSource BindingAddress { get; private set; }

        public DashboardPresenter(Dashboard form) : base(form)
        {
            isLoad = false;
            InitializeEvents();
        }

        protected override void InitializeEvents()
        {
            Form.WinLoad += FormOnWinLoad;
            Form.StreetsComboBoxSelectedIndexChanged += FormOnStreetsComboBoxSelectedIndexChanged;
            Form.SubdivisionsComboBoxSelectedIndexChanged += FormOnSubdivisionsComboBoxSelectedIndexChanged;
            Form.RemoveButtonClick += FormOnRemoveButtonClick;
            Form.AddButtonClick += FormOnAddButtonClick;
            Form.GridViewCellDoubleClick += FormOnGridViewCellDoubleClick;
        }

        private void FormOnGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddressBusinessObject bindingCurrent = Current();
            AddressDetailsBusinessObject detailsCurrent = AddressBusinessService.Find(bindingCurrent.AddressId);

            AddressDetailsBusinessObject addressDetails = new AddressDetailsBusinessObject
            {
                AddressId = detailsCurrent.AddressId,
                StreetId = detailsCurrent.StreetId,
                HouseNumber = bindingCurrent.House,
                SubdivisionId = detailsCurrent.SubdivisionId
            };

            EditAddressForm editAddressForm = new EditAddressForm(addressDetails);
            editAddressForm.ShowDialog();
            RefreshAfterLoad();
            GC.SuppressFinalize(editAddressForm);
        }

        private void FormOnAddButtonClick(object sender, EventArgs e)
        {
            AddAddressForm addAddressForm = new AddAddressForm();
            addAddressForm.ShowDialog();
            RefreshAfterLoad();
            GC.SuppressFinalize(addAddressForm);
        }

        private void FormOnRemoveButtonClick(object sender, EventArgs e)
        {
            if (ShowWarning("Вы уверены, что хотите удалить эту запись?\n\nВЫ НЕ СМОЖЕТЕ ЕЕ ВОСТАНОВИТЬ.", "Удаление адреса - Address Plan", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }

            AddressBusinessService.Remove(Current().AddressId);
            RefreshAfterLoad();
        }

        private void FormOnSubdivisionsComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void FormOnStreetsComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAfterLoad();
        }

        private void FormOnWinLoad(object sender, EventArgs e)
        {
            InitializeSubdivisions(Form.SubdivisionsComboBox, true);
            InitializeStreets(Form.StreetsComboBox, true);
            RefreshDataGrid();
            isLoad = true;
        }

        #region Helpers

        private void RefreshDataGrid()
        {
            BindingAddress?.ResetBindings(true);
            BindingAddress = new BindingSource
            {
                DataSource = AddressBusinessService.GetAddresses(GetSelectedValue(Form.StreetsComboBox), GetSelectedValue(Form.SubdivisionsComboBox))
            };
            Form.AddressesDataGridView.DataSource = BindingAddress;
        }

        private void RefreshAfterLoad()
        {
            if (!isLoad)
            {
                return;
            }

            RefreshDataGrid();
        }

        private static T Cast<T>(object param) where T : class
        {
            return param as T;
        }

        private AddressBusinessObject Current()
        {
            return Cast<AddressBusinessObject>(BindingAddress.Current);
        }

        #endregion
    }
}
