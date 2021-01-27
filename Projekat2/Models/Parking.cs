using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projekat.Models
{
    [Table("Parking")]
    public class Parking
    {
        [Column("ID")]
        public int ID{get;set;}
        [Column("Tip")]
        [MaxLength(255)]
        public string Tip{get;set;}   
        [Column("Naselje")]
        [MaxLength(255)]
        [Key]
        public string Naselje{get;set;}
        [Column("N")]
        public int N{get;set;}
        [Column("M")]
        public int M{get;set;}
        [Column("BrojZauzetih")]
        public int Brojzauzetih{get;set;}
        [Column("Mesta")]
        public virtual List<Mesta> Listamesta{get;set;}
        [JsonIgnore]
        public Parkinzi Parkinzi{get;set;}
    }
}