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

        public static string operator +(MyString str1, MyString str2)
        {
            return "";
        }

        public MyString(params char[] symbols)
        {
            _symbols = symbols;
        }

        public MyString(string str)
        {
            _symbols = str.ToCharArray();
        }

        public MyString() { }

        public IEnumerator GetEnumerator()
        {
            return _symbols.GetEnumerator();
        }

        public int Length => this._symbols.Length; 

        public override string ToString()
        {
            return new string(_symbols);
        }

        public char[] ToCharArray()
        {
            return _symbols;
        }

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
