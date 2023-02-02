using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace test111
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]


        /*UnhandledExceptionEventHandler MyHandler(Exception ex)
        {
            return 0;
        }*/
        static void Main(string[] args)
        {

            // Set the unhandled exception mode to force all Windows Forms 
            // errors to go through our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            // AppDomain currentDomain = AppDomain.CurrentDomain;
            // currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                if (args[0] == "kassa")
                {
                    FormKassa f = new FormKassa();

                    if (args.Length > 1)
                    {
                        if (args[1] == "merkado")
                        {
                            f.comboBox1.SelectedIndex = 1;
                        }
                    }


                    f.checkBox_timer.Checked = true;
                    f.timer1.Enabled = true;
                    f.ShowDialog();
                }

                if (args[0] == "print_ol")
                {
                    FormTovsheet f = new FormTovsheet();
                    f.textBox_idsheet.Text = args[1];
                    f.ShowDialog();
                }

                if (args[0] == "print_bd")
                {
                    FormDoc f = new FormDoc();
                    f.textBox_iddoc.Text = args[1];
                    f.ShowDialog();
                }

                if (args[0] == "sync_db")
                {

                }

            }
            Application.Run(new Form1());

        }
    }
}