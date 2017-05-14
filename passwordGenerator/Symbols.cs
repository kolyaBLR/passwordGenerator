using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    class Symbols
    {
        private string _number = "0123456789";
        private string _alphabetRuUp = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        private string _alphabetRuDown = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private string _alphabetEuUp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string _alphabetEuDown = "abcdefghijklmnopqrstuvwxyz";
        private string _symbol = "%*)?@#$~_";

        public string number { get { return _number; } }
        public string alphabetRuUp { get { return _alphabetRuUp; } }
        public string alphabetRuDown { get { return _alphabetRuDown; } }
        public string alphabetEuUp { get { return _alphabetEuUp; } }
        public string alphabetEuDown { get { return _alphabetEuDown; } }
        public string symbol { get { return _symbol; } }
    }
}
