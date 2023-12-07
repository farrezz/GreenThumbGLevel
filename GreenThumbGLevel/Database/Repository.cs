using GreenThumbGLevel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbGLevel.Database
{
    //e
    class Repository 
    {
        private readonly GreenThumbDbContext _context;


        public Repository(GreenThumbDbContext context)
        {
            _context = context;
        }
        public List<Plant> GetAll()
        {
            return _context.Plants.ToList();
        }
        public void Add(Plant plant)
        {
            _context.Plants.Add(plant);
        }
        //Då vi inte har Id som key, utgår vi från name som har satts till key. Därav hämtar vi name (som string).
        public Plant? GetbyName(string name)
        {
            return _context.Plants.FirstOrDefault(p => p.PlantName == name);
        }

        public void Update(string name, Plant plant)
        {
            Plant? PlantToUpdate = _context.Plants.FirstOrDefault(p => p.PlantName == name);
            if (PlantToUpdate != null)
            {
                PlantToUpdate.PlantName = plant.PlantName;
                PlantToUpdate.PlantDescription = plant.PlantDescription;
                PlantToUpdate.PlantOrigin = plant.PlantOrigin;
            }
        }
        public void Delete(string name)
        {
            Plant? PlantToDelete = _context.Plants.FirstOrDefault(p => p.PlantName == name);
            if (PlantToDelete != null)
            {
                _context.Plants.Remove(PlantToDelete);
            }
        }
    }
}
