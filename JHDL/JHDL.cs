using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Collections.Generic;
using Microsoft.VisualBasic;
namespace JHDL
{
    public partial class JHDL : Form
    {
        public JHDL()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
       
            if (File.Exists("membervariables.dat"))
            {
                using (BinaryReader reader = new BinaryReader(File.Open("membervariables.dat", FileMode.Open)))
                {
                    Member.totalMemberCount = reader.ReadInt32();
                }

            }
        }


        private void toevoegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leden_Toevoegen addUserForm = new Leden_Toevoegen();
            addUserForm.Show();
        }

        private void wijzigenToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
   
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                using (Stream stream = File.Create("Member.dat"))
                {

                    var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    binaryFormatter.Serialize(stream, Member.Members);
                  
                 
                }

                using (BinaryWriter writer = new BinaryWriter(File.Open("membervariables.dat", FileMode.OpenOrCreate)))
                {

                    writer.Write(Member.totalMemberCount);
                    
                }

            }
            catch (Exception ex)
            {
         
                MessageBox.Show("fout bij opslaan");
            
             
                //Log exception here
            }
        }

        private void toevoegenToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            InputDialogBox idb = new InputDialogBox("Een nieuwe rol aanmaken");
            var result = idb.ShowDialog();
            if (result == DialogResult.OK)
            {
                string val = idb.text;
                Console.WriteLine(val);
            }

        }

        private void beherenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RoleManager().Show();
        }
    }
}
