using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorcycelWorkingOnGas : Motorcycle
    {

        private static FuelEnergy.eTypeOfFuel k_TypeOfFuel = FuelEnergy.eTypeOfFuel.Occtan95;//סוג הדלק
        private const float k_MaximumAmountOfFuelInLiters = 7;

        public MotorcycelWorkingOnGas(float i_AmountOfFuelPresentInLiters, eLicenseType i_LicenseType, int i_EngineVolumeInCc, string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, string i_WheelManufacturerName, float i_CurrentAirPressur) : base(i_LicenseType, i_EngineVolumeInCc, i_ModelName, i_LicenseNumber,
            i_PercentageOfEnergyRemainingInItsEnergysource, i_WheelManufacturerName, i_CurrentAirPressur, new FuelEnergy(MaximumAmountOfFuelInLiters, i_AmountOfFuelPresentInLiters, TypeOfFuel))
        {


        }

        public static FuelEnergy.eTypeOfFuel TypeOfFuel
        {
            get { return k_TypeOfFuel; }

        }


        public static float MaximumAmountOfFuelInLiters
        {
            get { return k_MaximumAmountOfFuelInLiters; }

        }


        public override string ToString()
        {
            string DataOfMotorcycelWorkingOnGas;

            DataOfMotorcycelWorkingOnGas = string.Format("Type Of Fuel: {0}{3}" +
                "Amount Of Fuel Present In Liters: {1}{3}" +
                "Maximum Amount Of Fuel In Liters: {2}{3}"
               , TypeOfFuel.ToString(), (this as Vehicles).VehicleEnergy.RemainingEnergy.ToString().ToString(),
                MaximumAmountOfFuelInLiters.ToString(), Environment.NewLine);

            return DataOfMotorcycelWorkingOnGas + base.ToString();

        }

    }
}
