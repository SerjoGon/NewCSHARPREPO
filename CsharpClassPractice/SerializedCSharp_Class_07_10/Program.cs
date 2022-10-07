﻿using System;
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
            //PartBill partBill = (PartBill)Bill(1000,1,1,0);
            PartBill partBill = new PartBill(bill._billOnDay, bill._dayCount, bill._penalty, bill._dayPenaltyCount);
            Bill.FullPayment = true;
            using (FileStream fs = new FileStream("bill.xml", FileMode.Create)) { } 
            using (FileStream fs = new FileStream("bill.xml", FileMode.Truncate)) 
            {
                if (Bill.FullPayment)
                {
                    XmlSerializer xseria = new XmlSerializer(typeof(Bill));
                    xseria.Serialize(fs, bill);
                    bill.Display();

                }
                else
                {
                    XmlSerializer xseria = new XmlSerializer(typeof(PartBill));
                    xseria.Serialize(fs, partBill);
                    partBill.Display();


                }
            }
            using (FileStream fs = new FileStream("bill.xml", FileMode.Open))
            {
                if (Bill.FullPayment)
                {
                    XmlSerializer xseria = new XmlSerializer(typeof(Bill));
                    bill = xseria.Deserialize(fs) as Bill;
                    bill.Display();

                }
                else
                {
                    XmlSerializer xseria = new XmlSerializer(typeof(PartBill));
                   partBill = xseria.Deserialize(fs) as PartBill;
                    partBill.Display();


                }
            }
          
        }
    }
    public class PartBill
    {
        public decimal _billOnDay;
        public int _dayCount;
        public int _penalty = 1;
        public int _dayPenaltyCount;


        public PartBill() { }
        public PartBill(decimal BillOnDay, int DayCount,int Penalty, int DayPenaltyCount)
        {
            _billOnDay = BillOnDay;
            _dayCount = DayCount;
            _penalty = Penalty;
            _dayPenaltyCount = DayPenaltyCount;
        }
        public void Display()
        {
            Console.WriteLine($"Обьект: {_billOnDay} {_dayCount} {_penalty} {_dayPenaltyCount } ");
        }
    }
    public class Bill
    {
        public decimal _billOnDay;
        public int _dayCount;
        public int _penalty = 1;
        public int _dayPenaltyCount;
        public decimal _paymentWithoutPenalty;
        public decimal _paymentPenalty;
        public decimal _commonPayment;
        public static bool FullPayment { get; set; } = true;
        public Bill() { }
        public Bill(decimal BillonDay, int DayCount,int DayPenaltyCount)
        {
            _billOnDay = BillonDay;
            _dayCount = DayCount;
            _dayPenaltyCount = DayPenaltyCount;
            _paymentWithoutPenalty = BillonDay*DayCount;
            _paymentPenalty = _paymentWithoutPenalty * _penalty/100;
            _commonPayment = _paymentWithoutPenalty + _paymentPenalty;
        }
        public void Display()
        {
            Console.WriteLine($"Обьект: {_billOnDay} {_dayCount} {_penalty} {_dayPenaltyCount } {_paymentWithoutPenalty} {_paymentPenalty} {_commonPayment} ");
        } 

    }

}
