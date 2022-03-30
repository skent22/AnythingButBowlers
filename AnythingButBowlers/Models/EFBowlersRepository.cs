using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnythingButBowlers.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }
        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams.Include(x => x.TeamID);

        public void SaveBowler(Bowler bowler)
        {
            if (bowler.BowlerID == 0)
            {
                _context.Bowlers.Add(bowler);
                _context.SaveChanges();

            }

            _context.SaveChanges();
        }

        public void DeleteBowler(int bowlerId)
        {
            Bowler bowler = _context.Bowlers.Where(x => x.BowlerID == bowlerId).FirstOrDefault();
            _context.Remove(bowler);
            _context.SaveChanges();
        }

        public void EditBowler(int bowlerId)
        {
            Models.Bowler bowler = _context.Bowlers.Single(x => x.BowlerID == bowlerId);
        }

    }
}
