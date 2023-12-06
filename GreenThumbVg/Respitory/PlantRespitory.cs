using GreenThumbVg.Database;
using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Respitory
{
    public class PlantRepository<T> where T : class
    {

        private readonly GreenThumbVgDbContext _context;
        private readonly DbSet<T> _dbSet;



        public PlantRepository(GreenThumbVgDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }


        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void AddPlantAndInstructionsToGarden(PlantModel plant)
        {
            // Here you would add the plant and its instructions to your ListView
            // For instance:
            // listViewPlants.Items.Add(plant);

            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                context.Plants.Add(plant); // Save the plant to the database
                context.SaveChanges();
            }
        }


    }

}