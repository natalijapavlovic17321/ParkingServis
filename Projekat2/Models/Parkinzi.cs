using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projekat.Models
{    public class Parkinzi
    {
      [Key]
      [Column("ID")]
      public int ID{get;set;}
      [Column("Naziv")]
      [MaxLength(255)]
      public string Naziv{get;set;}
      [Column("Num")]
      public int Num{ get;set;}
      [Column("N")]
      public int N{get;set;}
      [Column("M")]
      public int M{get;set;}
      [Column("Parking")]
      public virtual List<Parking> Parkings{ get;set;}
    }
}