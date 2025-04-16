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
            if (_sequence == null || _sequence == "")
            {
                _output = null;
                return;
            }
            if (Input == null || Input.Length == 0)
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
            int count = 0;
            for (int i = 0; i < temp_words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(temp_words[i]))
                {
                    count++;
                }
            }
            string[] words = new string[count];
            int index = 0;
            for (int i = 0; i < temp_words.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(temp_words[i]))
                {
                    words[index++] = temp_words[i].Trim();
                }
            }
            string[] temp_results = new string[words.Length];
            int result_count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string lower_word = words[i].ToLower();
                if (!string.IsNullOrEmpty(_sequence) && lower_word.Contains(_sequence))
                {
                    bool isUnique = true;
                    for (int j = 0; j < result_count; j++)
                    {
                        if (temp_results[j] == lower_word)
                        {
                            isUnique = false;
                            break;
                        }
                    }
                    if (isUnique)
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
            for (int i = 0; i < _output.Length; ++i)
            {
                result += $"{_output[i]}";
                if (i + 1 < _output.Length)
                {
                    result += Environment.NewLine;
                }
            }
            return result;
        }
    }
}