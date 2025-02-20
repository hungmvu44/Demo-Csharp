using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirConditionerShop.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirConditionerShop.DAL.Repositories
{
    //GUI <-> Services(BLL) <-> DAL(REPO) <-> DBCONTEXT
    public class AirConRepository
    {
        private AirConditionerShop2024DbContext? _context;
        
        //CRUD
        public List<AirConditioner> GetAll()

        {
            _context = new AirConditionerShop2024DbContext();
            return _context.AirConditioners.Include("Supplier").ToList(); //Select * from AirConditioner
        }

        public void Add(AirConditioner x)
        {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Add(x);
            _context.SaveChanges();
        }

        public void Update(AirConditioner x) {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Update(x);
            _context.SaveChanges();
        }

        public void Delete(AirConditioner x)
        {
            _context = new AirConditionerShop2024DbContext();
            _context.AirConditioners.Remove(x); //delete from RAM
            _context.SaveChanges(); //delete from table
        }
    }
}
