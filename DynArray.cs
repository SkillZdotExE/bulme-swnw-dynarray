using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace HL_DynArray
{
    internal class DynArray : IHLContainer
    {
        private static float _GrowFactor = 1.5f;

        private object[] _contents = new object[16];
        private int _size = 0;
        private int _current = 0;

        private void _reallocate(int newSize)
        {
            object[] newArr = new object[newSize];
            _contents.CopyTo(newArr, 0);
            _contents = newArr;
        }

        private void _requireCapacity(int capacity)
        {
            if (_contents.Length >= capacity)
                return;
            int newCapacity = _contents.Length;

            while (newCapacity < capacity)
                newCapacity = (int)(_GrowFactor * (float)newCapacity);

            _reallocate(newCapacity);
        }

        private int _find(object aObj, IComparer aCmp)
        {
            for (int i = 0; i < _size; i++)
            {
                if (aCmp.Compare(_contents[i], aObj) == 0)
                    return i;
            }
            return -1;
        }

        private void _remove(int index)
        {
            if (index < 0 || index >= _size)
                throw new IndexOutOfRangeException();
            _size--;

            for (int i = index; i < _size; i++)
            {
                _contents[i] = _contents[i + 1];
            }

            if (_current > index)
                _current--;

            if (_current == index && _current == _size)
                _current--;

        }

        private void _insert(object obj, int index)
        {
            _size++;
            _requireCapacity(_size);

            if (_size == 1)
                _current = 0;
            else if (_current >= index)
                _current++;

            for (int i = _size - 1; i > index; i--)
            {
                _contents[i] = _contents[i - 1];
            }


            _contents[index] = obj;
        }

        public void AddHead(object aObj)
        {
            _insert(aObj, 0);
        }

        public void AddTail(object aObj)
        {
            _insert(aObj, _size);
        }

        public object At(int aPos)
        {
            if (_size <= aPos)
                throw new IndexOutOfRangeException();
            return _contents[aPos];
        }

        public int Count()
        {
            return _size;
        }

        public object Find(object aTestObject, IComparer aCmp)
        {
            int i = _find(aTestObject, aCmp);
            if (i == -1)
                return null;
            return _contents[i];
        }

        public object First()
        {
            _current = 0;
            if (_size == 0)
                return null;
            return _contents[0];
        }

        public void InsertAtPos(object aObj, int aPos)
        {
            _insert(aObj, aPos);
        }

        public void InsertSorted(object aObj, IComparer aCmp)
        {
            int i = 0;

            while (i < _size - 1 && aCmp.Compare(aObj, _contents[i]) == 1)
            {
                i++;
            }

            if (_current >= i)
                _current++;

            _insert(aObj, i);
        }

        public object Next()
        {
            _current++;
            if (_current >= _size)
                return null;
            return _contents[_current];
        }

        public void Print()
        {
            int cursorPosition = 0;
            int cursorLength = 0;
            if (_size == 0)
            {
                Console.WriteLine("Contents | ");
                Console.WriteLine("Cursor   | ");
                return;
            }

            Console.Write("Contents | ");
            for (int i = 0; i < _size; i++)
            {
                if (i != 0)
                    Console.Write(", ");
                Console.Write(_contents[i]);
                if (_current > i)
                    cursorPosition += _contents[i].ToString().Length+2;
                else if (_current == i)
                    cursorLength = _contents[i].ToString().Length;
            }

            Console.WriteLine();

            if (_current < _size)
                Console.WriteLine("Cursor   | " + new String(' ', cursorPosition) + new String('^', cursorLength));
            else
                Console.WriteLine("No Cursor");
        }

        public object Remove(object aObj)
        {
            int i = _find(aObj, Comparer.Default);

            if (i == -1)
                return null;

            _remove(i);
            return aObj;

        }

        public object RemoveAt(int aIdx)
        {
            if (aIdx < 0 || aIdx >= _size)
                throw new IndexOutOfRangeException();
            object ret = _contents[aIdx];
            _remove(aIdx);
            return ret;
        }

        public object RemoveHead()
        {
            object ret = _contents[0];
            _remove(0);
            return ret;
        }

        public object RemoveTail()
        {
            object ret = _contents[_size-1];
            _remove(_size-1);
            return ret;
        }
    }
}
