using System.Collections.Generic;

namespace ParkingLots
{
    public interface IParker
    {
        ParkCarResult ParkCar(List<ParkingLot> parkingLots, Car car);
    }
}