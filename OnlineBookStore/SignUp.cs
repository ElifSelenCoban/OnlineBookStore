using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Xml.Linq;

namespace OnlineBookStore
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        Customerlist customerlist = new Customerlist();
        private void btnSignup_Click(object sender, EventArgs e)
        {
            ArrayList allrecord = customerlist.ReadXML();
            bool flag = false;
            foreach (Customer csm in allrecord)
            {
                if (txtMail.Text == csm.CustomerEmail1)
                {
                    MessageBox.Show("This email is already used!");
                    flag = true;
                }
            }
            if (string.IsNullOrWhiteSpace(txtName.Text)|| string.IsNullOrWhiteSpace(txtMail.Text)|| string.IsNullOrWhiteSpace(txtLastname.Text)|| string.IsNullOrWhiteSpace(txtPassword.Text)|| string.IsNullOrWhiteSpace(txtPassword2.Text)||string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Please fill in the blanks.", "Warning", MessageBoxButtons.OK);
            }
           
           else   if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("Passwords are not matching!");
            }

         
            else if (chkMA.Checked == false)
            {
                MessageBox.Show("First, you have to accept Membership Agreement.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            else if (txtPassword.Text == txtPassword2.Text && chkMA.Checked == true && flag == false)
            {
                XDocument x = XDocument.Load(@"CustomerList.xml");
                x.Element("ArrayOfCustomer").Add(
                new XElement("Customer",
                new XElement("CustomerName", txtName.Text), new XElement("CustomerLastName", txtLastname.Text),
                new XElement("CustomerEmail", txtMail.Text),
                new XElement("CustomerPhoneNumber", txtPhone.Text),
                new XElement("CustomerPassword", txtPassword.Text)
                ));
                x.Save(@"CustomerList.xml");
                MessageBox.Show("Record  is Completed");
                txtName.Text = null;
                txtMail.Text = null;
                txtPhone.Text = null;
                txtLastname.Text = null;
                txtPassword.Text = null;
                txtPassword2.Text = null;
                chkMA.Checked = false;
            }
        }
        

       
        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

       
        private void chkMA_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to teda.com. Teda Services LLC and/or its affiliates (teda) provide website features and other products and services to you when you visit or shop at teda.com, use teda products or services, use teda applications for mobile, or use software provided by teda in connection with any of the foregoing (collectively, Teda Services). Teda provides the Teda Services subject to the following conditions.", " ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                       && !char.IsSeparator(e.KeyChar);
        }

        private void txtLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                       && !char.IsSeparator(e.KeyChar);
        }
    }
}
