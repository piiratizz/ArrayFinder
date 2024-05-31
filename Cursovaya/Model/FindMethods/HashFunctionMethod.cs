using Cursovaya.Model.DataStructs;

namespace Cursovaya.Model
{
    internal class HashFunctionMethod : IFindMethod<int>
    {
        public List<int> CheckedElements { get; }

        public HashFunctionMethod()
        {
            CheckedElements = new List<int>();
        }

        public int Find(int[] array, int target, bool autoClearChecked = true)
        {
            if (autoClearChecked)
            {
                CheckedElements.Clear();
            }

            HashTable<int, int> hashTable = new HashTable<int, int>(array.Length);

            for (int i = 0; i < array.Length; i++)
            {
                hashTable.Add(array[i], i);
            }

            if (hashTable.TryFind(target, out var index))
            {
                return index;
            }
            else return -1;
        }
    }
}
