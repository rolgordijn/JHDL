using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHDL
{
    /// <summary>
    /// Firstuserform: this form will be displayed when the program is executed for the first time. This will allow the user to create a user account that he or she can use to login.
    /// Further account details can later be added with the software. 
    /// </summary>
    public partial class FirstUserForm : Form
    {
        public FirstUserForm()
        {
            InitializeComponent();
        }

        private void createFirstUser(object sender, EventArgs e)
        {
            if (passWordBox.Text.Equals(checkPassWordBox.Text))
            {
                if (passWordBox.Text.Length < 5)
                {
                    MessageBox.Show("Het ingevoerde wachtwoord moet uit tenminste 5 tekens bestaan");

                }
                else
                {
                    Member m = new Member(nameBox.Text, passWordBox.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Ingevoerde paswoorden komen niet overeen, probeer het opnieuw");
            }
        }
    }
}
