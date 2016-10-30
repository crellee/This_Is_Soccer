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
        public new ClubModel SelectByID(object id)
        {
            table.Include(c => c.CountryId);
            return table.Find(id);
        }
    }
}