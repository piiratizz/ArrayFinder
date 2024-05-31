using Cursovaya.Infrastructure;
using Cursovaya.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Cursovaya.Model.DataStructs;

namespace Cursovaya.ViewModel
{
    internal class MainWindowVM : ViewModelBase
    {
        #region Window title
        private string _title = "ArrayFinder";

        /// <summary> Window title </summary>
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        } 
        #endregion

        #region ArraySize
        private int _arraySize = 0;

        /// <summary>
        /// Size of array
        /// </summary>
        public string ArraySize
        {
            get => _arraySize.ToString();
            set
            {
                if (int.TryParse(value, out var res))
                {
                    Set(ref _arraySize, res);
                }
            }
        }
        #endregion

        #region MinRange
        private string _min;
        /// <summary>
        /// Min range of random generation
        /// </summary>
        public string MinRange
        {
            get => _min;
            set => Set(ref _min, value);
        }
        #endregion

        #region MaxRange
        private string _max;
        /// <summary>
        /// Max range of random generation
        /// </summary>
        public string MaxRange
        {
            get => _max;
            set => Set(ref _max, value);
        }
        #endregion

        #region FoundedIndex
        private string _indexField;
        public string IndexField
        {
            get => _indexField;
            set => Set(ref _indexField, value);
        }
        #endregion

        #region TargetElements
        private string _target;
        public string TargetElements
        {
            get => _target;
            set => Set(ref _target, value);
        }
        #endregion

        #region ArrayGeneratedTextBox
        private string _array;

        public string Array
        {
            get => _array;

            set => Set(ref _array, value);
        }

        private GlobalArray<int> _globalArray;
        private ObservableCollection<TextBlock> _arrayTextBlock;
        public ObservableCollection<TextBlock> ArrayTextBlock
        {
            get { return _arrayTextBlock; }
            set => Set(ref _arrayTextBlock, value);
        }

        public void UpdateArrayTextBlock()
        {
            if (_arraySize > 100)
            {
                ArrayTextBlock[0].Text = string.Empty;
                return;
            }

            if(ArrayTextBlock[0].Text == string.Empty || _globalArray.Array.Length != _arraySize)
            {
                ArrayTextBlock[0] = CreateArrayTextBlock();
                for (int i = 0; i < _globalArray.Array.Length; i++)
                {
                    var run = new Run(_globalArray.Array[i].ToString() + ", ");
                    run.Foreground = _globalArray.BrushesList[i];
                    ArrayTextBlock[0].Inlines.Add(run);
                }
            }
            else
            {
                for (int i = 0; i < _globalArray.Array.Length; i++)
                {
                    ArrayTextBlock[0].Inlines.ElementAt(i).Foreground = _globalArray.BrushesList[i];
                }
            }
        }

        private TextBlock CreateArrayTextBlock()
        {
            return new TextBlock()
            {
                MaxHeight = 500,
                MaxWidth = 500,
                TextWrapping = TextWrapping.Wrap,
            };
        }
        #endregion

        #region GenerationProgressBar
        private int _progress;

        public int GenerationProgress
        {
            get => _progress;
            set => Set(ref _progress, value);
        }
        #endregion

        public MainWindowVM()
        {
            _array = string.Empty;
            _globalArray = DIContainer.GetService<GlobalArray<int>>();
            ArrayTextBlock = new ObservableCollection<TextBlock>();
            ArrayTextBlock.Add(CreateArrayTextBlock());
        }
    }
}