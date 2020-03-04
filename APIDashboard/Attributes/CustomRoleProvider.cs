using System.Linq;
using APIDashboard.Models;

namespace APIDashboard.Attributes
{
    public class CustomRoleProvider 
    {
        
        private readonly DBAPIFUELSContext db;
        public CustomRoleProvider(DBAPIFUELSContext _db)
        {
            db = _db;
            
        }
        public bool IsUserInRole(string User, string Role) {


            var result = db.UserInRole.Where(w => w.UserName == User && w.RoleName == Role).Any();

            return result;
            //throw new NotImplementedException();
        }
    }
}
