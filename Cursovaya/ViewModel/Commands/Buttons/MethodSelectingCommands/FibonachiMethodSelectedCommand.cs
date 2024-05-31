using Cursovaya.Infrastructure;
using Cursovaya.Model;
using Cursovaya.ViewModel.Commands.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya.ViewModel.Commands
{
    internal class FibonachiMethodSelectedCommand : CommandBase
    {
        private FindMethodCreator<int> _methodCreator;

        public FibonachiMethodSelectedCommand()
        {
            _methodCreator = DIContainer.GetService<FindMethodCreator<int>>();
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            _methodCreator.SetMethodCreator(() => new FibonachiMethod());
        }
    }
}
