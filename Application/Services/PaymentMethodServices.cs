using Application.DTOs.Car;
using Application.DTOs.CarBooking;
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
    public class PaymentMethodServices : IPaymentMethodService
    {
        private readonly IGenericRepository<PaymentMethod> _paymentMethodRepo;
        private readonly IMapper _mapper;
        public PaymentMethodServices(IGenericRepository<PaymentMethod> paymentMethodRepo,
            IMapper mapper)
        {
            _paymentMethodRepo = paymentMethodRepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponsePaymentMethod>> GetAllPaymentMethodsAsync()
        {
            var methods = await _paymentMethodRepo.GetAllAsync();
            var methodsDto = new List<ResponsePaymentMethod>();
            if (methods is not null)
            {
                foreach (PaymentMethod method in methods)
                {
                    methodsDto.Add(_mapper.Map<ResponsePaymentMethod>(method));
                }
            }
            return methodsDto;
        }
        public async Task<ResponsePaymentMethod> GetPaymentMethodByIdAsync(int id)
        {
            var paymentMethod = await _paymentMethodRepo.GetByIdAsync(id);
            return _mapper.Map<ResponsePaymentMethod>(paymentMethod);
        }
        public async Task<ResponsePaymentMethod> AddPaymentMethodAsync(RequestPaymentMethod paymentMethod)
        {
            var method = _mapper.Map<PaymentMethod>(paymentMethod);

            method = await _paymentMethodRepo.AddAsync(method);
            await _paymentMethodRepo.SaveChangesAsync();

            return _mapper.Map<ResponsePaymentMethod>(method);
        }
        public async Task<ResponsePaymentMethod> DeletePaymentMethodAsync(int id)
        {
            var methodDto = await _paymentMethodRepo.RemoveAsync(id);

            _paymentMethodRepo.SaveChanges();

            return _mapper.Map<ResponsePaymentMethod>(methodDto);
        }
        public async Task<ResponsePaymentMethod> UpdatePaymentMethodAsync(int id, RequestPaymentMethod dto)
        {
            var payment = await _paymentMethodRepo.GetByIdAsync(id);

            if (payment is null)
                return null;

            var mappedCar = _mapper.Map<PaymentMethod>(dto);

            mappedCar.Id = payment.Id;

            payment = await _paymentMethodRepo.UpdateAsync(id, mappedCar);

            _paymentMethodRepo.SaveChanges();

            return _mapper.Map<ResponsePaymentMethod>(payment);
        }
    }
}
