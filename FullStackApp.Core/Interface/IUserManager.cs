using FullStackApp.Core.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Interface
{
    public interface IUserManager
    {
        Operation CreateUser(UserModel model);
        Operation<UserModel[]> GetUsers();
        Operation<UserModel> GetUserById(int userId);
        Operation<UserModel> UpdateUser(UserModel model);
        Operation ChangePassword(string mail, string password, string newpassword);
        Operation<UserModel> ResetPassword(string email);
        Operation<UserModel> RecoverPassword(string email);
        Operation<bool> ValidateUser(string userName, string password);
        //Operation<RegisterModel> CreateRegister(RegisterModel model);
        Operation CreateRegister(UserModel model);
        Operation CreateRole(RoleModel model);
        Operation<RoleModel[]> GetRoles();
        Operation<RoleModel> GetRoleById(int roleId);
        Operation<RoleModel> UpdateRole(RoleModel model);
        Operation<RoleModel[]> GetRoles(int userId);
        void AssignRole(int userId, int roleId);
        Operation<RoleModel> RemoveRoleFromUser(int userId, string roleName);
        Operation<bool> HasRole(string email, string roleName);
        Operation<RoleModel[]> GetUserRoleByUserId(int userId);
        Operation<RoleModel[]> GetUnAssignedUserRoleByUserId(int userId);

    }
}
