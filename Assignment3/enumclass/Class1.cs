using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using enumgenlist;

namespace enumclass
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private GenericList<X> _storage;
        private int position = -1;

        public GenericListEnumerator(GenericList<X> list)
        {
            _storage = list;
        }

        public X Current
        {
            get
            {
                try
                {
                    return _storage.GetElement(position);
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            position++;
            return position < _storage.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
