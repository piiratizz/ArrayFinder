using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cursovaya.ViewModel.Commands.Base;

namespace Cursovaya.ViewModel.Commands
{
    internal class CloseApplicationCommand : CommandBase
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
