using System;

namespace PolyMorph__Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter an amount for the transaction, i.e. 23.45- no dollar sign and two decimal places only.");
            Console.WriteLine("Amounts less than or equal to $200 will be processed with Ingenic.");
            Console.WriteLine("Amounts more than $200 and less than or equal to $500 will be processed with Clover.");
            Console.WriteLine("Amounts more than and equal to $501 will be processed with Square.");

            decimal result = 0m;
            bool isADecimal;
            bool finished = false;
            
            do
            {
                string type;
                isADecimal = decimal.TryParse(Console.ReadLine(), out result);
                while (!isADecimal)
                {
                    Console.WriteLine("Your entry was not a decimal, try again.");
                    isADecimal = decimal.TryParse(Console.ReadLine(), out result);
                }
                type = PickAProcessor(result);

                IPaymentProcessor entry1 = ProcessPayment(type, result);
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

        private static string PickAProcessor(decimal result)
        {
            string type;
            if (result <= 100)
            {
                type = "Ingenic";
            }
            else if (result <= 500)
            {
                type = "Clover";
            }
            else
            {
                type = "Square";
            }

            return type;
        }

        public static IPaymentProcessor ProcessPayment(string paymentType, decimal paymentAmount)
        {
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
