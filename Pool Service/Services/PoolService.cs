using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.DataAccessLayer;
using System.Linq;
namespace InterviewManagementSystemAPI.Service
{
    public class PoolService : IPoolService
    {
        private IPoolDataAccessLayer _PoolDataAccessLayer = DataFactory.PoolDataFactory.GetPoolDataAccessLayerObject();
        private Pool _Pool = DataFactory.PoolDataFactory.GetPoolObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Pool Name is not passed to this service method
        */
        public bool CreatePool(string PoolName, int DeptId)
        {
            if (PoolName == null || DeptId == null)
                throw new ArgumentNullException("Pool Name is not provided");

            try
            {
                _Pool.PoolName = PoolName;
                return _PoolDataAccessLayer.AddPoolToDatabase(_Pool) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Pool Id is not passed to this service method
        */

        public bool RemovePool(int DeptId, string PoolName)
        {
            if (DeptName == null || PoolName == null)
                throw new ArgumentNullException("Pool Name or Department Name is not provided");

            try
            {
                return _PoolDataAccessLayer.RemovePoolFromDatabase(PoolId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching Pools
        */
        public IEnumerable<Pool> ViewPools(string DeptId)
        {
            try
            {
                IEnumerable<Pool> Pools = new List<Pool>();
                return Pools = from Pool in _PoolDataAccessLayer.GetPoolsFromDatabase() where Pool.IsActive == true select Pool;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching Pools"
                throw new Exception();
            }
        }

         public bool AddPoolMembers (int EmployeeID, int PoolId)
        {
            if (EmployeeID == null || PoolId == null)
                throw new ArgumentNullException("PoolID is not provided");

            try
            {
                _Pool.PoolId = PoolId;
                return _PoolDataAccessLayer.AddPoolToDatabase(_PoolMembers) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

            public bool RemovePoolMembers (int EmployeeID, int PoolId)
        {
            if (EmployeeID == null || PoolId == null)
                throw new ArgumentNullException("PoolID is not provided");

            try
            {
                _Pool.PoolId = PoolId;
                return _PoolDataAccessLayer.RemovePoolToDatabase(_PoolMembers) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        } public IEnumerable<PoolMembers> ViewPoolMembers(int DeptId, int PoolId, int RoleId, String EmployeeName)
        {
            try
            {
                IEnumerable<PoolMembers> Pools = new List<PoolMembers>();
                return PoolMembers = from Pool in _PoolDataAccessLayer.GetPoolmembersFromDatabase() where Pool.IsActive == true select Pool;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching Pools"
                throw new Exception();
            }
        }



    }
}