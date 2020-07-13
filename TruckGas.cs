using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class TruckGas : commercialVehicle
    {

        private static FuelEnergy.eTypeOfFuel k_TypeOfFuel = FuelEnergy.eTypeOfFuel.Soler;
        private const float k_MaximumAmountOfFuelInLiters = 120;
        private const int k_NumberOfWheelsInTruck = 16;
        private const float k_CarWheelsMaxAirPressure = 28;

        public TruckGas(float FuelPresentInLiters, string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyRemainingInItsEnergysource,
             string i_WheelManufacturerName, float i_CurrentAirPressur, bool i_IsTransportingDangerousSubstances, float i_Cargovolume) : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyRemainingInItsEnergysource,
            k_NumberOfWheelsInTruck, k_CarWheelsMaxAirPressure, i_WheelManufacturerName, i_CurrentAirPressur, i_IsTransportingDangerousSubstances, i_Cargovolume, new FuelEnergy(MaximumAmountOfFuelInLiters, FuelPresentInLiters, TypeOfFuel))
        {

        }


        public static FuelEnergy.eTypeOfFuel TypeOfFuel
        {
            get { return k_TypeOfFuel; }

        }

        public int NumberOfWheelsInTruck
        {
            get { return k_NumberOfWheelsInTruck; }

        }

        public static float MaximumAmountOfFuelInLiters
        {
            get { return k_MaximumAmountOfFuelInLiters; }

        }

        public static float CarWheelsMaxAirPressure
        {
            get { return k_CarWheelsMaxAirPressure; }

        }


        public override string ToString()
        {
            string DataOfTruckGas;

            DataOfTruckGas = string.Format("Type Of Fuel: {0}{4}" +
               "The amount of fuel remaining: {2}{4}" +
               "Maximum Amount Of Fuel In Liters: {2}{4}" +
               "Number Of Wheels In Truck: {3}{4}", TypeOfFuel, MaximumAmountOfFuelInLiters, (this as Vehicles).VehicleEnergy.RemainingEnergy.ToString(),
               NumberOfWheelsInTruck, Environment.NewLine);

            return DataOfTruckGas + base.ToString();

        }
    }
}