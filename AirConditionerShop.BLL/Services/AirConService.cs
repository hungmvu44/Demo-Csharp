using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;

namespace AirConditionerShop.BLL.Services
{
    //GUI <-> Service (BLL) <-> Repo
    public class AirConService
    {
        private AirConRepository _repo = new AirConRepository();

        public List<AirConditioner> GetAllAircons()
        {
            return _repo.GetAll();
        }

        public void AddAircon(AirConditioner x)
        {
            _repo.Add(x);
        }

        public void UpdateAircon(AirConditioner x)
        {
            _repo.Update(x);
        }

        public void DeleteAircon(AirConditioner x)
        {
            _repo.Delete(x);
        }

        //Search product
    }
}
