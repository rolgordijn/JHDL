using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHDL
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            String name = nameInputBox.Text;
            String password = passWordBox.Text;
            Member m;
            if(Member.Members.TryGetValue(name, out m) && m.Password.Equals(password))
            {
                if (m.Password.Equals(""))
                {
                    MessageBox.Show("u heeft geen toegang tot dit programma");
                }
                else
                {
                    JHDL main = new JHDL();
                    this.Hide();
                    Thread.Sleep(200);
                    main.Show();
                }
               
           
            }
            else
            {
                MessageBox.Show("Gebruikersnaam en wachtwoord komen niet overeen");
            }




        }
    }
}
