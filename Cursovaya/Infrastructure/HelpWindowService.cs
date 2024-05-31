using Cursovaya.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cursovaya.Infrastructure
{
    internal class HelpWindowService : IWindowService
    {
        public Window window { get; set; }

        public void OpenWindow()
        {
            if (window != null)
            {
                if (window.IsEnabled)
                {
                    window.Close();
                }
            }

            window = new HelpWindow();
            window.Show();
        }
    }
}
