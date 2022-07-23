namespace Chatroom.Service.Services.Interfaces
{
    public interface IStockCatalogService
    {
        Task<T> GetStockByAPIAsync<T>(string API);
    }
}
