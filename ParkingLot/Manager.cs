using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class Manager : PickerParker
    {
        readonly List<PickerParker> pickerParkers;

        public Manager(List<PickerParker> pickerParkers)
        {
            this.pickerParkers = pickerParkers;
        }

        public override ParkCarResult Park(Car car)
        {
            return pickerParkers.Any(pickerParker => pickerParker.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }

        public override Car Pick(string carId)
        {
            return pickerParkers.
                Select(pickerParker => pickerParker.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}