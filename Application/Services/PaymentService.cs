using Application.IServices;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        public Task<PaymentTransaction> AddPaymentTransaction(PaymentTransaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task<PaymentTransaction> GetPaymentTransaction(int id)
        {
            throw new NotImplementedException();
        }
    }
}
