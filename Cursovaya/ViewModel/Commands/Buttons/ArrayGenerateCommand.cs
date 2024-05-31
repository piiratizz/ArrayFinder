using Cursovaya.Infrastructure;
using Cursovaya.Model;
using Cursovaya.Model.DataStructs;
using Cursovaya.ViewModel;
using Cursovaya.ViewModel.Commands.Base;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Cursovaya.ViewModel.Commands
{
    internal class ArrayGenerateCommand : CommandBase
    {
        private MainWindowVM _mainWindowVM;
        private GlobalArray<int> _array;
        private Task _logicHandling = Task.CompletedTask;

        public ArrayGenerateCommand()
        {
            _array = DIContainer.GetService<GlobalArray<int>>();
            _mainWindowVM = DIContainer.GetService<MainWindowVM>();
        }

        public override bool CanExecute(object? parameter)
        {
            return _logicHandling.IsCompleted;
        }

        public override void Execute(object? parameter)
        {
            _mainWindowVM.IndexField = "";
            ExecuteAsync();
        }

        private async void ExecuteAsync()
        {
            int size = int.Parse(_mainWindowVM.ArraySize);
            
            if(size <= 1)
            {
                MessageBox.Show($"Розмір масиву повинен бути більше за 1", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _array.SetReadyToUse(false);

            if (!int.TryParse(_mainWindowVM.MinRange, out var min))
            {
                MessageBox.Show($"Мінімальний елемент повинен бути цілим числом та бути більше за {int.MinValue}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(_mainWindowVM.MaxRange, out var max))
            {
                MessageBox.Show($"Максимальний елемент повинен бути цілим числом та бути менше за {int.MaxValue}", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(min > max)
            {
                MessageBox.Show("Мінімальний елемент повинен бути меншим за максимальний", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (size <= 0)
            {
                MessageBox.Show("Розмір масиву повинен бути більше за 0", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (max - min < int.Parse(_mainWindowVM.ArraySize))
            {
                MessageBox.Show("Діапазон генерації повинен бути більше за розмір масиву", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            
            var filler = new Int32ArrayFiller();

            filler.OnProgressChanged += (int progress) =>
            {
                _mainWindowVM.GenerationProgress = progress;
            };

            var task = Task.Run(() => 
            { 
                _array.CreateArray(size);
                filler.TryRandomFill(_array.Array, min, max); 
            });

            _logicHandling = task;
            await _logicHandling;
            _array.SetReadyToUse(true);
            _mainWindowVM.UpdateArrayTextBlock();
            
        }
    }
}
