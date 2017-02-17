using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asi.iBO;
using Asi.iBO.ContactManagement;
using Asi.Security;

namespace ContactEditor
{
    public partial class Edit : Form
    {
        readonly IiMISUser _iMisUser = CContactUser.LoginByWebLogin("MANAGER");
        public Edit()
        {
            InitializeComponent();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxId.Text))
                return;
            try
            {
                using (Asi.Security.SecurityContext.Impersonate("MANAGER"))
                { 
                    var contact = new CContact(_iMisUser, textBoxId.Text);
                    textBoxFirstName.Text = contact.FirstName;
                    textBoxLastName.Text = contact.LastName;
                    if (contact.BirthDate != DateTime.MinValue)
                        dateTimePickerDOB.Value = contact.BirthDate;
                    else
                        dateTimePickerDOB.Value = DateTime.Today;
                    MessageBox.Show("Contact Loaded Successfully");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Load");
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (Asi.Security.SecurityContext.Impersonate("MANAGER"))
                {
                    var contact = new CContact(_iMisUser, textBoxId.Text);
                    contact.FirstName = textBoxFirstName.Text;
                    contact.LastName = textBoxLastName.Text;
                    if (dateTimePickerDOB.Value != DateTime.Today)
                        contact.BirthDate = dateTimePickerDOB.Value;
                    if (contact.Validate())
                        contact.Save();

                    MessageBox.Show("Contact Saved Successfully");

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Save");
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            buttonLoad_Click(sender, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxId.Text = "";
        }
    }
}
