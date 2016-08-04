namespace Explorer.DomainClasses.GettingStartedWithEF5.Models
{
  public class LineItem
  {
    public int LineItemId { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }

    public virtual Order Order { get; set; }
    public virtual Product Product { get; set; }
  }
}