using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public class Garage
    {
        private readonly Dictionary<string, NewVehiclesInTheGarage> r_DictOfGarageVehicles;

        public Dictionary<string, NewVehiclesInTheGarage> DictOfGarageVehicles
        {

            get { return r_DictOfGarageVehicles; }
        }


        public Garage()
        {

            r_DictOfGarageVehicles = new Dictionary<string, NewVehiclesInTheGarage>();
        }


        public bool AddVehicleToGarage(Vehicles i_Vehicle, string i_OwnerName, string i_OwnerPhoneNum)
        {
            bool vehicleExistsInGarage;

            vehicleExistsInGarage = r_DictOfGarageVehicles.ContainsKey(i_Vehicle.LicenseNumber);

            NewVehiclesInTheGarage vehicleInGarage;

            if (i_Vehicle == null)
            {
                throw new ArgumentNullException();
            }

            if (vehicleExistsInGarage == true)
            {
                ChangeExistingVehicleState(i_Vehicle.LicenseNumber, NewVehiclesInTheGarage.eVehicleConditionIngarage.InRepair);
            }

            else
            {
                vehicleInGarage = new NewVehiclesInTheGarage(i_Vehicle, i_OwnerName, i_OwnerPhoneNum);
                r_DictOfGarageVehicles.Add(i_Vehicle.LicenseNumber, vehicleInGarage);
            }

            return vehicleExistsInGarage;
        }


        public void ChangeExistingVehicleState(string i_LicenseNum, NewVehiclesInTheGarage.eVehicleConditionIngarage i_NewVehicleState)
        {
            NewVehiclesInTheGarage vehicleInGarage;

            vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);

            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            vehicleInGarage.VehicleConditionIngarage = i_NewVehicleState;
        }


        public NewVehiclesInTheGarage getVehicleFromDictionary(string i_LicenseNum)
        {
            bool vehicleExists;
            NewVehiclesInTheGarage garageVehicle = null;

            vehicleExists = r_DictOfGarageVehicles.TryGetValue(i_LicenseNum, out garageVehicle);

            if (vehicleExists == false)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            return garageVehicle;
        }


        public List<string> GetLicenseNumbers(NewVehiclesInTheGarage.eVehicleConditionIngarage i_StateInGarage)
        {
            List<string> LicenseNumbers = new List<string>();

            foreach (var VehicleInGarage in r_DictOfGarageVehicles)
            {
                if (VehicleInGarage.Value.VehicleConditionIngarage == i_StateInGarage)
                {
                    LicenseNumbers.Add(VehicleInGarage.Key);
                }
            }
            return LicenseNumbers;
        }


        public void LoadingVehicle(string i_LicenseNumber, float i_AddMinutesToBattery)
        {
            float i_AddHourToBattery;
            NewVehiclesInTheGarage VehicleData;

            i_AddHourToBattery = i_AddMinutesToBattery / 60;
            VehicleData = getVehicleFromDictionary(i_LicenseNumber);

            if (VehicleData == null)
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            if (!(VehicleData.Vehicle.VehicleEnergy is ElectricalEnergy))
            {

                throw new ArgumentException();

            }

          (VehicleData.Vehicle.VehicleEnergy as ElectricalEnergy).BatteryCharging(i_AddHourToBattery);

        }

        public List<string> GetLicenseNumbers()
        {
            List<string> licenseNums;

            licenseNums = new List<string>();

            foreach (string licenseNum in r_DictOfGarageVehicles.Keys)
            {
                licenseNums.Add(licenseNum);
            }

            return licenseNums;
        }

        public string GetVehicleData(string i_LicenseNumber)
        {
            NewVehiclesInTheGarage VehicleData = null;

            VehicleData = getVehicleFromDictionary(i_LicenseNumber);

            return VehicleData.ToString();
        }


        public void AddFulToVehicle(string i_LicenseNumber, float i_AmountOfGaslToFill, FuelEnergy.eTypeOfFuel i_TypeOfGas)
        {
            NewVehiclesInTheGarage VehicleInGarage;

            VehicleInGarage = getVehicleFromDictionary(i_LicenseNumber);

            if (VehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNumber);

            }

            if (!(VehicleInGarage.Vehicle.VehicleEnergy is FuelEnergy))
            {
                throw new ArgumentException();

            }

                (VehicleInGarage.Vehicle.VehicleEnergy as FuelEnergy).RefuelingOperation(i_AmountOfGaslToFill, i_TypeOfGas);

        }



        public void InflateVehicleWheelsToMax(string i_LicenseNum)
        {
            NewVehiclesInTheGarage vehicleInGarage;

            vehicleInGarage = getVehicleFromDictionary(i_LicenseNum);

            if (vehicleInGarage == null)
            {
                throw new VehicleNotFoundException(i_LicenseNum);
            }

            foreach (CollectionofWheels wheelOfvehicleInGarage in vehicleInGarage.Vehicle.CollectionofWheel)
            {

                wheelOfvehicleInGarage.inflateWheelToMax();
            }

        }
    }
}
