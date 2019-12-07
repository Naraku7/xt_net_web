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
        protected T[] _array;
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
            //_array = ie.ToArray(); 

            _array = new T[ie.Count()];

            int Count = 0;

            foreach (T item in ie)
            {
                _array[Count] = item;
                Count++;
            }

            Length = ie.Count();
        }

        
        public T this[int index]
        {
            get
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException();

                return index >= 0 ? _array[index] : _array[Length + index];               
        }

            set
            {
                if (index > Length - 1)
                    throw new ArgumentOutOfRangeException();

                if (index >= 0) _array[index] = value;
                else _array[Length + index] = value;
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
                _tempArr = _array;
                _array = new T[value];


                //Пришлось сделать таким образом, т.к. иначе вылетало исключение либо 
                //в при Remove(), либо при изменении Capacity из вызывающего кода
                if (Length > value)
                {
                    Length = value;

                    for (int i = 0; i < Length; i++)
                    {
                        _array[i] = _tempArr[i];
                    }
                }
                else
                {
                    for (int i = 0; i < _tempArr.Length; i++)
                    {                    
                        _array[i] = _tempArr[i];
                    }
                }
            }
        }

        public int Length { get; protected set; }

        public void Add(T item)
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

        public void AddRange(IEnumerable<T> collection) 
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

        public bool Insert(int index, T item)
        {
            if (index > Length - 1) 
                throw new ArgumentOutOfRangeException("Index is out of range", "index");

            int j = 0;

            if(Length < Capacity)
            {
                _tempArr = new T[Length + 1];

                for (int i = 0; i < _tempArr.Length; i++, j++)
                {
                    if (i == index)
                    {
                        _tempArr[i] = item;
                        j--;
                    }
                    else _tempArr[i] = _array[j];
                }

                _array = _tempArr;
                Length++;
            }
            else 
            {
                _tempArr = _array; //записываем наш массив во временный и создаем новый, емкостью в 2 раза больше
                _array = new T[_tempArr.Length * 2];

                _tempArr.CopyTo(_array, 0); //записываем старые элементы
                
                _tempArr = new T[Length + 1];

                for (int i = 0; i < _tempArr.Length; i++, j++)
                {
                    if (i == index)
                    {
                        _tempArr[i] = item;
                        j--;
                    }
                    else _tempArr[i] = _array[j];
                }

                _tempArr.CopyTo(_array, 0);

                Length++; //длина массива стала больше
            }

            return true;
        }


        public object Clone()
        {
            DynamicArray<T> Temp = new DynamicArray<T>(this._array);
            Temp.Length = this.Length;
            return Temp;
        }  

        public virtual IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Length; i++)
            {
                yield return _array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            _tempArr = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                _tempArr[i] = _array[i];
            }

            return _tempArr.GetEnumerator(); 
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (item.Equals(_array[i])) return true;
            }

            return false;
        }

        public T[] ToArray()
        {
            _tempArr = new T[Length];

            for (int i = 0; i < Length; i++)
            {
                _tempArr = _array;
            }

            return _tempArr;
        }


        public bool Remove(T item) //Если у меня два или более одинаковых элемента в коллекции, удаляю первый встретившийся
        {
            int j = 0;
            int Index = 0;
            int PreviousCapacity;

            if (_array.Contains(item))
            {
                _tempArr = new T[Length];
                PreviousCapacity = Capacity; //сохраняем предыдущее Capacity

                for (int i = 0; i < _array.Length; i++)
                {            
                    if (_array[i].Equals(item))
                    {                                            
                        Index = i; //обнаружили первое вхождение и выходим из цикла
                        break;
                    }
                }

                //с помощью j, убрав элемент, сдвигаем все остальные элементы
                for (int i = 0; i < Length; i++, j++)
                {
                    if (i != Index) _tempArr[j] = _array[i]; 
                    else j--;
                }
              
                _array = _tempArr; //записываем результат в _array
                Length--;
                Capacity = PreviousCapacity;

                return true;
            }
            
            return false;
        }

      
    }
}
