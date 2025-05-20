using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IGenericRepository<PaymentTransaction> _paymenttransactionrepo;
        private readonly IMapper _mapper;

        public PaymentTransactionService(IGenericRepository<PaymentTransaction> paymenttransactionrepo,
            IMapper mapper)
        {
            _paymenttransactionrepo = paymenttransactionrepo;
            _mapper = mapper;
        }
        
        public async Task<ResponsePaymentTransactionDTO> AddPaymentTransaction(RequestPaymentTransactionDTO addTransactionDto)
        {
            
            var transaction = _mapper.Map<PaymentTransaction>(addTransactionDto);
            transaction = await _paymenttransactionrepo.AddAsync(transaction);
            await _paymenttransactionrepo.SaveChangesAsync();
            return _mapper.Map<ResponsePaymentTransactionDTO>(transaction);
        }


        public async Task<IEnumerable<ResponsePaymentTransactionDTO>?> GetAllPaymentTransactions()
        {
            var paymentTransactions = await _paymenttransactionrepo.GetAllAsync();
            var paymentTransactionsDto = new List<ResponsePaymentTransactionDTO>();
            if (paymentTransactions != null)
            {
                foreach (PaymentTransaction transaction in paymentTransactions)
                {
                    paymentTransactionsDto.Add(_mapper.Map<ResponsePaymentTransactionDTO>(transaction));
                }

            }
            return paymentTransactionsDto;
        }

        public async Task<ResponsePaymentTransactionDTO> GetPaymentTransactionById(int id)
        {
            var paymentTransaction = await _paymenttransactionrepo.GetByIdAsync(id);
            var paymentTransactionDto = _mapper.Map<ResponsePaymentTransactionDTO>(paymentTransaction);
            return paymentTransactionDto;
        }
    }
}
