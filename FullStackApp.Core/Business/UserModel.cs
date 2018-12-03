using FullStackApp.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackApp.Core.Business
{
    public class UserModel : Model
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        // public string ConfirmPassword { get; set; }

        public UserModel()
        {

        }

        public UserModel(User user)
        {
            this.Assign(user);


        }
        public User CreateUser(UserModel model)
        {
            return new User()
            {
                Password = Password,
                Email = Email,
                Name = Name
                // ConfirmPassword =  ConfirmPassword


            };
        }
        public User Edit(User entity, UserModel model)
        {
            //entity.UserName = model.UserName;      
            entity.Email = model.Email;
            entity.Password = model.Password;
            entity.Name = model.Name;
            //entity.AccessTypeId = model.AccessTypeId;
            //entity.AccessTypeValueId = model.AccessTypeValueId;
            return entity;
        }
    }
}
