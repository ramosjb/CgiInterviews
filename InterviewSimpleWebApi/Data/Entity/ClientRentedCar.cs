using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSimpleWebApi.Data.Entity
{
    public class ClientRentedCar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime RentalStart { get; set; }

        public long KilometersAtRentalStart { get; set; }

        public DateTime RentalDelivery { get; set; }

        public long KilometersAtRentalDelivery { get; set; }

        [ForeignKey("Client")]
        public long ClientId { get; set; }

        public Client Client { get; set; }

        [ForeignKey("RentableCar")]
        public long RentableCarId { get; set; }

        public RentableCar RentableCar { get; set; }

        [DefaultValue(true)]

        public bool OngoingRental { get; set; }

    }
}
