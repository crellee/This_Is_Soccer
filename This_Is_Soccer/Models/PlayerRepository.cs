using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;
using System.Data.Entity;
using System.Web.Mvc;

namespace This_Is_Soccer.Models
{
    public class PlayerRepository : GenericRepository<PlayerModel>
    {
        public IEnumerable<PlayerModel> SelectAll()
        {
            var playerModels = db.PlayerModels.Include(p => p.Club).Include(p => p.Position);
            return playerModels; 
        }

        public PlayerModel SelectByID(int? id)
        {
            var playerModel = db.PlayerModels
                .Include(p => p.Position)
                .Include(p => p.Club)
                .First(p => p.PlayerId == id);

            return playerModel;
        }

        public DbSet<ClubModel> GetClubModels()
        {
            //SelectList selectList = new SelectList(db.ClubModels, "ClubId", "ClubName");
            return db.ClubModels;
        }

        public DbSet<PositionModel> GetPositionModels()
        {
            // SelectList selectList = new SelectList(db.PositionModels, "PositionId", "PositionName");
            return db.PositionModels;
        }
    }
}