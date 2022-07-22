using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatroom.Service.Services.RabbitMQ.Interfaces
{
    public interface IStockCatalogService
    {
        Task<T> GetStockByAPIAsync<T>(string API);
    }
}
