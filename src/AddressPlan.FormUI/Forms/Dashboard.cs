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
