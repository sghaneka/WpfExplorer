namespace Explorer.DomainClasses.BreakAway.Models
{
  public class Hostel : Lodging
  {
    public int MaxPersonsPerRoom { get; set; }
    public bool PrivateRoomsAvailable { get; set; }
  }
}