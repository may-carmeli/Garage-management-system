using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {

        private const float k_MaximumBatteryInHours = 2.1f;

        public ElectricCar(int i_AmountOfDoors, float i_BatteryTimeremainingInhours, eColor i_ColorOfCar
            , string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, float i_CurrentAirPressur, String i_WheelManufacturerName) :
            base(i_AmountOfDoors, i_ColorOfCar, i_ModelName, i_LicenseNumber,
            i_PercentageOfEnergyRemainingInItsEnergysource, i_WheelManufacturerName, i_CurrentAirPressur, new ElectricalEnergy(MaximumBatteryInHours * 60, i_BatteryTimeremainingInhours * 60))
        {

        }


        public static float MaximumBatteryInHours
        {

            get { return k_MaximumBatteryInHours; }

        }


        public override string ToString()
        {
            string DataOfElectroniCar;

            DataOfElectroniCar = string.Format("The battery timere maining Minutes: {0}{2}" +
                "The maximum battery in Minutes: {1}{2}",
                (this as Vehicles).VehicleEnergy.RemainingEnergy.ToString(), (this as Vehicles).VehicleEnergy.MaximumEnergy.ToString(), Environment.NewLine);

            return DataOfElectroniCar + base.ToString();
        }


    }
}
