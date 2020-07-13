using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class CarWorkingOnGas : Car
    {

        private static FuelEnergy.eTypeOfFuel k_TypeOfFuel = FuelEnergy.eTypeOfFuel.Occtan96;
        private const float k_MaximumAmountOfFuelInLiters = 60;

        public CarWorkingOnGas(int i_AmountOfDoors, float i_AmountOfFuelPresentInLiters, eColor i_ColorOfCar
            , string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, float i_CurrentAirPressur, String i_WheelManufacturerName) : base(i_AmountOfDoors, i_ColorOfCar
            , i_ModelName, i_LicenseNumber,
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
            string DataOfElectroniCar;

            DataOfElectroniCar = string.Format("Type Of Fuel: {0}{3}" +
                "Amount Of Fuel Present In Liters: {1}{3}" +
                "Maximum Amount Of FuelIn Liters: {2}{3}", TypeOfFuel.ToString(), (this as Vehicles).VehicleEnergy.RemainingEnergy.ToString(),
                MaximumAmountOfFuelInLiters.ToString(), Environment.NewLine);

            return DataOfElectroniCar + base.ToString();
        }


    }
}
