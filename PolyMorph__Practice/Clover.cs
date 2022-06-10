using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorph__Practice
{
    internal class Clover : IPaymentProcessor
    {
        public string PaymentType { get; }

        public bool HasBeenInitialized { get; private set; }

        public decimal PaymentAmount { get; }

        public DateTime ProcessTime { get; private set; }

        public Clover(decimal paymentAmount)
        {
            PaymentAmount = paymentAmount;
            PaymentType = "Clover";
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
            if (!HasBeenInitialized)
                
                Console.WriteLine($"Payment is {PaymentAmount} with no process fee!");
                Console.WriteLine($"Your payment has been processed at {ProcessTime}");
                EmailReceptToCustomer();
        }

        public void EmailReceptToCustomer()
        {
            Console.WriteLine("A receipt has been emailed to the customer");
        }
    }
}
