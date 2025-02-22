using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;

namespace AirConditionerShop.DAL.Repositories
{
    //GUI <-> Service (BLL) <-> Repo (DAL) <-> DBCONTEXT
    public class MemberRepository
    {
        private AirConditionerShop2024DbContext _context;

        //Only one member at the time
        public StaffMember GetOne(string? email, string? password)
        {
            _context = new AirConditionerShop2024DbContext();
            return _context.StaffMembers.FirstOrDefault(x => x.EmailAddress.ToLower() == email.ToLower() && x.Password == password);
        }

        
    }
}
