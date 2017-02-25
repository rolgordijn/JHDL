using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHDL
{ 
    
    static class Program
    {
        public static bool DEBUG = true;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                if (File.Exists("Member.dat"))
                {

                    using (Stream stream = File.Open("Member.dat", FileMode.Open))
                    {
                        var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        Member.Members = (Dictionary<string, Member>)binaryFormatter.Deserialize(stream);

                    }
                    if (!DEBUG) { 
                    Application.Run(new LoginForm());
                    }
                    else{
                        Application.Run(new JHDL());
                    }
                }
                else
                {
                    Form fuf = new FirstUserForm();
                    fuf.ShowDialog();
                    Application.Run(new JHDL());

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fout bij het laden van ledenbestand");
            }
          
            
        }
    }
}
