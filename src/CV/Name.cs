using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.CV
{
    internal class Name
    {
        private string _first;
        private string _last;
        private string? _middle;
        private string? _title;

        public Name(string first, string? middle, string last, string? title)
        {
            _first = first;
            _middle = middle;
            _last = last;
            _title = title;

            if (middle == "")
                _middle = null;
            if (title == "")
                _title = null;
        }

        public Name(string FullName)
        {
            string[] names = FullName.Split(' ');
            if (names.Length == 4)
            {
                _title = names[0];
                _first = names[1];
                _middle = names[2];
                _last = names[3];
            }
            else if (names.Length == 3)
            {
                _first = names[0];
                _middle = names[1];
                _last = names[2];
            }
            else if (names.Length == 2)
            {
                _first = names[0];
                _last = names[1];
            }
            else
            {
                throw new ArgumentException("Invalid name, name must be in the format of 'Title First Middle Last' or 'First Middle Last' or 'First Last'");
            }
        }

        public string Full()
        {
            if (_middle == null || _title == null)
                return FirstLast();
            else
                return _title + " " + _first + " " + _middle + " " + _last;
        }

        public string FullShorten()
        {
            if (_middle == null)
                return FirstLast();
            else
                return _first + " " + _middle.Substring(0, 1) + ". " + _last;
        }

        public string FirstLast()
        {
            return _first + " " + _last;
        }

        public string LastFirst()
        {
            return _last + ", " + _first;
        }

        public string First
        {
            get { return _first; }
            set { _first = value; }
        }

        public string Last
        {
            get { return _last; }
            set { _last = value; }
        }

        public string Middle
        {
            get { return _middle ?? throw new Exception("Middle name is not stored"); }
            set { _middle = value; }
        }

        public string Title
        {
            get { return _title ?? throw new Exception("Title is not stored"); }
            set { _title = value; }
        }

    }
}
