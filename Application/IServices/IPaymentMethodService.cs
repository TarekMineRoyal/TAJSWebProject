using Application.DTOs.CarBooking;
using Application.DTOs.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPaymentMethodService
    {
        Task<ResponsePaymentMethod?> GetPaymentMethodByIdAsync(int id);
        Task<ResponsePaymentMethod> AddPaymentMethodAsync(RequestPaymentMethod dto);
        Task<IEnumerable<ResponsePaymentMethod>> GetAllPaymentMethodsAsync();
        Task<ResponsePaymentMethod?> UpdatePaymentMethodAsync(int id, RequestPaymentMethod dto);
        Task<ResponsePaymentMethod> DeletePaymentMethodAsync(int id);
    }
}
