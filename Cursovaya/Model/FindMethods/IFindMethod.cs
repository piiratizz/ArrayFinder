namespace Cursovaya.Model
{
    internal interface IFindMethod<T> where T : IComparable
    {
        List<T> CheckedElements { get; }

        T Find(T[] array, T target, bool autoClearChecked = true);
    }
}
