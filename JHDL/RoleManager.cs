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
    public partial class RoleManager : Form
    {
        public RoleManager()
        {
            InitializeComponent();
            dataGridView1.Rows.Add("beheerder");
            dataGridView1.Rows.Add("bestuurder");
            dataGridView1.Rows.Add("lid");
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
