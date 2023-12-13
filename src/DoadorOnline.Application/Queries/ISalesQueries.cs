
namespace DoadorOnline.Application
{
    public interface ISalesQueries
    {
        Task<List<SalesViewModel>> GetSales();
        Task<IEnumerable<SalesViewModel>> GetCarouselSales();
    }
}