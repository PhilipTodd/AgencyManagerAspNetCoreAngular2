using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AgencyManager.Models;
using Microsoft.EntityFrameworkCore;

namespace AgencyManager.DAL.Repository
{
    public class PositionRepository : IDisposable
    {
        private AgencyManagerContext context;

        public PositionRepository(AgencyManagerContext context)
        {
            this.context = context;
        }

        public class PositionCriteria
        {
            public int ContactId { get; set; }
        }

        public IEnumerable<Position> GetPositions(PositionCriteria criteria)
        {
            IQueryable<Position> query = context.Positions;

            if (criteria.ContactId > 0)
            {
                query = query.Where(Position => Position.ContactId == criteria.ContactId);
            }

            query = query.OrderByDescending(Position => Position.Created);

            return query.ToList();
        }

        public Position GetPositionByID(int id)
        {
            return context.Positions.Find(id);
        }

        public void InsertPosition(Position Position)
        {
            context.Positions.Add(Position);
        }

        public void DeletePosition(int PositionID)
        {
            Position Position = context.Positions.Find(PositionID);
            context.Positions.Remove(Position);
        }

        public void UpdatePosition(Position Position)
        {
            context.Entry(Position).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}