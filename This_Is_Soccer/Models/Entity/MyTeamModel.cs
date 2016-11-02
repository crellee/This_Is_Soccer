using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity
{
    public class MyTeamModel
    {
        /*
        [Key]
        [Column(Order = 0)]
        public string MyTeamId { get; set; }
        */

        [Key]
        [Column(Order = 1)]
        public string Id { get; set; }
        public ApplicationUser User { get; set; }

        [Column(Order = 2)]
        public int PositionId { get; set; }
        public int PlayerId { get; set; }
        public PlayerModel Player { get; set; }
        
        
        
        


    }
}