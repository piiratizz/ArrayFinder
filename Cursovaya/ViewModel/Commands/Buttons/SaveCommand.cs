using Cursovaya.Infrastructure;
using Cursovaya.Model;
using Cursovaya.ViewModel.Commands.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Cursovaya.Model.DataStructs;

namespace Cursovaya.ViewModel.Commands
{
    internal class SaveCommand : CommandBase
    {
        private GlobalArray<int> _globalArray;
        private MainWindowVM _mainWindowVM;

        public SaveCommand()
        {
            _globalArray = DIContainer.GetService<GlobalArray<int>>();
            _mainWindowVM = DIContainer.GetService<MainWindowVM>();
        }

        public override bool CanExecute(object? parameter)
        {
            return _globalArray.Array != null && _globalArray.IsReadyToUse;
        }

        public override void Execute(object? parameter)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "output";
            saveFileDialog.Filter = "Text Files | *.txt";

            StringBuilder sb = new StringBuilder();
            sb.Append("Масив:  ");
            for (int i = 0; i < _globalArray.Array.Length; i++)
            {
                sb.Append(_globalArray[i].ToString());

                if(i != _globalArray.Array.Length - 1)
                {
                    sb.Append(", ");
                }
                else
                {
                    sb.AppendLine();
                }
            }

            string s = string.Empty;
            sb.AppendLine($"Потрібний елемент: {string.Join(" ", s.ParseToIntArray(_mainWindowVM.TargetElements))}");
            sb.AppendLine($"Індекс: {_mainWindowVM.IndexField}");


            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, sb.ToString());

        }
    }
}
