using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicles
    {

        private readonly string m_ModelName;
        private readonly string m_LicenseNumber;
        private float m_PercentageOfEnergyRemainingInItsEnergysource;
        private readonly List<CollectionofWheels> m_CollectionofWheel;
        private VehicleEnergy m_VehicleEnergy;

        public Vehicles(string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyRemainingInItsEnergysource,
            int i_NumberOfWheelsInVehicles, float i_VehiclesWheelsMaxAirPressure, string i_WheelManufacturerName, float i_CurrentAirPressur, VehicleEnergy i_VehicleEnergy)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            PercentageOfEnergyRemainingInItsEnergysource = i_PercentageOfEnergyRemainingInItsEnergysource;

            m_CollectionofWheel = new List<CollectionofWheels>();

            createVehicleWheels(i_NumberOfWheelsInVehicles, i_WheelManufacturerName, i_CurrentAirPressur, i_VehiclesWheelsMaxAirPressure);
            VehicleEnergy = i_VehicleEnergy;
        }


        public VehicleEnergy VehicleEnergy
        {
            get { return m_VehicleEnergy; }
            set { m_VehicleEnergy = value; }
        }


        public List<CollectionofWheels> CollectionofWheel
        {
            get { return m_CollectionofWheel; }
        }


        public float PercentageOfEnergyRemainingInItsEnergysource
        {
            get { return m_PercentageOfEnergyRemainingInItsEnergysource; }
            set { m_PercentageOfEnergyRemainingInItsEnergysource = value; }
        }


        public string ModelName
        {
            get { return m_ModelName; }
        }


        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }


        private void createVehicleWheels(int i_NumberOfWheelsInVehicles, string i_WheelManufacturerName, float i_CurrentAirPressur, float i_VehiclesWheelsMaxAirPressure)
        {

            for (int i = 0; i < i_NumberOfWheelsInVehicles; i++)
            {

                m_CollectionofWheel.Add(new CollectionofWheels(i_WheelManufacturerName, i_CurrentAirPressur, i_VehiclesWheelsMaxAirPressure));
            }
        }


        public override string ToString()
        {
            string DataOfVehicles;

            DataOfVehicles = string.Format("Model Name: {0}{3}" +
               "LicenseNumber Number: {1}{3}" +
               "Percentage Of  Energy Remaining In Its Energysource: {2}%{3}", ModelName, LicenseNumber,
               PercentageOfEnergyRemainingInItsEnergysource.ToString(), Environment.NewLine);

            return DataOfVehicles + CollectionofWheel[0].ToString();
        }





    }
}
