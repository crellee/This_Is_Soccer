using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity
{
    public class CountryModel
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}