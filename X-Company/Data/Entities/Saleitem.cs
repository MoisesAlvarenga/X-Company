namespace XCompany.Data.Entities;

public partial class Saleitem : BaseEntity
{
    public int Saleid { get; set; }

    public int Productid { get; set; }

    public int Amount { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sale { get; set; } = null!;

    //public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
