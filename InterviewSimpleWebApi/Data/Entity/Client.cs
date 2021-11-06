using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterviewSimpleWebApi.Data.Entity
{
    [Index("IX_LicenseNumber", "LicenseNumber", IsUnique = true)]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string LicenseNumber { get; set; }

        public ICollection<ClientRentedCar> ClientRentedCars { get; set; }

    }
}
