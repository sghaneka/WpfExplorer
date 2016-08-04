using System;
using System.Collections.Generic;

namespace Explorer.DomainClasses.GettingStartedWithEF5.Models
{
  public class Product
  {
    private ICollection<Category> _categories;
    private ICollection<LineItem> _lineItems;

    public Product()
    {
      _lineItems = new HashSet<LineItem>();
      _categories = new HashSet<Category>();
    }

    public int ProductId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTime ProductionStart { get; set; }

    public virtual ICollection<LineItem> LineItems
    {
      get { return _lineItems; }
      set { _lineItems = value; }
    }

    public virtual ICollection<Category> Categories
    {
      get { return _categories; }
      set { _categories = value; }
    }

  }
}