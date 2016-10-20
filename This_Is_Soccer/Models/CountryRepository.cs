using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models.Entity;

namespace This_Is_Soccer.Models
{
    public class CountryRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Create(CountryModel country)
        {
            db.Countries.Add(country);
        }
    }
}