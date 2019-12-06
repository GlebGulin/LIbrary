using Binding;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAllOrder();
    }
    public class OrderService : IOrderService
    {
        private readonly LibraryDBContext _os;
        public OrderService(LibraryDBContext os)
        {
            _os = os;  
        }
        public IEnumerable<Order> GetAllOrder()
        {

            var result = new List<Order>();
            try
            {
                result = _os.dataOrder.ToList();


            }
            catch (System.Exception)
            {

            }
            return result;
        }
    }

}
