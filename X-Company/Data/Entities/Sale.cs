namespace XCompany.Data.Entities;

public partial class Sale : BaseEntity
{
    public int CustomerId { get; set; }

    public DateTime SaleDate { get; set; }

    public virtual Customer Customer { get; set; } = new Customer();

    public virtual ICollection<Saleitem> SaleItems { get; set; } = new List<Saleitem>();

}
