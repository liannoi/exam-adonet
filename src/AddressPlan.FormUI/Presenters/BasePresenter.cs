using AddressPlan.BL.BusinessObjects;
using AddressPlan.BL.BusinessServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressPlan.FormUI.Presenters
{
    public abstract class BasePresenter<TForm> where TForm : class
    {
        protected TForm Form { get; }

        protected AddressBusinessService AddressBusinessService { get; set; }

        protected StreetBusinessService StreetBusinessService { get; set; }

        protected SubdivisionBusinessService SubdivisionBusinessService { get; set; }

        protected BasePresenter(TForm form)
        {
            Form = form;
            AddressBusinessService = new AddressBusinessService();
            StreetBusinessService = new StreetBusinessService();
            SubdivisionBusinessService = new SubdivisionBusinessService();
        }

        protected abstract void InitializeEvents();

        protected virtual void InitializeStreets(ComboBox comboBox, bool wantNull)
        {
            IEnumerable<StreetBusinessObject> streets = StreetBusinessService.GetStreets(wantNull);
            comboBox.DataSource = streets;
            comboBox.ValueMember = "StreetId";
            comboBox.DisplayMember = "StreetName";
        }

        protected virtual void InitializeSubdivisions(ComboBox comboBox, bool wantNull)
        {
            IEnumerable<SubdivisionBusinessObject> subdivisions = SubdivisionBusinessService.GetSubdivisions(wantNull);
            comboBox.DataSource = subdivisions;
            comboBox.ValueMember = "SubdivisionId";
            comboBox.DisplayMember = "SubdivisionName";
        }

        protected int GetSelectedValue(ComboBox comboBox)
        {
            return Convert.ToInt32(comboBox.SelectedValue);
        }

        public static DialogResult ShowWarning(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Exclamation)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult ShowError(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Hand)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult ShowQuestion(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.YesNo, MessageBoxIcon icon = MessageBoxIcon.Question)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult ShowAlert(string text, string caption, MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Asterisk)
        {
            return MessageBox.Show(text, caption, buttons, icon);
        }
    }
}
