﻿using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingLot
    {
        readonly List<Car> cars;
        readonly int parkingSpaceCount;

        public ParkingLot(int parkingSpaceCount = 10)
        {
            cars = new List<Car>(parkingSpaceCount);
            this.parkingSpaceCount = parkingSpaceCount;
        }

        public ParkCarResult Park(Car car)
        {
            if (cars.Count != parkingSpaceCount)
            {
                cars.Add(car);
                return ParkCarResult.Success;
            }

            return ParkCarResult.NoParkingSpace;
        }

        public Car Pick(string carId)
        {
            Car picked = cars.FirstOrDefault(car => car.Id == carId);
            cars.Remove(picked);
            return picked;
        }

        public int EmptyParkingSpace()
        {
            return parkingSpaceCount - cars.Count;
        }
    }
}