using System;

namespace Lab_8
{
    public class Green_4 : Green
    {
        private string[] _output;
        public string[] Output => _output;

        public Green_4(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input == "")
            {
                _output = null;
                return;
            }

            string[] temp_words = Input.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            int count = 0;
            foreach (string word in temp_words)
            {
                if (word != null && word.Trim().Length > 0)
                {
                    count++;
                }
            }

            string[] surnames = new string[count];
            int index = 0;
            foreach (string word in temp_words)
            {
                if (word != null && word.Trim().Length > 0)
                {
                    surnames[index++] = word.Trim();
                }
            }
            if (surnames.Length == 0)
            {
                _output = new string[0];
                return;
            }

            int t_special = 0;
            string[] special_surnames = new string[surnames.Length];

            for (int i = 0; i < surnames.Length; i++)
            {
                bool f = false;
                string c = surnames[i];
                for (int j = 0; j < t_special; j++)
                {
                    if (c.ToLower() == special_surnames[j].ToLower())
                    {
                        f = true;
                        break;
                    }
                }
                if (f == false)
                {
                    special_surnames[t_special++] = c;
                }
            }

            string[] result = new string[t_special];
            for (int i = 0; i < t_special; i++)
            {
                result[i] = special_surnames[i];
            }

            for (int i = 0; i < result.Length - 1; i++)
            {
                for (int j = 0; j < result.Length - 1 - i; j++)
                {
                    if (result[j].ToLower() == result[j + 1].ToLower())
                    {
                        string temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }
            _output = result;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return "";

            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += _output[i];
                if (i < _output.Length - 1)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }
    }
}