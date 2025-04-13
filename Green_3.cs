using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_3 : Green
    {
        //поля
        private string[] _output;
        private readonly string _sequence;
        public string[] Output => _output;//свойство
        public Green_3(string input, string sequence) : base(input)//конструктор
        {
            _output = null;
            if (sequence == null)
            {
                _sequence = "";
            }
            else
            {
                _sequence = sequence.ToLower();
            }
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(_sequence))
            {
                _output = null;
                return;
            }
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
                return;
            }

            char[] marks = {
                ' ', '.', '!', '?', ',', ':', '\"', ';',
                '–', '(', ')', '[', ']', '{', '}', '/'
            };

            //разбиваем строку на слова
            string[] temp_words = Input.Split(marks, StringSplitOptions.RemoveEmptyEntries);

            int сount = 0;
            foreach (string word in temp_words)
            {
                if (word != null && word.Trim() != "")
                {
                    сount++;
                }
            }
            string[] words = new string[сount];
            int index = 0;
            foreach (string word in temp_words)
            {
                if (word != null && word.Trim().Length > 0)
                {
                    words[index] = word.Trim();
                    index++;
                }
            }
            string[] temp_results = new string[words.Length];
            int result_count = 0;

            for (int i = 0; i < words.Length; i++)//проверяем слова
            {
                string lower_word = words[i].ToLower();
                if (lower_word.Contains(_sequence))
                {
                    bool f = false;
                    for (int j = 0; j < result_count; j++)
                    {
                        if (temp_results[j].ToLower() == lower_word)
                        {
                            f = true;
                            break;
                        }
                    }
                    if (f == false)
                    {
                        temp_results[result_count] = lower_word;
                        result_count++;
                    }
                }
            }
            
            _output = new string[result_count];
            for (int i = 0; i < result_count; i++)
            {
                _output[i] = temp_results[i];
            }
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }
            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += _output[i];
                if (i < _output.Length - 1)
                {
                    result += "\n";
                }
            }
            return result;
        }
    }
}