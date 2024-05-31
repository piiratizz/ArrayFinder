namespace Cursovaya.Model
{
    internal class Int32ArrayFiller
    {
        public event Action<int>? OnProgressChanged;
        private int _progress = 0;

        public bool TryRandomFill(int[] array, int min, int max)
        {
            _progress = 0;
            SendProgressChanged();

            if (min > max || array.Length > max - min)
                return false;

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int rand = random.Next(min, max);

                if (array.Contains(rand))
                {
                    rand = min;
                    while (array.Contains(rand))
                    {
                        rand++;
                    }
                }
                array[i] = rand;

                int delta = array.Length / 100;

                if (delta != 0)
                {
                    if (i % delta == 0)
                    {
                        _progress++;
                        SendProgressChanged();
                    }
                }
            }

            Array.Sort(array);
            return true;
        }

        private void SendProgressChanged()
        {
            OnProgressChanged?.Invoke(_progress);
        }
    }
}
