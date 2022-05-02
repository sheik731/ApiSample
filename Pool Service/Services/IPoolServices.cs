using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.Service{
    public interface IPoolService 
    {
        public  bool CreatePool(string PoolName);
        public bool RemovePool(int PoolId);
        public IEnumerable<Pool> ViewPools(int DeptId);

    }
}