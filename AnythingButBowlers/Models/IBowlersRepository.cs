using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnythingButBowlers.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        IQueryable<Team> Teams { get; }

        public void SaveBowler(Bowler bowler);
        public void DeleteBowler(int bowlerId);
        public void EditBowler(int bowlerId);
    }
}
