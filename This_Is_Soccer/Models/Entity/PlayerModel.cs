using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity
{
    public class PlayerModel
    {
        [Key]
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        //Foreign key to Club
        public int ClubId { get; set; }
        public ClubModel Club { get; set; }

        //Foreign key til Position
        public int PositionId { get; set; }
        public PositionModel Position { get; set; }
    }
}