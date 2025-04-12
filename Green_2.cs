using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_2 : Green
    {
        private char[] _output;//поле
        public char[] Output => _output;//свойство
        public Green_2(string input) : base(input)//конструктор
        {
            _output = null;
        }

        public override void Review()
        {
            if (Input == null || Input.Length == 0)
            {
                _output = null;
                return;
            }

            char[] marks = {
                ' ', '.', '!', '?', ',', ':', '\"', ';',
                '–', '(', ')', '[', ']', '{', '}', '/'
            };
            string[] temp_words = Input.Split(marks);

            //кол-во непустых слов
            int count = 0;
            foreach (string word in temp_words)
            {
                if (word != "")
                {
                    count++;
                }
            }

            //заполняем массив непустыми строками
            string[] words = new string[count];
            int index = 0;
            foreach (string word in temp_words)
            {
                if (word != "")
                {
                    words[index++] = word;
                }
            }
            if (words.Length == 0)
            {
                _output = new char[0];
                return;
            }

            char[] letters = new char[words.Length];//хранит первые буквы
            int[] counts = new int[words.Length];
            int t_special = 0; //счетчик уникальных букв

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char first_letter = char.ToLower(word[0]);//нижний регистр

                //проверяем что это буква не включая цифры и знаки
                if (first_letter < 'A' || (first_letter > 'Z' && first_letter < 'a') || first_letter > 'z')
                {
                    continue;
                }

                bool f = false;
                for (int i = 0; i < t_special; i++)
                {
                    if (letters[i] == first_letter)
                    {
                        counts[i]++;
                        f = true;
                        break;
                    }
                }

                if (f == false)//добавляем новую букву
                {
                    letters[t_special] = first_letter;
                    counts[t_special] = 1;
                    t_special++;
                }
            }

            // Сортируем по убыванию и алфавиту
            for (int i = 0; i < t_special - 1; i++)
            {
                for (int j = 0; j < t_special - i - 1; j++)
                {
                    if (counts[j] < counts[j + 1])
                    {
                        int temp_count = counts[j];
                        counts[j] = counts[j + 1];
                        counts[j + 1] = temp_count;

                        char temp_letter = letters[j];
                        letters[j] = letters[j + 1];
                        letters[j + 1] = temp_letter;
                    }
                    else if ((counts[j] == counts[j + 1]) && (letters[j] > letters[j + 1]))
                    {
                        char temp_letter = letters[j];
                        letters[j] = letters[j + 1];
                        letters[j + 1] = temp_letter;
                    }
                }
            }
            //итоговый массив
            _output = new char[t_special];
            for (int i = 0; i < t_special; i++)
            {
                _output[i] = letters[i];
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
                result += _output[i].ToString();
                if (i < _output.Length - 1)
                {
                    result += ", ";
                }
            }
            return result;
        }
    }
}