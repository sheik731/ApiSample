using InterviewManagementSystemAPI.DataAccessLayer;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
namespace InterviewManagementSystemAPI.DataFactory{
    public static class PoolDataFactory
    {
        public static IPoolDataAccessLayer GetPoolDataAccessLayerObject()
        {
            return new PoolDataAccessLayer();
        }
        public static IPoolService GetPoolServiceObject()
        {
            return new PoolService();
        }
        public static Pool GetPoolObject()
        {
            return new Pool();
        }

    }
}