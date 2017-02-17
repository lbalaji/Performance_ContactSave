using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Asi.iBO;
using Asi.iBO.ContactManagement;
using Asi.Security;

namespace ContactEditor
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            iboAdmin.InitializeSystem(); 
            Application.SetCompatibleTextRenderingDefault(false);
            var edit = new Edit();
           Application.Run(edit);
        }
    }
}
 