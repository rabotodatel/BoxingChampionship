using BoxingChampionshipWebApplication.Models;
using BoxingChampionshipWebApplication.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;

namespace BoxingChampionshipWebApplication.Services
{
    public class CrudService
    {
        public void InsertBattle(Battle battle)
        {
            using (BattleContext db = new BattleContext()) 
            {
                db.Battles.Add(battle);
                db.SaveChanges();
            }
        }

        public Battle GetBattle(int id)
        {
            using(BattleContext db = new BattleContext())
            {
                var battle = db.Battles.Where(x => x.Id == id).SingleOrDefault();
                return battle;
            }
        }

        public void UpdateBattle(int id, Battle newBattle)
        {
            using (BattleContext db = new BattleContext())
            {
                var battle = db.Battles.Where(x => x.Id == id).SingleOrDefault();
                battle.AmountOfRounds = newBattle.AmountOfRounds;
                battle.BoxerOne = newBattle.BoxerOne;
                battle.BoxerTwo = newBattle.BoxerTwo;
                battle.Date = newBattle.Date;
                battle.RefereePointsOne = newBattle.RefereePointsOne;
                battle.RefereePointsTwo = newBattle.RefereePointsTwo;
                db.SaveChanges();
            }
        }

        public void DeleteBattle(int id)
        {
            using(BattleContext db = new BattleContext())
            {
                var battle = db.Battles.Where(x => x.Id == id).SingleOrDefault();
                db.Battles.Remove(battle);
                db.SaveChanges();
            }
        }

        public List<RankingVM> GetRankings()
        {
            var rankings = new List<RankingVM>();
            using(BattleContext db = new BattleContext())
            {
                var battles = db.Battles.ToList();
                rankings = battles
                    .GroupBy(b => b.BoxerOne)
                    .Select(r => new RankingVM
                    {
                        AmountOfBattles = r.Count() + (battles.Count(bt => bt.BoxerTwo == r.First().BoxerOne)),
                        Name = r.First().BoxerOne,
                        Wins = r.Count()
                    }).ToList();
                rankings = rankings.OrderByDescending(x => x.Wins).ToList();
            }
            return rankings;
        }
    }
}