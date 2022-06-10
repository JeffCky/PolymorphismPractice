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
                isADecimal = decimal.TryParse(Console.ReadLine(), out result);
                if (result <= 100)
                {
                    Ingenic entry1 = new Ingenic(result);
                    Console.WriteLine($"You are procesing this payment with {entry1.PaymentType}");
                    entry1.Initialize();
                    entry1.ProcessPayment();

                    Console.WriteLine("----------------------\n");

                }
                else if (result <= 500)
                {
                    Clover entry2 = new Clover(result);
                    Console.WriteLine($"You are procesing this payment with {entry2.PaymentType}");
                    entry2.Initialize();
                    entry2.ProcessPayment();

                    Console.WriteLine("----------------------\n");
                }
                else
                {
                    Square entry3 = new Square(result);
                    Console.WriteLine($"You are procesing this payment with {entry3.PaymentType}");
                    entry3.Initialize();
                    entry3.ProcessPayment();

                    Console.WriteLine("----------------------\n");
                }
                Console.WriteLine("Do you want to do it again? enter y or n.");
                if(Console.ReadLine() == "y")
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
    }
}
