using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace This_Is_Soccer.Models.Entity
{
    public class PositionModel
    {
        [Key]
        public int PositionId { get; set; }
        public string PositionName { get; set; }

        public ICollection<PlayerModel> Players { get; set; }

    }
}