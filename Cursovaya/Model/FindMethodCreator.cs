using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursovaya.Model
{
    internal class FindMethodCreator<T> where T : IComparable
    {
        private Func<IFindMethod<T>> _creatorMethod;

        public bool IsSelected => _creatorMethod != null;

        public void SetMethodCreator(Func<IFindMethod<T>> func)
        {
            _creatorMethod = func;
        }

        public IFindMethod<T> Create()
        {
            if (_creatorMethod == null)
                throw new NullReferenceException(nameof(_creatorMethod) + " Must not be null");

            return _creatorMethod();
        }
    }
}
