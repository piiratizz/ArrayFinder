
namespace Cursovaya.Model
{
    internal class CompareMethod : IFindMethod<int>
    {
        public List<int> CheckedElements { get; }

        public CompareMethod()
        {
            CheckedElements = new List<int>();
        }

        public int Find(int[] array, int target, bool autoClearChecked = true)
        {
            if (autoClearChecked)
            {
                CheckedElements.Clear();
            }

            for (int i = 0; i < array.Length; i++)
            {
                CheckedElements.Add(i);
                if (array[i] == target)
                    return i;
            }
            return -1;
        }
    }
}
