using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializedCSharp_Class_07_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bill bill = new Bill(1000,1,0);
            using (FileStream fs = new FileStream("bill.xml", FileMode.OpenOrCreate)) 
            {
                XmlSerializer xseria = new XmlSerializer(typeof(Bill));
                xseria.Serialize(fs, bill);
            }
        }
    }
    public class Bill
    {
        public decimal _billOnDay;
        public int _dayCount;
        public int _penalty = 1;
        public int _dayPenaltyCount;
        decimal _paymentWithoutPenalty;
        decimal _paymentPenalty;
        decimal _commonPayment;
        public static bool FullPayment { get; set; } = true;
        public Bill() { }
        public Bill(decimal BillonDay, int DayCount,int DayPenaltyCount)
        {
            _billOnDay = BillonDay;
            _dayCount = DayCount;
            _dayPenaltyCount = DayPenaltyCount;
            _paymentWithoutPenalty = BillonDay*DayCount;
            _paymentPenalty = _paymentWithoutPenalty * _penalty;
            _commonPayment = _paymentWithoutPenalty + _paymentPenalty;
        }

    }

}
