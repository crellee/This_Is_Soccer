namespace This_Is_Soccer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.Entity;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<This_Is_Soccer.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(This_Is_Soccer.Models.ApplicationDbContext context)
        {

            var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            rm.Create(new IdentityRole("admin"));

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var client1 = new ApplicationUser { UserName = "secret@admin.com" };

            var result1 = userManager.Create(client1, "P_assw0rd1");

            if (result1.Succeeded == false)
            {
                client1 = userManager.FindByName("secret@admin.com");
            }


            //save this change to the database to get the GUID that is used as an Id.
            context.SaveChanges();

            userManager.AddToRole(client1.Id, "admin");
            




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
                                                                                                                                                new PlayerModel
                                                                        {
                                                                            PlayerId = 12,
                                                                            PlayerName = "Benzema",
                                                                            PlayerPic ="http://futhead.cursecdn.com/static/img/17/players/165153.png",
                                                                            ClubId = 2,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 13,
                                                                            PlayerName = "Morata",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/201153.png",
                                                                            ClubId = 2,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 14,
                                                                            PlayerName = "Ronaldo",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/20801.png",
                                                                            ClubId = 2,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 15,
                                                                            PlayerName = "Bale",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/173731.png",
                                                                            ClubId = 2,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 16,
                                                                            PlayerName = "Modric",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/177003.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 17,
                                                                            PlayerName = "Kroos",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/182521.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 18,
                                                                            PlayerName = "Carvajal",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/204963.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 19,
                                                                            PlayerName = "Marcelo",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/176676.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 20,
                                                                            PlayerName = "Ramos",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/155862.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 21,
                                                                            PlayerName = "Pepe",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/120533.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 22,
                                                                            PlayerName = "Navas",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193041.png ",
                                                                            ClubId = 2,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 23,
                                                                            PlayerName = "Griezmann",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/194765.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 24,
                                                                            PlayerName = "Torres",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/49369.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 25,
                                                                            PlayerName = "Gaitán",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/184144.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 26,
                                                                            PlayerName = "Carrasco",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/208418.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 27,
                                                                            PlayerName = "Koke",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193747.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 28,
                                                                            PlayerName = "Gabi",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/146954.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 29,
                                                                            PlayerName = "Luis",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/164169.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 30,
                                                                            PlayerName = "Juanfran",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/146760.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 31,
                                                                            PlayerName = "Godin",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/182493.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 32,
                                                                            PlayerName = "Giménez",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/216460.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 33,
                                                                            PlayerName = "Oblak",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/200389.png",
                                                                            ClubId = 3,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 34,
                                                                            PlayerName = "Lewandowski",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/188545.png ",
                                                                            ClubId = 3,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 35,
                                                                            PlayerName = "Müller",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189596.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 36,
                                                                            PlayerName = "Coman",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/213345.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 37,
                                                                            PlayerName = "Robben",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/9014.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 38,
                                                                            PlayerName = "Vidal",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/181872.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 39,
                                                                            PlayerName = "Alonso",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/45197.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 40,
                                                                            PlayerName = "Alaba",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/197445.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 41,
                                                                            PlayerName = "Lahm",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/121939.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 42,
                                                                            PlayerName = "Boateng",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/183907.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 43,
                                                                            PlayerName = "Hummels",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/178603.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 44,
                                                                            PlayerName = "Neuer",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/167495.png ",
                                                                            ClubId = 4,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 45,
                                                                            PlayerName = "Aubameyang",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/188567.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 46,
                                                                            PlayerName = "Ramos",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/176619.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 47,
                                                                            PlayerName = "Reus",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/188350.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 48,
                                                                            PlayerName = "Schürrle",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193130.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 49,
                                                                            PlayerName = "Kagawa",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189358.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 50,
                                                                            PlayerName = "Götze",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/192318.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 51,
                                                                            PlayerName = "Schmelzer",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/188802.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 52,
                                                                            PlayerName = "Piszczek",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/173771.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 53,
                                                                            PlayerName = "Sokratis",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/172879.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 54,
                                                                            PlayerName = "Bartra",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/198141.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 55,
                                                                            PlayerName = "Bürki",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189117.png ",
                                                                            ClubId = 5,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 56,
                                                                            PlayerName = "Higuaín",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/167664.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 57,
                                                                            PlayerName = "Mandzukic",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/181783.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 58,
                                                                            PlayerName = "Dybala",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/211110.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 59,
                                                                            PlayerName = "Cuadrado",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193082.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 60,
                                                                            PlayerName = "Khedira",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/179846.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 61,
                                                                            PlayerName = "Marchisio",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/173210.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 62,
                                                                            PlayerName = "Evra",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/52091.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 63,
                                                                            PlayerName = "Alves",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/146530.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 64,
                                                                            PlayerName = "Chiellini",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/138956.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 65,
                                                                            PlayerName = "Bonucci",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/184344.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 66,
                                                                            PlayerName = "Buffon",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/1179.png ",
                                                                            ClubId = 6,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 67,
                                                                            PlayerName = "Ibrahimovic",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/41236.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 68,
                                                                            PlayerName = "Rashford",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/231677.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 69,
                                                                            PlayerName = "Pogba",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players_alt/p67304728.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 70,
                                                                            PlayerName = "Mkhitaryan",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/192883.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 71,
                                                                            PlayerName = "Rooney",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/54050.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 72,
                                                                            PlayerName = "Mata",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/178088.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 73,
                                                                            PlayerName = "Shaw",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/205988.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 74,
                                                                            PlayerName = "Damian",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/184392.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 75,
                                                                            PlayerName = "Smalling",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/189881.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 76,
                                                                            PlayerName = "Bailly",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/225508.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 77,
                                                                            PlayerName = "Gea",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/193080.png ",
                                                                            ClubId = 7,
                                                                            PositionId = 1
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 78,
                                                                            PlayerName = "Sanchez",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/184941.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 11
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 79,
                                                                            PlayerName = "Giroud",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/178509.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 10
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 80,
                                                                            PlayerName = "Walcott",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/164859.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 9
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 81,
                                                                            PlayerName = "Cazorla",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/146562.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 8
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 82,
                                                                            PlayerName = "Özil",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/176635.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 7
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 83,
                                                                            PlayerName = "Ramsey",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/186561.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 6
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 84,
                                                                            PlayerName = "Monreal",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/177604.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 5
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 85,
                                                                            PlayerName = "Bellerin",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/203747.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 4
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 86,
                                                                            PlayerName = "Koscielny",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/165229.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 3
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 87,
                                                                            PlayerName = "Mustafi",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/192227.png ",
                                                                            ClubId = 8,
                                                                            PositionId = 2
                                                                        },
                                                                        new PlayerModel
                                                                        {
                                                                            PlayerId = 88,
                                                                            PlayerName = "Cech",
                                                                            PlayerPic = "http://futhead.cursecdn.com/static/img/17/players/48940.png ",
                                                                            ClubId = 8,
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
