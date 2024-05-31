namespace Cursovaya.Model
{
    internal class InterpolationMethod : IFindMethod<int>
    {
        public List<int> CheckedElements { get; }

        public InterpolationMethod()
        {
            CheckedElements = new List<int>();
        }

        public int Find(int[] array, int target, bool autoClearChecked = true)
        {
            if (autoClearChecked)
            {
                CheckedElements.Clear();
            }

            int low = 0, high = array.Length - 1;
            CheckedElements.Add(low);
            CheckedElements.Add(high);
            while (low <= high && target >= array[low] && target <= array[high])
            {
                if (low == high)
                {
                    if (array[low] == target)
                        return low;
                    return -1;
                }

                int pos = low + ((target - array[low]) * (high - low) / (array[high] - array[low]));
                CheckedElements.Add(pos);

                if (array[pos] == target)
                    return pos;

                if (array[pos] < target)
                {
                    low = pos + 1;
                    CheckedElements.Add(low);
                }
                else
                {
                    high = pos - 1;
                    CheckedElements.Add(high);
                }

            }
            return -1;
        }
    }
}
