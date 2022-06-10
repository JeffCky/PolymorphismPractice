using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorph__Practice
{
    internal class Square : IPaymentProcessor
    {
        public string PaymentType { get; }

        public bool HasBeenInitialized { get; private set; }

        public decimal PaymentAmount { get; }

        public DateTime ProcessTime { get; private set; }

        public Square(decimal paymentAmount)
        {
            PaymentAmount = paymentAmount;
            PaymentType = "Square";
            HasBeenInitialized = false;
            ProcessTime = DateTime.Now;
        }



        public void Initialize()
        {
            this.HasBeenInitialized = true;
            Console.WriteLine($"This payment processor is {PaymentType} and it is now initialized");
        }

        public void ProcessPayment()
        {
            decimal processFeeRate = .003m;
            if (!HasBeenInitialized)
                
                Console.WriteLine($"Payment is {PaymentAmount} with a process fee of: {PaymentAmount * processFeeRate}");
                Console.WriteLine($"Your payment has been processed at {ProcessTime}");
                EmailReceptToCustomer();
        }

        public void EmailReceptToCustomer()
        {
            Console.WriteLine("A receipt has been emailed to the customer");
        }
    }
}
