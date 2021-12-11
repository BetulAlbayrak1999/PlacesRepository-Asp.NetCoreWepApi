using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VisitWithUs.Entities
{
    public class Place
    {
            [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int PlaceId { get; set; }

            [Required,  StringLength(50, ErrorMessage = "The Place Name should have {1} maximum characters")]
            public string PlaceName { get; set; }
            [Required]
            public string CityName { get; set; }

            [Required, StringLength(100, ErrorMessage = "The Place Adress should have {1} maximum characters")]
            public string PlaceAdress { get; set; }

            [Required, StringLength(maximumLength: 20, ErrorMessage = "The Phone Number should have {1} maximum characters")]
            public string PhoneNumber { get; set; }

            [Required, DataType(DataType.EmailAddress)]
            public string PlaceEmail { get; set; }

            [Required, DataType(DataType.Time)] 
            public string OpeningTime { get; set; }

            [Required, DataType(DataType.Time)]
            public string ClosingTime { get; set; }

            [Required]
            public double EntranceFee { get; set; }

            [Required, StringLength(maximumLength: 200, ErrorMessage = "The Place Description {0} should have {1} maximum characters")]
             public string PlaceDescription { get; set; }

             [Required, DataType(DataType.ImageUrl)]
             public string ImageURL { get; set; }
        
    }
}

