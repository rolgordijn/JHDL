using System;
using System.Windows.Forms;

namespace JHDL
{
    public partial class InputDialogBox : Form
    {
        public String text;
        public InputDialogBox(String question)
        {
            InitializeComponent();
            inputDialogQuestion.Text = question;
        }

        private void dialogResultOKButton_click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
