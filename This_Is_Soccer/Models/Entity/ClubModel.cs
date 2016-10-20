using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity
{
    public class ClubModel
    {
        [Key]
        public int ClubId { get; set; }
        public int ClubName { get; set; }
        public string ClubLogo { get; set; }

        //Foreign key to Country
        public int CountryId { get; set; }
        public CountryModel Country { get; set; }
    }
}