using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Country.Models
{
    public class CountryAll
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Country Name")]
        public string CountryName  { get; set; }

        [Required]
        public int Population { get; set; }

        [Required]
        [DisplayName("National Language")]
        public string NationalLangauge { get; set; }

        [Required]
        [DisplayName("Number Of States")]
        public int NumberOfStates { get; set; }

        [Required]
        public string Region  { get; set; }
    }
}
