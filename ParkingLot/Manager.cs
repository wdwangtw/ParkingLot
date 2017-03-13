using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class Manager
    {
        readonly List<ParkingBoyBase> parkingBoys = new List<ParkingBoyBase>();

        public Manager(List<ParkingLot> parkingLots, List<ParkingBoyBase> parkingBoys)
        {
            this.parkingBoys.AddRange(parkingBoys);
            this.parkingBoys.Add(new SuperParkingBoy(parkingLots));
        }

        public ParkCarResult Park(Car car)
        {
            return parkingBoys.Any(boy => boy.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }

        public Car Pick(string carId)
        {
            return parkingBoys.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}