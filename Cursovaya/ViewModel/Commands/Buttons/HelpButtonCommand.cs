using Cursovaya.Infrastructure;
using Cursovaya.ViewModel.Commands.Base;
using Cursovaya.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya.ViewModel.Commands
{
    internal class HelpButtonCommand : CommandBase
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var service = DIContainer.GetService<HelpWindowService>();
            service.OpenWindow();
        }
    }
}
