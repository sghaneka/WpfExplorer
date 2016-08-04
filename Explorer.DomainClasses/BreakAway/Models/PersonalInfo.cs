using System.ComponentModel.DataAnnotations.Schema;

namespace Explorer.DomainClasses.BreakAway.Models
{
  [ComplexType]
  public class PersonalInfo
  {
    public Measurement Weight { get; set; }
    public Measurement Height { get; set; }
    public string DietryRestrictions { get; set; }
  }
}