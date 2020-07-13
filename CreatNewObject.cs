using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public static class CreatNewObject
    {

        public static Vehicles CreatGasTruc(float i_FuelPresentInLiters, string i_ModelName, string i_LicenseNumber, float i_PercentageOfEnergyRemainingInItsEnergysource,
             string i_WheelManufacturerName, float i_CurrentAirPressur, bool i_IsTransportingDangerousSubstances, float i_Cargovolume)
        {
            TruckGas NewTruckGas = new TruckGas(i_FuelPresentInLiters, i_ModelName, i_LicenseNumber, i_PercentageOfEnergyRemainingInItsEnergysource,
            i_WheelManufacturerName, i_CurrentAirPressur, i_IsTransportingDangerousSubstances, i_Cargovolume);
            return NewTruckGas;
        }


        public static Vehicles CreatElectricCar(int i_AmountOfDoors, float i_BatteryTimeremainingInhours, Car.eColor i_ColorOfCar
           , string i_ModelName, string i_LicenseNumber,
           float i_PercentageOfEnergyRemainingInItsEnergysource, float i_CurrentAirPressur, String i_WheelManufacturerName)
        {

            ElectricCar NewElectricCar = new ElectricCar(i_AmountOfDoors, i_BatteryTimeremainingInhours, i_ColorOfCar
            , i_ModelName, i_LicenseNumber,
             i_PercentageOfEnergyRemainingInItsEnergysource, i_CurrentAirPressur, i_WheelManufacturerName);

            return NewElectricCar;

        }


        public static Vehicles CreatElectricMotorcycel(Motorcycle.eLicenseType i_LicenseType, float i_BatteryTimeremainingInhours, int i_EngineVolumeInCc, string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, string i_WheelManufacturerName, float i_CurrentAirPressur)
        {

            ElectricMotorcycel NewElectricMotorcycel = new ElectricMotorcycel(i_LicenseType, i_BatteryTimeremainingInhours, i_EngineVolumeInCc, i_ModelName, i_LicenseNumber,
             i_PercentageOfEnergyRemainingInItsEnergysource, i_WheelManufacturerName, i_CurrentAirPressur);
            return NewElectricMotorcycel;
        }

        public static Vehicles CreatGasMotorcycel(float i_AmountOfFuelPresentInLiters, Motorcycle.eLicenseType i_LicenseType, int i_EngineVolumeInCc, string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, string i_WheelManufacturerName, float i_CurrentAirPressur)
        {

            MotorcycelWorkingOnGas CreatMotorcycelWorkingOnGas = new MotorcycelWorkingOnGas(i_AmountOfFuelPresentInLiters, i_LicenseType, i_EngineVolumeInCc, i_ModelName, i_LicenseNumber,
             i_PercentageOfEnergyRemainingInItsEnergysource, i_WheelManufacturerName, i_CurrentAirPressur);
            return CreatMotorcycelWorkingOnGas;

        }

        public static Vehicles CreatGasCar(int i_AmountOfDoors, float i_AmountOfFuelPresentInLiters, Car.eColor i_ColorOfCar
            , string i_ModelName, string i_LicenseNumber,
            float i_PercentageOfEnergyRemainingInItsEnergysource, float i_CurrentAirPressur, String i_WheelManufacturerName)
        {

            CarWorkingOnGas CreatCarWorkingOnGas = new CarWorkingOnGas(i_AmountOfDoors, i_AmountOfFuelPresentInLiters, i_ColorOfCar
            , i_ModelName, i_LicenseNumber,
             i_PercentageOfEnergyRemainingInItsEnergysource, i_CurrentAirPressur, i_WheelManufacturerName);
            return CreatCarWorkingOnGas;
        }


    }
}
