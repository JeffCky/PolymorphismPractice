using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyMorph__Practice
{
    internal interface IPaymentProcessor
    {
        string PaymentType { get; }
        bool HasBeenInitialized { get; }

        decimal PaymentAmount { get; }
        void Initialize();
        void ProcessPayment();
    }
    
}
