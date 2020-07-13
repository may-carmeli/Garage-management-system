using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class Motorcycle : Vehicles
    {
        public enum eLicenseType { A, A1, AA, B };
        private readonly eLicenseType r_LicenseType;
        private int m_EngineVolumeInCc;
        private const float k_MotorcycleWheelsMaxAirPressure = 3;
        private const int k_MotorcycleNumOfWheels = 2;


        public Motorcycle(eLicenseType i_LicenseType, int i_EngineVolumeInCc, string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, string i_WheelManufacturerName, float i_CurrentAirPressur, VehicleEnergy i_VehicleEnergy) :
            base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyRemainingInItsEnergysource,
            k_MotorcycleNumOfWheels, k_MotorcycleWheelsMaxAirPressure, i_WheelManufacturerName, i_CurrentAirPressur, i_VehicleEnergy)
        {
            r_LicenseType = i_LicenseType;

            EngineVolumeInCc = i_EngineVolumeInCc;
        }

        public eLicenseType LicenseType
        {
            get { return r_LicenseType; }

        }
        public int EngineVolumeInCc
        {
            get { return m_EngineVolumeInCc; }
            set { m_EngineVolumeInCc = value; }

        }
        public static float MotorcycleWheelsMaxAirPressure
        {
            get { return k_MotorcycleWheelsMaxAirPressure; }

        }
        public int MotorcycleNumOfWheels
        {
            get { return k_MotorcycleNumOfWheels; }

        }

        public override string ToString()
        {
            string DataOfMotorcycle;

            DataOfMotorcycle = string.Format("License Type: {0}{3}" +
                "Engine Volume In Cc: {1}{3}" +
                "Number Of Wheels: {2}{3}", LicenseType.ToString(), EngineVolumeInCc.ToString()
                , MotorcycleNumOfWheels.ToString(), Environment.NewLine);

            return DataOfMotorcycle + base.ToString();

        }
    }
}
