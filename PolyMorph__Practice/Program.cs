using System;

namespace PolyMorph__Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isADecimal;
            bool finished = false; 
            
            Console.WriteLine("Please enter an amount for the transaction, i.e. 23.45- no dollar sign and two decimal places only.");
            Console.WriteLine("Amounts less than or equal to $100 will be processed with Ingenic.");
            Console.WriteLine("Amounts more than $200 and less than or equal to $500 will be processed with Clover.");
            Console.WriteLine("Amounts more than and equal to $501 will be processed with Square.");
            
            
            do
            {
                isADecimal = decimal.TryParse(Console.ReadLine(), out decimal result);
                while (!isADecimal)
                {
                    Console.WriteLine("Your entry was not a decimal, try again.");
                    isADecimal = decimal.TryParse(Console.ReadLine(), out result);
                }
                
                IPaymentProcessor entry1 = ProcessPayment(result);
                Console.WriteLine($"You are procesing this payment with {entry1.PaymentType}");
                entry1.Initialize();
                entry1.ProcessPayment();

                Console.WriteLine("----------------------\n");

                Console.WriteLine("Do you want to process another payment? enter y or n.");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Please enter an amount for the transaction, i.e. 23.45- no dollar sign and two decimal places only.");

                }
                else
                {
                    break;
                }

            }
            while (!finished);
        
        }

        public static IPaymentProcessor ProcessPayment(decimal paymentAmount)
        {
            string paymentType;
            if (paymentAmount <= 100)
            {
                paymentType = "Ingenic";
            }
            else if (paymentAmount <= 500)
            {
                paymentType = "Clover";
            }
            else
            {
                paymentType = "Square";
            }

            switch (paymentType)
            {
                case "Ingenic":
                    return new Ingenic(paymentAmount);
                case "Clover":
                    return new Clover(paymentAmount);
                default:
                   return new Square(paymentAmount);

            }
        }
    }
}
