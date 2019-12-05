using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class DynamicArray<T> : IEnumerable, IEnumerable<T>, ICloneable//, ICollection<T>, IList<T>
    {
        private T[] _array;
        private T[] _tempArr;     

        public DynamicArray()
        {
            _array = new T[8];
            Length = 8;
        }

        public DynamicArray(int n)
        {
            _array = new T[n];
            Length = n;
        }

        public DynamicArray(T[] array)
        {
            _array = array;
            Length = array.Length;           
        }

        public DynamicArray(IEnumerable<T> ie)
        {
            _array = ie.ToArray(); //исправить, как ниже, если нельзя
            Length = ie.Count();
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

        public int Capacity
        {
            get
            {                
                return _array.Length;
            }

            set
            {               
                _array = new T[value];
            }
        }

        public int Length { get; private set; }

        public void Add(T item) //в этом методе добавь увеличение Length и мб Capacity
        {
           if (Length < Capacity)
            {
                _array[Length] = item;
                Length++; //длина массива стала больше
            }
            else
            {
                _tempArr = _array; //записываем наш массив во временный и создаем новый, емкостью в 2 раза больше
                _array = new T[_tempArr.Length * 2];

                _tempArr.CopyTo(_array, 0); //записываем старые элементы
                _array[Length] = item; //записываем новый элемент.
                Length++; //длина массива стала больше
                
            }
        }

        public void AddRange(IEnumerable<T> collection) //в этом методе добавь увеличение Length и мб Capacity
        {
            if (Length + collection.Count() <= Capacity)
            {
                //_tempArr = collection.ToArray<T>();  

                //Вместо collection.ToArray<T>() делаем через foreach
                _tempArr = new T[collection.Count()];

                int Count = 0;

                foreach (T item in collection)
                {
                    _tempArr[Count] = item;
                    Count++;
                }

                _tempArr.CopyTo(_array, Length); //вставляем новые элементы
                
                Length += collection.Count(); 
            }
            else
            {
                _tempArr = _array; //записываем наш массив во временный и создаем новый, емкостью в 2 раза больше

                int Doubler = 2;

                while(Length + collection.Count() > Capacity) //увеличиваем в два раза до тех пор, пока емкость не будет достаточной
                {
                    _array = new T[_tempArr.Length * Doubler];
                    Doubler += 2;
                }

                _tempArr.CopyTo(_array, 0); //записываем старые элементы

                //_tempArr = collection.ToArray<T>(); 

                //Вместо collection.ToArray<T>() делаем через foreach
                _tempArr = new T[collection.Count()]; 

                int Count = 0;

                foreach (T item in collection)
                {
                    _tempArr[Count] = item;
                    Count++;
                }

                _tempArr.CopyTo(_array, Length); //вставляем новые элементы

                Length += collection.Count();
            }

        }

        //сделать
        public bool Insert(int index, T item)
        {
            return true;
        }


        public object Clone()
        {
            DynamicArray<T> Temp = new DynamicArray<T>(this._array);
            Temp.Length = this.Length;
            return Temp;
        }  

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (item.Equals(_array[i])) return true;
            }

            return false;
        }

        //сделать
        public T[] ToArray()
        {
            return new T[1];
        }

        //доделать
        public bool Remove(T item) //Если у меня два или более одинаковых элемента в коллекции, удаляю первый встретившийся
        {
            if (_array.Contains(item))
            {

            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
