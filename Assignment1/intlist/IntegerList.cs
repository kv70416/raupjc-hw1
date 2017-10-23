using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using @interface;

namespace intlist
{
    public class IntegerList : IIntegerList
    {
        private int[] _internalStorage;

        private int _containerSize;
        private int _elemCount;

        public IntegerList()
        {
            _internalStorage = new int[4];
            _containerSize = 4;
            _elemCount = 0;
        }

        public IntegerList(int initialSize)
        {
            _internalStorage = new int[initialSize];
            _containerSize = initialSize;
            _elemCount = 0;
        }

        public void Add(int item)
        {
            if (_elemCount == _containerSize)
            {
                int[] temp = _internalStorage;
                _internalStorage = new int[_containerSize * 2];
                temp.CopyTo(_internalStorage, 0);
                _containerSize *= 2;
            }
            _internalStorage[_elemCount] = item;
            _elemCount++;
        }

        public bool Remove(int item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i] == item) return RemoveAt(i);
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

        public int GetElement(int index)
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

        public int IndexOf(int item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i] == item) return i;
            }

            return -1;
        }

        public int Count => _elemCount;

        public void Clear()
        {
            _elemCount = 0;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _elemCount; i++)
            {
                if (_internalStorage[i] == item) return true;
            }

            return false;
        }
    }

}
