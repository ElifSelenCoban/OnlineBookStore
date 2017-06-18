using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineBookStore
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            LoginCustomer customerprofile = LoginCustomer.getInstance();
            string[] profile = customerprofile.customer.printCustomerDetails();
            lblName.Text = profile[0];
            lblLastname.Text = profile[1];
            lblEmail.Text = profile[2];
            lblPhone.Text = profile[3];
            label5.Visible = false;
            if (Payment.rtnpay() == true)
            {
                label5.Visible = true;
            }
        }
    }
}
