using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricMotorcycel : Motorcycle
    {

        private const float k_MaximumBatteryInHours = 1.2f;

        public ElectricMotorcycel(eLicenseType i_LicenseType, float i_BatteryTimeremainingInhours, int i_EngineVolumeInCc, string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, string i_WheelManufacturerName, float i_CurrentAirPressur) :
            base(i_LicenseType, i_EngineVolumeInCc, i_ModelName, i_LicenseNumber,
            i_PercentageOfEnergyRemainingInItsEnergysource, i_WheelManufacturerName, i_CurrentAirPressur, new ElectricalEnergy(k_MaximumBatteryInHours * 60, i_BatteryTimeremainingInhours * 60))
        {

        }


        public static float MaximumBatteryInHours
        {
            get { return k_MaximumBatteryInHours; }
        }


        public override string ToString()
        {
            string DataOfElectricMotorcycel;

            DataOfElectricMotorcycel = string.Format("Battery Timer emaining In hours: {0}{3}" +
                "Maximum Battery In Minutes: {2}{3}"
               , (this as Vehicles).VehicleEnergy.RemainingEnergy.ToString(),
                MaximumBatteryInHours.ToString(), Environment.NewLine);

            return DataOfElectricMotorcycel + base.ToString();

        }
    }
}
