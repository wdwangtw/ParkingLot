using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SuperParkingBoy : ParkingBoyBase
    {
        public SuperParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots, ParkerType.Super)
        {
        }

        public override string NameDescription
        {
            get { return "SuperBoy"; }
        }
    }
}