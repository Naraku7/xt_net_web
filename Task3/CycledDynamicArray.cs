using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public override IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                for (int i = 0; i < Length; i++)
                {
                    yield return _array[i];
                }
            }
        }

        public CycledDynamicArray(T[] array)
        {
            _array = array;
            Length = array.Length;
        }

        public CycledDynamicArray()
        {
            _array = new T[8];
            Length = 8;
        }
    }
}
