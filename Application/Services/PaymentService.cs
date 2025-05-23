using Application.DTOs.Payment;
using Application.IRepositories;
using Application.IServices;
using AutoMapper;
using Domain.Entities.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IGenericRepository<Payment> _paymentrepo;
        private readonly IMapper _mapper;
        public PaymentService(IGenericRepository<Payment> paymentrepo,
            IMapper mapper)
        {
            _mapper = mapper;
            _paymentrepo = paymentrepo;
        }
        public async Task<IEnumerable<ResponsePaymentDTO>> GetAllPayments()
        {
            var payments = await _paymentrepo.GetAllAsync();
            var paymentsDto = new List<ResponsePaymentDTO>();
            if (payments != null)
            {
                foreach (Payment payment in payments)
                {
                    paymentsDto.Add(_mapper.Map<ResponsePaymentDTO>(payment));
                }
            }
            return paymentsDto;
        }

        public async Task<ResponsePaymentDTO> GetPaymentById(int id)
        {
            var payment = await _paymentrepo.GetByIdAsync(id);
            var paymentDto = _mapper.Map<ResponsePaymentDTO>(payment);
            return paymentDto;
        }

        public async Task<ResponsePaymentDTO> AddPayment(RequestPaymentDTO addPaymentDto)
        {
            var payment = _mapper.Map<Payment>(addPaymentDto);
            payment = await _paymentrepo.AddAsync(payment);
            await _paymentrepo.SaveChangesAsync();
            return _mapper.Map<ResponsePaymentDTO>(payment);
        }

    }
}
