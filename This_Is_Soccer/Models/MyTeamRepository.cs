using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using This_Is_Soccer.Models.Entity;
using System.Data.Entity;

namespace This_Is_Soccer.Models
{
    public class MyTeamRepository : GenericRepository<MyTeamModel>
    {
        static IEnumerable<PlayerModel> playerModels = new List<PlayerModel>();

        public MyTeamModel[] GetMyTeam()
        {
            string UserId = HttpContext.Current.User.Identity.GetUserId();
            var myTeamModels = db.MyTeamModels.Include(m => m.Player).Where(m => m.Id.Contains(UserId));
            var playerArray = new MyTeamModel[11];


            foreach (var item in myTeamModels.ToList())
            {
                int b = 0;
                b = item.Player.PositionId - 1;

                playerArray[b] = new MyTeamModel { PlayerId = item.PlayerId, User = item.User, Player = item.Player };
            }


            return playerArray;
        }
        
        public void RemovePlayer(int id)
        {
            string UserId = HttpContext.Current.User.Identity.GetUserId();
            MyTeamModel teamModels = db.MyTeamModels.FirstOrDefault(m => m.PlayerId == id && m.Id == UserId); //m.PlayerId == id);
            db.MyTeamModels.Remove(teamModels);
            db.SaveChanges();
        }

        public void SetPlayersToAdd(int? id)
        {
            playerModels = db.PlayerModels.Include(p => p.Club).Include(p => p.Position).Where(p => p.PositionId == id);
        }

        public IEnumerable<PlayerModel> GetPlayersToAdd()
        {
            return playerModels;
        }

        public void AddPlayer(int id)
        {
            string UserId = HttpContext.Current.User.Identity.GetUserId();

            MyTeamModel som = new MyTeamModel
            {
                Id = UserId,
                PlayerId = id
            };
            db.MyTeamModels.Add(som);
            db.SaveChanges();
            SetPlayersToAdd(0);
        }

    }
}