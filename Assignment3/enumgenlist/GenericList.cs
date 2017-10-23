using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using @interface;

namespace enumgenlist
{
    public class GenericList<X> : IGenericList<X>
    {
        private X[] _internalStorage;

        private int _containerSize;
        private int _elemCount;

        public GenericList()
        {
            _internalStorage = new X[4];
            _containerSize = 4;
            _elemCount = 0;
        }

        public GenericList(int initialSize)
        {
            _internalStorage = new X[initialSize];
            _containerSize = initialSize;
            _elemCount = 0;
        }

        public void Add(X item)
        {
            if (_elemCount == _containerSize)
            {
                X[] temp = _internalStorage;
                _internalStorage = new X[_containerSize * 2];
                temp.CopyTo(_internalStorage, 0);
                _containerSize *= 2;
            }
            _internalStorage[_elemCount] = item;
            _elemCount++;
        }

        public bool Remove(X item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i].Equals(item)) return RemoveAt(i);
            }

            return false;
        }

        public bool RemoveAt(int index)
        {
            if (index >= _elemCount)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _elemCount; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            _elemCount--;

            return true;
        }

        public X GetElement(int index)
        {
            if (index < _elemCount)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(X item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i].Equals(item)) return i;
            }

            return -1;
        }

        public int Count => _elemCount;

        public void Clear()
        {
            _elemCount = 0;
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i].Equals(item)) return true;
            }

            return false;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


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

        public bool MoveNext()
        {
            position++;
            return position < _storage.Count;
        }

        public void Reset()
        {
            position = -1;
        }

        public void Dispose()
        {
        }

   }
}
