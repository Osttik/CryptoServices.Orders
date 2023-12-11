using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoServices.Orders.Infrastructure.Models
{
    public class UpdateOrderModel
    {
        public Guid Id { get; set; }
        public string NewState { get; set; } = string.Empty;
    }
}
