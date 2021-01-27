using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Projekat.Models
{
    [Table("Mesta")]
    public class Mesta
    {
        [Column("ID")]
        public int ID {get;set;}
        [Column("Tablica")]
        [MaxLength(255)]
        [Key]
        public string Tablica{get;set;}
        [Column("Dani")]
        public int Dani{get;set;}
        [Column("X")]
        public int X{get;set;}
        [Column("Y")]
        public int Y{get;set;}
        [Column("Tip")]
        [MaxLength(255)]
        public string Tip{get;set;}
        [Column("Povrsina")]
        [MaxLength(255)]
        public string Povrsina{get;set;}
        [Column("Naselje")]
        [MaxLength(255)]
        public string Naselje{get;set;}
        //[Column("Vrsta")]
        //[MaxLength(255)]
        //public string Vrsta{get;set;}
        [JsonIgnore]
        public Parking Parking{get;set;}
        [JsonIgnore]
        public Parkinzi Parkinzi{get;set;}
    }
}