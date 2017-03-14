namespace ParkingLots
{
    public class ParkingLotProviderFactory
    {
        public static IParkingLotProvider CreateParkingLotProvider(ParkingLotProviderType parkingLotProviderType)
        {
            switch (parkingLotProviderType)
            {
                case ParkingLotProviderType.Commen:
                    return new CommonParkingLotProvider();
                case ParkingLotProviderType.Smart:
                    return new SmartParkingLotProvider();
                case ParkingLotProviderType.Super:
                    return new SuperParkingLotProvider();
                default:
                    return null;
            }
        }
    }
}