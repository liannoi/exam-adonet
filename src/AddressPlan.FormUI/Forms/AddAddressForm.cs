// Copyright 2019 Maksym Liannoi
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
