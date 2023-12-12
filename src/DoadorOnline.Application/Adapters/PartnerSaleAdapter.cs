
using DoadorOnline.Domain;

namespace DoadorOnline.Application;
public static class PartnerSaleAdapter
{
    public static List<SalesViewModel> ToListSalesViewModel(this List<PartnerSale> lstSales, string userLoggedInId) 
    => lstSales.Select(x => x.ToSalesViewModel(userLoggedInId)).ToList();
    public static SalesViewModel ToSalesViewModel(this PartnerSale partnerSale, string userLoggedInId)
    => new()
    {
        SaleId = partnerSale.Id,
        Base64Logo = partnerSale.User?.ProfileImage.ToBase64String(),
        Description = partnerSale.Description,
        Name = partnerSale.SaleName,
        Points = partnerSale.Points,
        IsAbleToDelete = partnerSale.DonatorId == userLoggedInId,
    };
}


