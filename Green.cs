using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public abstract class Green
    {
        private string _input; //поле
        public string Input => _input; //свойство
        public Green(string input) //конструктор
        {
            _input = input;
        }
        public abstract void Review();
    }
}
