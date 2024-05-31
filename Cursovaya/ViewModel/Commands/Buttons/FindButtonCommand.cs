using Cursovaya.Model;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Cursovaya.ViewModel.Commands.Base;
using Cursovaya.Infrastructure;
using System.Windows.Media;
using Cursovaya.Model.DataStructs;
using System.Text;

namespace Cursovaya.ViewModel.Commands
{
    internal class FindButtonCommand : CommandBase
    {
        private MainWindowVM _mainWindowVM;
        private GlobalArray<int> _globalArray;
        private FindMethodCreator<int> _methodCreator;

        public FindButtonCommand()
        {
            _mainWindowVM = DIContainer.GetService<MainWindowVM>();
            _globalArray = DIContainer.GetService<GlobalArray<int>>();
            _methodCreator = DIContainer.GetService<FindMethodCreator<int>>();
        }

        public override bool CanExecute(object? parameter)
        {
            return _globalArray.IsReadyToUse && _methodCreator.IsSelected;
        }

        public override void Execute(object? parameter)
        {
            _globalArray.ClearColor();
            string s = "";

            if(_mainWindowVM.TargetElements == null)
            {
                MessageBox.Show("Потрібний елемент повинен бути числом");
                return;
            }

            int[] array = s.ParseToIntArray(_mainWindowVM.TargetElements);
            var globalArray = _globalArray.Array;
            var finder = _methodCreator.Create();

            if(array.Length == 0)
            {
                MessageBox.Show("Потрібний елемент повинен бути числом");
                return;
            }

            StringBuilder sb = new StringBuilder();

            foreach(var element in array) 
            {
                var index = finder.Find(globalArray, element, false);

                if (index == -1)
                {
                    sb.AppendLine($"В масиві нема елементу {element}");
                    
                }
                else
                {
                    sb.AppendLine($"Елемент {element} : Індекс {index}");
                    _globalArray.BrushesList[index] = Brushes.LightGreen;
                } 
            }

            var checkedElements = finder.CheckedElements;

            foreach (var checkedElement in checkedElements)
            {
                if (_globalArray.BrushesList[checkedElement] != Brushes.LightGreen)
                {
                    _globalArray.BrushesList[checkedElement] = Brushes.Yellow;
                }
            }

            _mainWindowVM.IndexField = sb.ToString();
            _mainWindowVM.UpdateArrayTextBlock();
        }
    }
}