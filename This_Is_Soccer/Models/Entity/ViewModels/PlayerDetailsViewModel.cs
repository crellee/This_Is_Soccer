using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity.ViewModels
{
    public class PlayerDetailsViewModel
    {
        public PlayerModel Player { get; set; }
        public List<PlayerModel> Players { get; set; }
    }
}