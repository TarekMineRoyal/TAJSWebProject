using DataAccess.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IServices
{
    public interface IPaymentService
    {
        Task Pay(User user, double amount);
    }
}
