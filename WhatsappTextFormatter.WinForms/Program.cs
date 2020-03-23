using Ninject;
using System;
using System.Windows.Forms;
using WhatsappTextFormatter.Business;

namespace WhatsappTextFormatter.WinForms
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

            IKernel kernel = new StandardKernel(new DefaultBusinessModule());
            var mainView = kernel.Get<TesterInterface>();

            Application.Run(mainView);
        }
    }
}
