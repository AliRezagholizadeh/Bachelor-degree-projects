using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mainform
{
    static class Program
    {
        public static Form1 f1;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            f1 = new Form1();
            loadPasswordFromFile("C:\\test.txt");
            Application.Run(f1);

        }
        public static void loadPasswordFromFile(String fileName)
        {
            try
            {
                String line;
                String pass = "";
                System.IO.StreamReader file = new System.IO.StreamReader(fileName);
                while ((line = file.ReadLine()) != null)
                    pass += line;
                file.Close();
                Program.f1.PassWord = pass;
            }
            catch (Exception exc)
            {
                Program.f1.PassWord = "1234";
            }
        }
        public static void savePasswordTofile(String fileName) {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt");
            file.WriteLine(Program.f1.PassWord);

            file.Close();       
        }

    }
}
