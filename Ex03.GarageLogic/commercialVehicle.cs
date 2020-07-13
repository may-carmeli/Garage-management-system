using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class commercialVehicle : Vehicles
    {

        private readonly bool r_IsTransportingDangerousSubstances;
        private readonly float r_Cargovolume;

        public commercialVehicle(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyRemainingInItsEnergysource,
            int i_NumberOfWheelsInVehicles, float i_VehiclesWheelsMaxAirPressure, string i_WheelManufacturerName, float i_CurrentAirPressur,
            bool i_IsTransportingDangerousSubstances, float i_CargoVolume, VehicleEnergy i_VehicleEnergy) :
            base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyRemainingInItsEnergysource,
            i_NumberOfWheelsInVehicles, i_VehiclesWheelsMaxAirPressure, i_WheelManufacturerName, i_CurrentAirPressur, i_VehicleEnergy)
        {
            r_IsTransportingDangerousSubstances = i_IsTransportingDangerousSubstances;

            r_Cargovolume = i_CargoVolume;
        }


        public bool IsTransportingDangerousSubstances
        {
            get { return r_IsTransportingDangerousSubstances; }
        }


        public float Cargovolume
        {
            get { return r_Cargovolume; }
        }


        public override string ToString()
        {
            string DataOfTruckGas;

            DataOfTruckGas = string.Format("Is Transporting Dangerous Substances: {0}{2}" +
               "Cargo volume: {1}{2}"
              , IsTransportingDangerousSubstances.ToString(), Cargovolume.ToString(),
                Environment.NewLine);

            return DataOfTruckGas + base.ToString();

        }

    }
}