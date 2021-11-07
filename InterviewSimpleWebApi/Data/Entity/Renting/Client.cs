using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSimpleWebApi.Data.Entity
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public ICollection<ClientRentedCar> ClientRentedCars { get; set; }
    }
}
