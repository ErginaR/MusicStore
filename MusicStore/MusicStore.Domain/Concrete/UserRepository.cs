using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Domain.Concrete
{
    public class UserRepository:IUserRepository
    {
        MusicStoreDbContext context = new MusicStoreDbContext();
        public IEnumerable<User> Users 
        { 
            get 
            {
                return context.Users;
            } 
        } 
        public bool SaveUser(User user)
        {
            User userdb = context.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);//shohim nqs ne db ndodhet ndonje user me username dhe password te njejte
            if(userdb==null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
