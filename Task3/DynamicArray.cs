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
        private T[] _tempArr;     

        public DynamicArray()
        {
            _array = new T[8];
            Length = 8;
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

        public int Length { get; private set; } //длина массива, который подан на вход 

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
                _tempArr = collection.ToArray<T>(); //не знаю, можно ли использовать этот метод. Если нет, то нужно как-то еще скопировать 

                //_tempArr = new T[collection.Count()]; //нужно ли?

                //int Count = 0;

                //foreach (T item in collection)
                //{
                //    _tempArr[Count] = item;
                //    Count++;    
                //}

                _tempArr.CopyTo(_array, Length);
                
                Length += collection.Count(); //длина массива стала больше
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

                _tempArr = collection.ToArray<T>(); //не знаю, можно ли использовать этот метод. Если нет, то нужно как-то еще скопировать

                _tempArr.CopyTo(_array, Length); //выход за границы массива

                Length += collection.Count(); //длина массива стала больше
            }

        }

      

        public object Clone()
        {
            throw new NotImplementedException();
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

        public bool Remove(T item) //Если у меня два или более одинаковых элемента в коллекции, метод Remove должен удалить их все или только первый нашедшийся?
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
