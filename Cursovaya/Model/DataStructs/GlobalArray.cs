using System;
using System.Windows.Media;

namespace Cursovaya.Model.DataStructs
{
    internal class GlobalArray<T>
    {
        private T[] _array;
        private Brush[] _brushes;

        public bool IsReadyToUse { get; private set; }

        public T[] Array { get =>  _array; }
        public Brush[] BrushesList { get => _brushes; }

        public T this[int i]
        {
            get => _array[i];
        }

        public bool IsEmpty()
        {
            return _array == null || _array.Length == 0;
        }


        public void CreateArray(int size)
        {
            _array = new T[size];
            _brushes = new Brush[size];
            for (int i = 0; i < size; i++) 
            {
                _brushes[i] = Brushes.Black;
            }
        }

        public void ClearColor()
        {
            for (int i = 0; i < _brushes.Length; i++)
            {
                _brushes[i] = Brushes.Black;
            }
        }

        public void SetReadyToUse(bool flag)
        {
            IsReadyToUse = flag;
        }
    }
}
