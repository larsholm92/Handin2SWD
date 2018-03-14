using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptBook.Model
{
    public class DeptBookModel
    {
        public List<Debtor> DeptorList { get; set; }

        public int Balance { get; set; }

        public int CalcBalance()
        {
            int sum = 0;
            foreach (var x in DeptorList)
            {
                sum += x.Amount;
            }

            return sum;
        }

    }
}
