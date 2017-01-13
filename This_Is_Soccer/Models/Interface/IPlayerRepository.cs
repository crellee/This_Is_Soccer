using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using This_Is_Soccer.Models.Entity;

namespace This_Is_Soccer.Models.Interface
{
    
        public interface IPlayerRepository 
        {
            IEnumerable<PlayerModel> SelectAll();

            PlayerModel SelectByID(int? id);


            DbSet<ClubModel> GetClubModels();

    
            DbSet<PositionModel> GetPositionModels();

            IQueryable<PlayerModel> Search(string searchString);

            IEnumerable<PlayerModel> getTeamMates(int? clubId, int? playerId);
            
           
        }
}
