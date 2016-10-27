using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;
using System.Data.Entity;


namespace This_Is_Soccer.Models
{
    public class PlayerRepository : GenericRepository<PlayerModel>
    {

        public IEnumerable<PlayerModel> SelectAll()
        {
            var playerModels = db.PlayerModels.Include(p => p.Club).Include(p => p.Position);
            return playerModels; 
        }
    }
}