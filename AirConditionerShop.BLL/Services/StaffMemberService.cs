using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    //GUI <-> Service (BLL) <-> Repo (DAL) <-> DBCONTEXT
    //                          CRUD
    public class StaffMemberService
    {
        private MemberRepository _repo = new MemberRepository();

        public StaffMember Authenticate(string email, string password)
        {
            return _repo.GetOne(email, password);
        }
     
    }
}
