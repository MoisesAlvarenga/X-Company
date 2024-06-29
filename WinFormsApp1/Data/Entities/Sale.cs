namespace XCompany.Data.Entities;

public partial class Sale : BaseEntity
{
    public int Customerid { get; set; }

    public DateTime Saledate { get; set; }

    public virtual Customer Customer { get; set; } = new Customer();

    public virtual ICollection<Saleitem> Saleitems { get; set; } = new List<Saleitem>();

}
