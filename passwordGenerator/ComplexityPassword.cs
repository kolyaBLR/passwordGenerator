using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace passwordGenerator
{
    class ComplexityPassword
    {
        public ComplexityPassword()
        {

        }

        public int CheckedPassword(string name)
        {
            bool check = false;
            int complexity = 0;
            if (Regex.IsMatch(name, @"[А-ЯЁ]") || (Regex.IsMatch(name, @"[A-Z]")))
                complexity += 5;
            if (Regex.IsMatch(name, @"[a-z]") || (Regex.IsMatch(name, @"[а-яё]")))
                complexity += 5;
            if (Regex.IsMatch(name, @"[0-9]"))
                complexity += 5;
            if (name.Length >= 8)
                complexity += 10;
            if (name.Length >= 10)
                complexity += 15;
            Symbols s = new Symbols();
            for (int i = 0; i < name.Length - 1; i++)
            {
                if (Regex.IsMatch(name[i].ToString(), @"[А-ЯЁ]") && !Regex.IsMatch(name[i + 1].ToString(), @"[А-ЯЁ]"))
                    complexity += 5;
                if (Regex.IsMatch(name[i].ToString(), @"[A-Z]") && !Regex.IsMatch(name[i + 1].ToString(), @"[A-Z]"))
                    complexity += 5;
                if (Regex.IsMatch(name[i].ToString(), @"[a-z]") && !Regex.IsMatch(name[i + 1].ToString(), @"[a-z]"))
                    complexity += 5;
                if (Regex.IsMatch(name[i].ToString(), @"[а-яё]") && !Regex.IsMatch(name[i + 1].ToString(), @"[а-яё]"))
                    complexity += 5;
                if (Regex.IsMatch(name[i].ToString(), @"[0-9]") && !Regex.IsMatch(name[i + 1].ToString(), @"[0-9]"))
                    complexity += 5;
                if (!check)
                    for (int j = 0; j < s.symbol.Length; j++)
                    {
                        if (name[i] == s.symbol[j])
                        {
                            check = true;
                            complexity += 10;
                        }
                    }
            }
            return complexity;
        }

        public string status(int complexity)
        {
            string status = "";
            if (complexity == 0)
                status = "";
            if (complexity > 0 && complexity <= 25)
                status = "крайне слабый";
            if (complexity >= 26 && complexity <= 50)
                status = "не надёжный";
            if (complexity >= 26 && complexity <= 50)
                status = "нормальный";
            if (complexity >= 51 && complexity <= 75)
                status = "надёжный";
            if (complexity >= 76)
                status = "очень надёжный";
            return status;
        }
    }
}
