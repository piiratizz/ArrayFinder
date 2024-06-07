namespace Cursovaya.Model
{
    internal class FibonachiMethod : IFindMethod<int>
    {
        public List<int> CheckedElements { get; }

        public FibonachiMethod()
        {
            CheckedElements = new List<int>();
        }

        public int Find(int[] array, int target, bool autoClearChecked = true)
        {
            if(autoClearChecked)
            {
                CheckedElements.Clear();
            }
            
            int n = array.Length;
            int fibMinus2 = 0;
            int fibMinus1 = 1;
            int fibNumber = fibMinus1 + fibMinus2;
            //CheckedElements.Add(fibMinus2);
            //CheckedElements.Add(fibMinus1);

            while (fibNumber < n)
            {
                fibMinus2 = fibMinus1;
                fibMinus1 = fibNumber;
                fibNumber = fibMinus1 + fibMinus2;
                //CheckedElements.Add(fibMinus2);
                //CheckedElements.Add(fibMinus1);
            }

            int offset = -1;

            while (fibNumber > 1)
            {
                int i = Math.Min(offset + fibMinus2, n - 1);
                CheckedElements.Add(i);
                if (array[i] < target)
                {
                    fibNumber = fibMinus1;
                    fibMinus1 = fibMinus2;
                    fibMinus2 = fibNumber - fibMinus1;
                    offset = i;
                    //CheckedElements.Add(fibMinus2);
                    //CheckedElements.Add(fibMinus1);
                    //CheckedElements.Add(offset);
                }
                else if (array[i] > target)
                {
                    fibNumber = fibMinus2;
                    fibMinus1 = fibMinus1 - fibMinus2;
                    fibMinus2 = fibNumber - fibMinus1;
                    //CheckedElements.Add(fibMinus2);
                    //CheckedElements.Add(fibMinus1);
                }
                else
                {
                    return i;
                }
            }

            if (fibMinus1 == 1 && offset < n - 1 && array[offset + 1] == target)
            {
                return offset + 1;
            }

            return -1;
        }
    }
}
