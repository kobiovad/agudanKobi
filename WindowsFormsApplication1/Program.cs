using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new login());
           // Application.Run(new menu("kobi"));
            // (new login()).Show();
           // (new menu("kobi")).Show();
            //(new loadingbar()).Show();
            //Application.Run();
        }
    }
}
