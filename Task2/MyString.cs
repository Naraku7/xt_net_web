using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class MyString : IEnumerable
    {
        private char[] _symbols;

        public char this[int id]
        {
            get => _symbols[id];
            set => _symbols[id] = value;
        }

        public static MyString operator +(MyString str1, MyString str2)
        {         
            return new MyString(str1.ToString() + str2.ToString());
        }

        public MyString(params char[] symbols) => _symbols = symbols;


        public MyString(string str) => _symbols = str.ToCharArray();


        public MyString() { }

        public IEnumerator GetEnumerator() => _symbols.GetEnumerator();
        

        public int Length => this._symbols.Length; 

        public override string ToString() => new string(_symbols);
       

        public int IndexOf(char c)
        {
            for (int i = 0; i < this.Length; i++)
            {
                if (this._symbols[i] == c) return i;
            }

            return -1;
        }

        public char[] ToCharArray() => _symbols;


        public override bool Equals(object obj)
        {
            MyString MyStr = obj as MyString;

            if (MyStr == null) return false; //если объект не типа MyString, выдаем False
            if (base.Equals(obj)) return true; //если объекты лежат в heap по одной ссылке, выдаем True
            
            //если слова разной длины, выдаем Fasle
            if (this.Length != MyStr.Length) return false;

            for (int i = 0; i < _symbols.Length; i++)
            {
                if (_symbols[i] != MyStr[i]) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

    }
}
