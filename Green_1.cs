using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Green_1 : Green
    {
        private (char, double)[] _output; //поле
        public (char, double)[] Output => _output; //свойство
        public Green_1(string input) : base(input) //конструктор
        {
            _output = null;
        }
        //массив русских букв
        char[] russian_letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
        
        public override void Review()
        {
            int[] counts = new int[33];//счетчик для каждой буквы
            int t = 0; //общий счетчик букв

            string lower_input = Input.ToLower();// переводим текст к нижнему регистру
            for (int i = 0; i < lower_input.Length; i++)//подсчет букв
            {
                char c = lower_input[i];
                if (char.IsLetter(c))//проверка что символ это буква
                {
                    t++;
                    for (int j = 0; j < russian_letters.Length; j++)
                    {
                        if (c == russian_letters[j])//ищем букву
                        {
                            counts[j]++;//для конк буквы
                            break;
                        }
                    }
                }
            }
            //сколько букв встр хотя бы один раз
            int result_length = 0;
            for (int i = 0; i < russian_letters.Length; i++)
            {
                if (counts[i] > 0)
                {
                    result_length++;
                }
            }

            //массив результат
            var result = new (char, double)[result_length];
            int ind_result = 0;

            for (int i = 0; i < russian_letters.Length; i++)
            {
                if (counts[i] > 0)  //если буква встр хотя бы раз
                {
                    double frequency = -1.0; // Значение по умолчанию
                    if (t > 0)
                    {
                        frequency = (double)counts[i] / t;
                    }
                    result[ind_result++] = (russian_letters[i], frequency);

                    //заполняем массив значениями
                    result[ind_result] = (russian_letters[i], frequency);
                    ind_result++;
                }
            }
            _output = result;
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return "";
            }

            string result = "";

            for (int i = 0; i < _output.Length - 1; i++)//до предпоследнего элемента
            {
                result += $"{_output[i].Item1} - {_output[i].Item2:F4}\n";
            }
            result += $"{_output[_output.Length - 1].Item1} - {_output[_output.Length - 1].Item2:F4}";//последний элемент отдельно

            return result;
        }
    }
}