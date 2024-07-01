namespace XCompany.Data.Entities;

public partial class Saleitem : BaseEntity
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public int Amount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
