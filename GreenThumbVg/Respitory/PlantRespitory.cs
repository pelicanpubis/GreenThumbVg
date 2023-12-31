﻿using GreenThumbVg.Database;
using GreenThumbVg.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenThumbVg.Respitory
{
    // En generisk klass 'PlantRepository' som arbetar med olika typer av entiteter (T) där T är en klass
    public class PlantRepository<T> where T : class
    {
        // En instans av databasens DbContext
        private readonly GreenThumbVgDbContext _context;

        // En instans av en specifik DbSet<T>
        private readonly DbSet<T> _dbSet;


        // Konstruktör som tar emot en instans av databasens DbContext och initierar instansvariabler
        public PlantRepository(GreenThumbVgDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>(); // Initierar _dbSet med en specifik DbSet<T>

        }

        public async Task<List<PlantModel>> GetAllGardenPlants(int userId)
        {
            // Assuming you have access to your database context
            using (var dbContext = new GreenThumbVgDbContext()) // Replace with your actual DbContext instantiation logic
            {
                var userGardenPlants = await dbContext.GardenPlants
                    .Where(gp => gp.Garden.UserId == userId) // Filter by the user's ID
                    .Select(gp => gp.Plant)
                    .ToListAsync();

                return userGardenPlants;
            }
        }

        // Hämtar en entitet av typen T baserat på det givna ID:t
        public async Task<T?> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        // Hämtar alla entiteter av typen T
        public async Task<List<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        // Lägger till en entitet av typen T till DbSet<T>
        public async Task Add(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        //// Tar bort en entitet av typen T från DbSet<T> och sparar ändringar i databasen
        //public async Task Delete(T entity)
        //{
        //    _dbSet.Remove(entity);
        //    await _context.SaveChangesAsync();
        //}

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        // Metod för att lägga till en växt och dess instruktioner till en trädgård//använder inte denna... borde tas bort
        public void AddPlantAndInstructionsToGarden(PlantModel plant)
        {

            using (GreenThumbVgDbContext context = new GreenThumbVgDbContext())
            {
                context.Plants.Add(plant); 
                context.SaveChanges();
            }
        }


        public async Task<List<PlantModel>> GetAllGardensPlants(int userId)
        {
            var userGardenPlants = await _context.GardenPlants
                .Where(gp => gp.Garden.UserId == userId)
                .Select(gp => gp.Plant)
                .ToListAsync();

            return userGardenPlants;
        }

    }

}