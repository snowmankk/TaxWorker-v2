using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxWorker_v2
{
    class Program
    {
        static void Main(string[] args)
        {
            var _work = new TaxWork();
        }
    }

    class TaxWork
    {
        public TaxWork()
        {
            Work();
        }

        public void Work()
        {
            Reader reader = new Reader();
            reader.Init();

            Writer writer = new Writer();
            writer.Write("삼성", reader.data_samsung);
            Console.WriteLine("\n\n");

            writer.Write("신한", reader.data_shinhan);
            Console.WriteLine("\n\n");
        }
    }
}
