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

        [Required(ErrorMessage = "A name is too important to miss. Please enter a player name.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Use letters only please")]
        [MinLength(2, ErrorMessage = "A name must be at least two characters")]
        public string PlayerName { get; set; }
        
        [RegularExpression(@"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)", ErrorMessage = "Unvalid link!" )]
        public string PlayerPic { get; set; }

        //Foreign key to Club
        public int ClubId { get; set; }
        public ClubModel Club { get; set; }

        //Foreign key til Position
        public int PositionId { get; set; }
        public PositionModel Position { get; set; }

    }
}