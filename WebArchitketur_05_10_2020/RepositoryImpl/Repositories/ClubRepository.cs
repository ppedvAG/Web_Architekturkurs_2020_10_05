using GenericRepository;
using Microsoft.EntityFrameworkCore;
using RepositoryImpl.EFContext;
using RepositoryImpl.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryImpl.Repositories
{
    public class ClubRepository : RepositoryBase<Clubs>
    {

        private ClubDBContext _dbContext = null;

        public ClubRepository()
        {
            _dbContext = DbContextFactory.ClubDBContextInstance;
        }

        

        public override async Task<int> Count()
        {
            return await _dbContext.Clubs.CountAsync();
        }

        public override void Delete(Expression<Func<Clubs, bool>> predicate)
        {
            
        }

        public override void Delete(Clubs entity)
        {
            _dbContext.Clubs.Remove(entity);
        }

        public override IList<Clubs> GetAll()
        {
            return _dbContext.Clubs.ToList();
        }

        public override void Insert(Clubs entity)
        {
            _dbContext.Clubs.Add(entity);
        }

        public override Clubs Single(Expression<Func<Clubs, bool>> predicate)
        {
            return _dbContext.Clubs.Single(predicate);
        }

        public override void Update(Clubs orginalEntity, Clubs modifiedEntity)
        {
            if (orginalEntity.Id == modifiedEntity.Id)
                _dbContext.Entry(modifiedEntity).State = EntityState.Modified;
        }

        public override IList<Clubs> Where(Expression<Func<Clubs, bool>> predicate)
        {
            return _dbContext.Clubs.Where(predicate).ToList();
        }


       


    }
}
