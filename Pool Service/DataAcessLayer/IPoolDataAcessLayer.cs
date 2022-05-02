using InterviewManagementSystemAPI.Models;
namespace InterviewManagementSystemAPI.DataAccessLayer{
    public interface IRoleDataAccessLayer{
        public bool AddPoolToDatabase(Role role);
         public bool RemovePoolFromDatabase(int roleId);
         public List<Role> GetPoolsFromDatabase();
    }
}