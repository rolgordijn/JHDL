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
    public partial class FirstUserForm : Form
    {
        public FirstUserForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
