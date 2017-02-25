using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHDL
{
    public partial class Leden_Toevoegen : Form
    {
        private PrintDocument docToPrint = new PrintDocument();
       

        private Font printFont = new Font("Verdana",12) ;
        public Leden_Toevoegen()
        {
            InitializeComponent();
            loadForm();

        }

        /// <summary>
        /// Initialise form. Add the enumerators for gender, permissions and all the members to the corresponding listboxes. 
        /// </summary>
        private void loadForm()
        {
            genderField.DataSource = Enum.GetValues(typeof(Gender));
            MemberPermissionsField.DataSource = Enum.GetValues(typeof(MemberPermissions));
            if (Member.Members.Count > 0)
            {
                memberListBox.Enabled = true;
                memberListBox.DataSource = new BindingSource(Member.Members, null);
                memberListBox.DisplayMember = "Key";
                memberListBox.ValueMember = "Value";
            }
            else
            {
                memberListBox.Enabled = false;
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                // try
                //  {
                String name = nameField.Text;
                String location = locationField.Text;
                String phone = phoneField.Text;
                String email = emailField.Text;
                DateTime birthday = birthDayField.Value;
                Gender gender = (Gender)genderField.SelectedValue;
                MemberPermissions memberPermissions = (MemberPermissions)MemberPermissionsField.SelectedValue;
                Member m = new Member(name, location, phone, email, birthday, gender, memberPermissions, Member.getNewId());
                GenerateBarcode(m.ID);

                m.Password = passWordField.Text;
                if (!Member.Members.ContainsKey(m.Name))
                {
                    Member.Members.Add(name, m);
                    MessageBox.Show("nieuw lid toegevoegd\n\n\r" + m.ToString());
                }
                else
                {
                    MessageBox.Show("Een lid met dezelfde naam bestaat reeds in het gegevensbestand!");
                }
                // }catch(Exception ex)
                //  {
                // MessageBox.Show("Een ongekende fout heeft zich voorgedaan. Probeer opnieuw");
                // MessageBox.Show(ex.StackTrace.ToString());
                //  }

                loadForm();

            }
        }

        private void GenerateBarcode(long id)
        {
            Zen.Barcode.CodeEan13BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeEan13WithChecksum;
            pictureBox1.Image = barcode.Draw(id.ToString(), 100);
        }

     
        /// <summary>
        /// This method checks the input of the new/edit user form with regex. 
        /// </summary>
        /// <returns> returns true when all the Regex in this method matches with the input, otherwise it will return false</returns>
        private bool validateData()
        {
            String name = nameField.Text;
            Regex rgx = new Regex(@"^(\s)*[A-Za-z]+((\s)?((\'|\-|\.)?([A-Za-z])+))*(\s)*$");
            if (!rgx.IsMatch(name))
            {
                MessageBox.Show("Controleer uw naam en probeer opnieuw");
                return false;
            }




            String location = locationField.Text;
            String phone = phoneField.Text;

            rgx = new Regex(@"[0]\d{3}[\/](\d{2}[ ]\d{2}[ ]\d{2}|\d{3}[ ]\d{3})");
            if (!rgx.IsMatch(phone))
            {
                MessageBox.Show("Controleer uw GSM nummer en probeer opnieuw\r\n Gebruik 0xxx/xx xx xx of 0xxx/xxx xxx als format");
                return false;
            }


            String email = emailField.Text;
            rgx = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!rgx.IsMatch(email))
            {
                MessageBox.Show("Dit is waarschijnlijk geen correct e-mailadres \r\n gebruik het format mijnnaam@mijnprovider.be of bv   mijnnaam@mijnprovider.com)");
                return false;
            }

            if (!passWordFieldCheck.Text.Equals(passWordField.Text)||passWordField.Text.Length<4)
            {

                MessageBox.Show("Paswoorden komen niet overeen, of korter dan 4 tekens");
                return false;
            }

            return true;

        }

        private void disablePasswordField(object sender, EventArgs e)
        {
            if ((int)MemberPermissionsField.SelectedValue >= 1)
            {
                passWordField.Enabled = true;
                passWordFieldCheck.Enabled = true;

            }
            else
            {
                passWordField.Enabled = false;
                passWordFieldCheck.Enabled = false;
                passWordField.Text = "";
                passWordFieldCheck.Text = "";
            }
        }

        /// <summary>
        /// This method will initialise the fields in the new/edit user form when a 
        /// </summary>
       private void setInitialData(object sender, EventArgs e)
        {
            if (memberListBox.Enabled)
            {
                KeyValuePair<String, Member> kvpm = (KeyValuePair<String, Member>)memberListBox.SelectedItem;
                Member m = kvpm.Value;
                nameField.Text = m.Name;
                MembershipCardNameField.Text = ("lidkaart van " + m.Name);
                emailField.Text = m.Email;
                passWordField.Text = m.Password;
                passWordFieldCheck.Text = m.Password;
                phoneField.Text = m.Phone;
                birthDayField.Value = m.Birthday;
                locationField.Text = m.City;
                genderField.SelectedIndex = (int)m.Gender;
                try
                {
                    MemberPermissionsField.SelectedIndex = (int) m.MemberPermissions;
                }catch(InvalidOperationException ex)
                {
                    MessageBox.Show("error" + ex.ToString() + ex.StackTrace + ex.HelpLink + ex.Message);
                }
          
                iDLabel.Text = ("id" + m.ID);
                GenerateBarcode(m.ID);

            }
        }

        private void editUserButton_Click(object sender, EventArgs e)
        {
            if (validateData())
            {
                Member m = getCurrentMember();
                m.Name = nameField.Text;
                m.Email = emailField.Text;
                m.Password = passWordField.Text;
                m.Phone = phoneField.Text;
                m.Birthday = birthDayField.Value;
                m.City = locationField.Text;
                m.Gender = (Gender)genderField.SelectedIndex;
                m.MemberPermissions = (MemberPermissions)MemberPermissionsField.SelectedIndex;

            }
        }

        private Member getCurrentMember()
        {
            KeyValuePair<String, Member> kvpm = (KeyValuePair<String, Member>) memberListBox.SelectedItem;
            Member m = kvpm.Value;
            return m;
        }

        private void removeMemberButton_Click(object sender, EventArgs e)
        {
            Member.Members.Remove(nameField.Text);
            MessageBox.Show("" + nameField.Text + " is niet langer lid van JHDL");
            loadForm();

        }

        /// <summary>
        /// This function will be executed when the user wants to print a label for a membership card 
        /// </summary>
        private void printMembershipCardLabelButton_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            docToPrint.PrintPage += new PrintPageEventHandler
                  (this.document_PrintPage);
            // Do Not Allow the user to choose the page range he or she would
            // like to print.
            printDialog1.AllowSomePages = false;

            // Show the help button.
            printDialog1.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
        
            printDialog1.Document = docToPrint;

            docToPrint.DefaultPageSettings.PaperSize = new PaperSize("sticker", 170, 250);
            docToPrint.DefaultPageSettings.Landscape = true;
            DialogResult result = printDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }


        }

        private void document_PrintPage(object sender,  PrintPageEventArgs e)
        {

            // Insert code to render the page here.
            // This code will be called when the control is drawn.

            // The following code will render a simple
            // message on the printed document.
            Member m = getCurrentMember();

            string name = "lidkaart van: " + m.Name ;
            string ID = m.ID.ToString();
            long IDasInt = m.ID;
            string part1 = (IDasInt / 1000000).ToString();
            string part2 = (IDasInt % 1000000).ToString();

            Font printFont = new Font("Verdana", 8, FontStyle.Regular);
           
            // Draw the content.
            e.Graphics.DrawString(name, printFont,Brushes.Black, 10, 10);
           

            Zen.Barcode.CodeEan13BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.CodeEan13WithChecksum;
            e.Graphics.DrawImage(barcode.Draw(ID, 100),110,36);
             printFont = new Font("Verdana", 5, FontStyle.Regular);
            e.Graphics.DrawString(part1, printFont, Brushes.Black, 120, 135);
            e.Graphics.DrawString(part2, printFont, Brushes.Black, 170, 135);
        }
    }
}
