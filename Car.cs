using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic

{

    public abstract class Car : Vehicles
    {

        public enum eColor { Red, White, Silver, Black };
        private readonly eColor r_ColorOfCar;
        private readonly int r_AmountOfDoors;
        private const int k_NumberOfWheelsInCar = 4;
        private const float k_CarWheelsMaxAirPressure = 32;

        public Car(int i_AmountOfDoors, eColor i_ColorOfCar
            , string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, String i_WheelManufacturerName, float i_CurrentAirPressur, VehicleEnergy i_VehicleEnergy)
            : base(i_ModelName, i_LicenseNumber, i_PercentageOfEnergyRemainingInItsEnergysource,
            k_NumberOfWheelsInCar, k_CarWheelsMaxAirPressure, i_WheelManufacturerName, i_CurrentAirPressur, i_VehicleEnergy)
        {
            r_ColorOfCar = i_ColorOfCar;
            r_AmountOfDoors = i_AmountOfDoors;
        }

        public static float CarWheelsMaxAirPressure
        {
            get { return k_CarWheelsMaxAirPressure; }
        }

        public eColor ColorOfCar
        {
            get { return r_ColorOfCar; }
        }

        public int AmountOfDoors
        {
            get { return r_AmountOfDoors; }

        }
        public int NumberOfWheelsInCar
        {
            get { return k_NumberOfWheelsInCar; }
        }

        public override string ToString()
        {
            string DataOfElectroniCar;

            DataOfElectroniCar = string.Format("Color Of Car: {0}{3}" +
                "Amount Of Doors: {1}{3}" +
                "Number Of Wheels In Car: {2}{3}", ColorOfCar.ToString(), AmountOfDoors.ToString(),
                k_NumberOfWheelsInCar.ToString(), Environment.NewLine);

            return DataOfElectroniCar + base.ToString();
        }

    }
}
