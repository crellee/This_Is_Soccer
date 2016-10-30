using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;
using System.Data.Entity;

namespace This_Is_Soccer.Models
{
    public class ClubRepository : GenericRepository<ClubModel>
    {
        public new IEnumerable<ClubModel> SelectAll()
        {
            var clubModels = db.ClubModels.Include(c => c.Country);
            return clubModels;
        }
        public ClubModel SelectByID(int? id)
        {
            var clubModel = db.ClubModels
            .Include(c => c.Country)
            .FirstOrDefault(c => c.ClubId == id);

            return clubModel;
        }
        public DbSet<CountryModel> GetCountryModels()
        {
            return db.Countries;
        }
    }
}