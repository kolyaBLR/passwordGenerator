using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace passwordGenerator
{
    class ImageCheck
    {
        public bool checkSize(string size)
        {
            if (size.Length >= 8)
                return true;
            else
                return false;
        }

        public bool alphabetUp(string size)
        {
            Symbols s = new Symbols();
            for (int i = 0; i < size.Length; i++)
            {
                for (int j = 0; j < s.alphabetEuUp.Length; j++)
                    if (size[i] == s.alphabetEuUp[j])
                        return true;
                for (int j = 0; j < s.alphabetRuUp.Length; j++)
                    if (size[i] == s.alphabetRuUp[j])
                        return true;
            }
            return false;
        }

        public bool alphabetDown(string size)
        {
            Symbols s = new Symbols();
            for (int i = 0; i < size.Length; i++)
            {
                for (int j = 0; j < s.alphabetEuDown.Length; j++)
                    if (size[i] == s.alphabetEuDown[j])
                        return true;
                for (int j = 0; j < s.alphabetRuDown.Length; j++)
                    if (size[i] == s.alphabetRuDown[j])
                        return true;
            }
            return false;
        }

        public bool number(string size)
        {
            Symbols s = new Symbols();
            for (int i = 0; i < size.Length; i++)
            {
                for (int j = 0; j < s.number.Length; j++)
                    if (size[i] == s.number[j])
                        return true;
            }
            return false;
        }
    }
}
