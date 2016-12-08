using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;
using System.Data.Entity;
using System.Web.Mvc;
using This_Is_Soccer.Models.Interface;

namespace This_Is_Soccer.Models
{
  
    public class PlayerRepository : IPlayerRepository
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        public IQueryable<PlayerModel> Search(string searchString)
        {
            var players = SelectAll().AsQueryable();
            //var players = from m in db.PlayerModels select m;


            if (!string.IsNullOrEmpty(searchString))
            {
                players = players.Where(s => s.PlayerName.ToLower().Contains(searchString) ||
                                             s.Club.ClubName.ToLower().Contains(searchString)
                );
            }
            return players;
        }
    }
}