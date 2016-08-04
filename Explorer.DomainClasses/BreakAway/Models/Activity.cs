﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Explorer.DomainClasses.BreakAway.Models
{
  public class Activity
  {
    public int ActivityId { get; set; }
    [Required, MaxLength(50)]
    public string Name { get; set; }
    public List<Trip> Trips { get; set; }
  }
}