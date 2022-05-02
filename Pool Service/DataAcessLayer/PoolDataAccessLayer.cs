using InterviewManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagementSystemAPI.DataAccessLayer
{
    public class PoolDataAccessLayer : IPoolDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();

        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Pool object is not passed 
        */

        //private readonly ILogger _logger = new ILogger<PoolDataAccessLayer>();        
        public bool AddPoolToDatabase(Pool Pool)
        {
            if (Pool == null)
                throw new ArgumentNullException("Pool is not provided");
            try
            {
                _db.Pools.Add(Pool);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Pool Id is not passed 
        */
        public bool RemovePoolFromDatabase(int PoolId)
        {
            if (PoolId != 0)
                throw new ArgumentNullException("Pool Id is not provided ");

            try
            {
                var Pool = _db.Pools.Find(PoolId);
                Pool.IsActive = false;
                _db.Pools.Update(Pool);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }

        }

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
        public List<Pool> GetPoolsFromDatabase()
        {
            try
            {
                return _db.Pools.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }

         public bool AddPoolMembersToDatabase(PoolMembers PoolMembers)
        {
            if (PoolMembers == null)
                throw new ArgumentNullException("PoolMembers is not provided");
            try
            {
                _db.PoolMembers.Add(PoolMembers);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }

         public bool RemovePoolMembersToDatabase(PoolMembers PoolMembers)
        {
            if (PoolMembers == null)
                throw new ArgumentNullException("Pool Member is not provided");
            try
            {
                var PoolMembers = _db.PoolMembers.Find(PoolMembersId);
                PoolMembers.IsActive = false;
                _db.Poolmembers.Update(Poolmembers);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }

         public List<PoolMembers> GetPoolMembersFromDatabase()
        {
            try
            {
                return _db.PoolMembers.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }

    }
}