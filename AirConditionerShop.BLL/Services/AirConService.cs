using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using AirConditionerShop.DAL.Repositories;
using Microsoft.IdentityModel.Tokens;

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
        //If user not entering both Feature and Quantity => Load All Data
        //If user entering Feature => criteria search
        //if quantity is not int data type => show warning
        public List<AirConditioner> SearchByFeatureAndQuantity(string feature, int? quantity) //quantiy could be Null => user does not enter Quantity
        {
            //1.Load full if not entering Feature and Quantity
            List<AirConditioner> result = _repo.GetAll();
            if (feature.IsNullOrEmpty() && !quantity.HasValue)
            {
                return result;
            }
            //2. Search by Feature. WHERE filter whatever user input string from database
            if (!feature.IsNullOrEmpty())
            {
                result = result.Where(ac => ac.FeatureFunction.ToLower().Contains(feature)).ToList();
            }
            //.3 Search quantiy
            if (quantity.HasValue)
            {
                result = result.Where(ac => ac.Quantity == quantity).ToList();
            }

            return result;
        }
    }
}
