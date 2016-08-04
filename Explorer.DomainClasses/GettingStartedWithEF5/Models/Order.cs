using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Explorer.DomainClasses.GettingStartedWithEF5.Models.Enums;

namespace Explorer.DomainClasses.GettingStartedWithEF5.Models
{
  public class Order
  {
    private ICollection<LineItem> _lineItems;

    public Order()
    {
      _lineItems = new List<LineItem>();
    }

    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public DbGeography DestinationLatLong { get; set; }
    public OrderSource OrderSource { get; set; }
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<LineItem> LineItems
    {
      get { return _lineItems; }
      set { _lineItems = value; }
    }
  }
}