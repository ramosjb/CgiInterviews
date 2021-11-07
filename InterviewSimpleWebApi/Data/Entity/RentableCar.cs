using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSimpleWebApi.Data.Entity
{
    public class RentableCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Car")]
        public long CarId { get; set; }

        public Car Car { get; set; }

        public ClientRentedCar ClientRentedCar { get; set; }
    }
}
