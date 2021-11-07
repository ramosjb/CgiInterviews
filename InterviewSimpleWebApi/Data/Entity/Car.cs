using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSimpleWebApi.Data.Entity
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string Brand { get; set; }

        public string Color { get; set; }

        public long Kilometers { get; set; }

        public string LicensePlate { get; set; }
    }
}
