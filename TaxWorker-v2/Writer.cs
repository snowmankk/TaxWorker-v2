using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxWorker_v2
{
    class Writer
    {
        public void Write(string _bank, Dictionary<string, Dictionary<string, Data>> _datas)
        {
            int _total_price = 0;
            int _total_count = 0;
            foreach (var _data in _datas)
            {
                var _card_no = _data.Key;
                foreach (var _value in _data.Value)
                {
                    var _identity = _value.Key;
                    var _price = InsertComma(_value.Value.price);
                    var _count = _value.Value.count;

                    var _line = string.Empty;
                    _line += "[" + _card_no + "] " + _identity + " : " + _price + "(" + _count + ")\n";
                    Console.WriteLine(_line);

                    _total_price += _value.Value.price;
                    _total_count += _value.Value.count;
                }

                Console.WriteLine("\n");
            }

            Console.WriteLine("▶▶▶ 합계" + "(" + _bank + ") : " + InsertComma(_total_price) + "(" + _total_count + ") ◀◀◀\n\n\n\n");
        }

        private string InsertComma(int _value)
        {
            string _str = _value.ToString();
            int _comma = (int)(_str.Length % 3);
            int _index = 0;
            for (var _i = 0; _i < _str.Length; ++_i)
            {
                if (0 == _comma)
                {
                    _str = _str.Insert(_index, ",");
                    _comma = 4;
                }

                ++_index;
                --_comma;
            }

            return _str;
        }
    }
}
