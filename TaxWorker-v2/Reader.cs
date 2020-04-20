using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TaxWorker_v2
{
    class Bank
    {
        public int card_no;
        public int register_no;
        public int price;
        public int name;

        public Bank(int _card_no, int _register_no, int _price, int _name)
        {
            card_no = _card_no;
            register_no = _register_no;
            price = _price;
            name = _name;
        }
    }

    class Data
    {
        public int price;
        public int count;

        public Data(int _price, int _count)
        {
            price = _price;
            count = _count;
        }
    }

    class Reader
    {
        private readonly string FILE_SAMSUNG = "ss.txt";
        private readonly string FILE_SHINHAN = "sh.txt";

        private Bank shinhan;
        private Bank samsung;

        public Dictionary<string, Dictionary<string, Data>> data_samsung = new Dictionary<string, Dictionary<string, Data>>();
        public Dictionary<string, Dictionary<string, Data>> data_shinhan = new Dictionary<string, Dictionary<string, Data>>();

        public void Init()
        {
            samsung = new Bank(4, 10, 7, 6);
            Read(FILE_SAMSUNG, samsung, data_samsung);

            shinhan = new Bank(2, 5, 7, 4);
            Read(FILE_SHINHAN, shinhan, data_shinhan);
        }

        private void Read(string _file, Bank _bank, Dictionary<string, Dictionary<string, Data>> _data)
        {
            var _path = System.IO.Directory.GetCurrentDirectory() + "\\" + _file;
            if (false == File.Exists(_path))
            {
                Console.WriteLine("File not exists..");
                return;
            }

            // 파일 읽기 (line)
            var _arr = File.ReadAllLines(_path);
            foreach (var _line in _arr)
            {
                var _values = _line.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);    // 탭을 기준으로 요소를 분리

                var _card_no = _values[_bank.card_no];                                              // 카드 번호
                var _name = _values[_bank.name];                                                    // 가맹점 이름
                var _register_no = _values[_bank.register_no];                                      // 사업자 번호
                var _price = System.Convert.ToInt32(RemoveComma(_values[_bank.price]));             // 가격
                var _identity = _register_no + " (" + _name + ")";                                  // 표시될 이름 = 사업자 번호 (가맹점 이름)

                // 카드 번호 별로 구분
                if (false == _data.ContainsKey(_card_no))
                {
                    _data[_card_no] = new Dictionary<string, Data>();
                }

                // 중복된 요소는 가격과 개수를 더함
                if (_data[_card_no].ContainsKey(_identity))
                {
                    _data[_card_no][_identity].price += _price;
                    _data[_card_no][_identity].count += 1;
                }
                else
                {
                    _data[_card_no][_identity] = new Data(_price, 1);
                }
            }
        }

        private string RemoveComma(string _str)
        {
            _str = _str.Replace(",", "");
            return _str;
        }
    }





}




