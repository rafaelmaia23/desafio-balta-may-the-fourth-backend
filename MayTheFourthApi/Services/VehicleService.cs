﻿using MayTheFourthApi.Data;
using MayTheFourthApi.Models;
using MayTheFourthApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace MayTheFourthApi.Services
{
    public class VehicleService : IVehicleService
    {
        private AppDbContext _db;
        public VehicleService(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddVehicle(Vehicle vehicle)
        {
            await _db.Vehicles.AddAsync(vehicle);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            var vehicle = await _db.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicle == null) return false;

            _db.Vehicles.Remove(vehicle);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Vehicle?> GetVehicleById(int id)
        {
            return await _db.Vehicles.FirstAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehicles()
        {
            return _db.Vehicles;
        }

        public async Task<Vehicle> UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleToBeUpdated = await _db.Vehicles.FirstOrDefaultAsync(x => x.Id == id);
            if (vehicleToBeUpdated == null) return null;

            vehicleToBeUpdated.Name = vehicle.Name;
            vehicleToBeUpdated.Model = vehicle.Model;
            vehicleToBeUpdated.Manufacturer = vehicle.Manufacturer;
            vehicleToBeUpdated.CostInCredits = vehicle.CostInCredits;
            vehicleToBeUpdated.Length = vehicle.Length;
            vehicleToBeUpdated.MaxSpeed = vehicle.MaxSpeed;
            vehicleToBeUpdated.Crew = vehicle.Crew;
            vehicleToBeUpdated.Passengers = vehicle.Passengers;
            vehicleToBeUpdated.CargoCapacity = vehicle.CargoCapacity;
            vehicleToBeUpdated.Consumables = vehicle.Consumables;
            vehicleToBeUpdated.Class = vehicle.Class;

            _db.Vehicles.Update(vehicleToBeUpdated);
            await _db.SaveChangesAsync();
            return vehicleToBeUpdated;
        }
    }
}
