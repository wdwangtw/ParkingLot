using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class Manager : IPickerParker
    {
        readonly List<IPickerParker> pickerParkers;

        public Manager(List<IPickerParker> pickerParkers)
        {
            this.pickerParkers = pickerParkers;
        }

        public virtual ParkCarResult Park(Car car)
        {
            return pickerParkers.Any(pickerParker => pickerParker.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }

        public virtual Car Pick(string carId)
        {
            return pickerParkers.
                Select(pickerParker => pickerParker.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}