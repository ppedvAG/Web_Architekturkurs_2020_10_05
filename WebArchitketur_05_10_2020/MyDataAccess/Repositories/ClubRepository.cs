using GenericRepository;
using Microsoft.EntityFrameworkCore;
using MyDataAccess.Data;
using MyDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyDataAccess.Repositories
{
    public class ClubRepository : RepositoryBase<Clubs>
    {

        private ClubDBContext _context = null;

        public ClubRepository()
        {
            _context = DbContextFactory.ClubDBContextInstance;
        }

        public override async Task<int> Count()
        {
            return await _context.Clubs.CountAsync();
        }

        public override async Task  Delete(Expression<Func<Clubs, bool>> predicate)
        {
            IList<Clubs> clubsToDelete = _context.Clubs.Where(predicate).ToList();

            foreach (Clubs currentToDelete in clubsToDelete)
            {
                _context.Clubs.Remove(currentToDelete);
            }

            await _context.SaveChangesAsync();
        }

        public override async Task Delete(Clubs entity)
        {
            _context.Clubs.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public override async Task<List<Clubs>> GetAll()
        {
            return await _context.Clubs.ToListAsync();
        }

        public override async Task Insert(Clubs entity)
        {
            _context.Clubs.Add(entity);
            await _context.SaveChangesAsync();
        }

        public override async Task<Clubs> Single(Expression<Func<Clubs, bool>> predicate)
        {
            return await _context.Clubs.SingleAsync(predicate);
        }

        public override async Task Update(Clubs orginalEntity, Clubs modifiedEntity)
        {

            _context.Attach(orginalEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public override async Task Update(Clubs modifiedEntity)
        {
            //var currentClub = _context.Clubs.Single(c => c.Id == modifiedEntity.Id);

            try
            {
                _context.Attach(modifiedEntity);
            
                _context.Entry(modifiedEntity).State = EntityState.Modified;

            
                await _context.SaveChangesAsync();

                return;
            }
            catch (Exception e) //Only for my dear Andre :)
            {

            }

            
        }

        public override Task<List<Clubs>> Where(Expression<Func<Clubs, bool>> predicate)
        {
            return _context.Clubs.Where(predicate).ToListAsync();
        }
    }
}
