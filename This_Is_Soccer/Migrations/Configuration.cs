namespace This_Is_Soccer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Entity;

    internal sealed class Configuration : DbMigrationsConfiguration<This_Is_Soccer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(This_Is_Soccer.Models.ApplicationDbContext context)
        {
            context.Countries.AddOrUpdate(h => h.CountryId, new CountryModel[]
                                                             {
                                                                 new CountryModel
                                                                 {
                                                                     CountryId = 1,
                                                                     CountryName="Spain"
                                                                 },
                                                                 new CountryModel
                                                                 {
                                                                     CountryId = 2,
                                                                     CountryName="Germany"
                                                                 },
                                                                 new CountryModel
                                                                 {
                                                                     CountryId = 3,
                                                                     CountryName="Italy"
                                                                 },
                                                                 new CountryModel
                                                                 {
                                                                     CountryId = 4,
                                                                     CountryName="England"
                                                                 },
                                                             });

            context.ClubModels.AddOrUpdate(h => h.ClubId, new ClubModel[]
                                                             {
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 1,
                                                                     ClubName="FC Barcelona",
                                                                     ClubLogo="http://s.weltsport.net/bilder/wappen/mittel/530.gif",
                                                                     CountryId=1
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 2,
                                                                     ClubName="Real Madrid",
                                                                     ClubLogo="http://www.footballdatabase.eu/images/foot/club/28.png",
                                                                     CountryId=1
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 3,
                                                                     ClubName="Atletico Madrid",
                                                                     ClubLogo="http://i.eurosport.com/_iss_/sport/football/club/logo/medium/4012.png",
                                                                     CountryId=1
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 4,
                                                                     ClubName="FC Bayern München",
                                                                     ClubLogo="http://www.visitfootball.dk/wp-content/uploads/2014/10/bayern-munchen-logo.png",
                                                                     CountryId=2
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 5,
                                                                     ClubName="Borussia Dortmund",
                                                                     ClubLogo="http://www.footballmatch.de/images/Wappen/dortmund.gif",
                                                                     CountryId=2
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 6,
                                                                     ClubName="Juventus",
                                                                     ClubLogo="http://s.weltsport.net/bilder/wappen/mittel/511.gif",
                                                                     CountryId=3
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 7,
                                                                     ClubName="Manchester United",
                                                                     ClubLogo="http://www.visitfootball.dk/wp-content/uploads/2014/08/manchester-united-logo.png",
                                                                     CountryId=4
                                                                 },
                                                                  new ClubModel
                                                                 {
                                                                     ClubId = 8,
                                                                     ClubName="Arsenal F.C.",
                                                                     ClubLogo="https://yt3.ggpht.com/-dZ2LhrpNpxs/AAAAAAAAAAI/AAAAAAAAAAA/L0Wl0cFKYhE/s100-c-k-no-mo-rj-c0xffffff/photo.jpg",
                                                                     CountryId=4
                                                                 }
                                                             });
            context.PositionModels.AddOrUpdate(h => h.PositionId, new PositionModel[]
                                                                     {
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 1,
                                                                            PositionName = "GK"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 2,
                                                                            PositionName = "LCB"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 3,
                                                                            PositionName = "RCB"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 4,
                                                                            PositionName = "LB"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 5,
                                                                            PositionName = "RB"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 6,
                                                                            PositionName = "LCM"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 7,
                                                                            PositionName = "RCM"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 8,
                                                                            PositionName = "LM"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 9,
                                                                            PositionName = "RM"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 10,
                                                                            PositionName = "LCF"
                                                                        },
                                                                        new PositionModel
                                                                        {
                                                                            PositionId = 11,
                                                                            PositionName = "RCF"
                                                                        },
                                                            });
            context.PlayerModels.AddOrUpdate(a => a.PlayerId, new PlayerModel[]
                                                                    {
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 1,
                                                                            PlayerName = "Messi",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/158023.png",
                                                                            ClubId = 1,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 2,
                                                                            PlayerName = "Suarez",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/176580.png",
                                                                            ClubId = 1,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 3,
                                                                            PlayerName = "Neymar",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/190871.png",
                                                                            ClubId = 1,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 4,
                                                                            PlayerName = "Iniesta",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/41.png",
                                                                            ClubId = 1,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 5,
                                                                            PlayerName = "Busquets",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189511.png",
                                                                            ClubId = 1,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 6,
                                                                            PlayerName = "Rakitic",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/168651.png",
                                                                            ClubId = 1,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 7,
                                                                            PlayerName = "Roberto",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/199564.png",
                                                                            ClubId = 1,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 8,
                                                                            PlayerName = "Alba",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189332.png",
                                                                            ClubId = 1,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 9,
                                                                            PlayerName = "Pique",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/152729.png",
                                                                            ClubId = 1,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 10,
                                                                            PlayerName = "Macherano",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/142754.png",
                                                                            ClubId = 1,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 11,
                                                                            PlayerName = "Stegen",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/192448.png",
                                                                            ClubId = 1,
                                                                            PositionId = 1
                                                                        },
                                                            });


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
