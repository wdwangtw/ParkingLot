﻿using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class SmartParkingBoy : ParkingBoyBase
    {
        public SmartParkingBoy(List<ParkingLot> parkingLots) : base(parkingLots, ParkerType.Smart)
        {
        }

        public override string NameDescription
        {
            get { return "SmartBoy"; }
        }
    }
}