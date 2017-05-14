using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace passwordGenerator
{
    class Generator
    {
        private bool[] masFlag;

        private int size;

        private string name;
        public string getName { get { return name; } }

        private Random rnd = new Random();

        public Generator(bool[] _mas, int _size)
        {
            masFlag = _mas;
            size = _size;
        }

        public void generations()
        {            
            for (int i = 0; i < size; i++)
            {
                name += randomIndex();
            }
        }

        public string randomIndex()
        {
            int index = rnd.Next()%6;
            string nameChar = "";
            Symbols s = new Symbols();
            switch (index)
            {
                case 0://число
                    if (masFlag[0])
                        nameChar += s.number[rnd.Next(s.number.Length)];
                    else  return randomIndex();
                    break;
                case 1://буквы строчыне русские
                    if (masFlag[1] && masFlag[3])
                        nameChar += s.alphabetRuDown[rnd.Next(s.alphabetRuDown.Length)];
                    else return randomIndex();
                    break;
                case 2://буквы строчные английские
                    if (masFlag[1] && masFlag[4])
                        nameChar += s.alphabetEuDown[rnd.Next(s.alphabetEuDown.Length)];
                    else return randomIndex();
                    break;
                case 3://буквы прописные русские
                    if (masFlag[2] && masFlag[3])
                        nameChar += s.alphabetRuUp[rnd.Next(s.alphabetRuUp.Length)];
                    else return randomIndex();
                    break;
                case 4://буквы прописыне английские
                    if (masFlag[2] && masFlag[4])
                        nameChar += s.alphabetEuUp[rnd.Next(s.alphabetEuUp.Length)];
                    else return randomIndex();
                    break;
                case 5://знак
                    if (masFlag[5])
                        nameChar += s.symbol[rnd.Next(s.symbol.Length)];
                    else return randomIndex();
                    break;
            }
            return nameChar;
        }
    }
}
