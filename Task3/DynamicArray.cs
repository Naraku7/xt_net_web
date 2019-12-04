using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArray<T> : IEnumerable<T>, ICloneable//, ICollection<T>, IList<T>
    {
        private T[] _array;

        public DynamicArray()
        {
            _array = new T[8];
        }

        public DynamicArray(T[] array)
        {
            _array = array;
        }

        public DynamicArray(IEnumerable<T> ie)
        {
            _array = ie.ToArray();
        }

        //В задании сказано выбросить ArgumentOutOfRangeException, поэтому пришлось сделать через try-catch
        public T this[int index] //{ get => _array[index]; set => _array[index] = value; } 
        {
            get
            {
                try { return _array[index]; }

                catch(IndexOutOfRangeException ex)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }

            set
            {
                try { _array[index] = value; }

                catch (IndexOutOfRangeException ex)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int Capacity => throw new NotImplementedException();

        public int Length => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<T> collection)
        {

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
