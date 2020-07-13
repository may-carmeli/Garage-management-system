using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ComsoleUI

{
    public class UserInterface
    {
        private static Garage ObjectOfGarage = new Garage();
        public enum eTypeOfVehicles
        {
            GasCar,
            ElectricCar,
            GasMotorcycle,
            ElectricMotorsycle,
            TruckGas
        };


        public enum eMenuOption
        {
            AddVehicle,
            DisplayLicenseNumbers,
            DisplayFilteredLicenseNumbers,
            ModifyVehicleStatus,
            InflateVehicleWheels,
            RefuelGasolineVehicle,
            ChargeElectricVehicle,
            DisplayVehicleDetails,
            QuitProgram
        }




        private const string k_TextMain = @"Please choose from the following options (1-9):
        1. Add a new vehicle to garage.
        2. Display license plate numbers for all vehicles in the garage.
        3. Display license numbers for vehicles filtered by garage status.
        4. Modify a vehicle's status.
        5. Inflate a vehicle's wheels to maximum.
        6. Refuel a gasoline-powered vehicle.
        7. Charge an electric vehicle.
        8. Display full details of a vehicle.
        9. Quit.
        ";


        public static void Run()
        {
            string TheException = "";
            string InputYourChoice = "";
            int userMenuSelection;

            while (InputYourChoice.Equals("9") == false)
            {
                try
                {
                    showInitialMenu();
                    Console.WriteLine();

                    InputYourChoice = Console.ReadLine();
                    userMenuSelection = parseUserSelection(InputYourChoice, Enum.GetNames(typeof(eMenuOption)).Length);
                    MenuSelection(userMenuSelection);

                    Console.WriteLine("{0}press enter to continue...", Environment.NewLine);

                    Console.ReadLine();
                }

                catch (ValueOutOfRangeException Exception)
                {
                    TheException = string.Format("Error: Values not in range, the rang is : {0} - {1}",
                         Exception.MinValue,
                         Exception.MaxValue);
                    Console.WriteLine(TheException);

                }


                catch (VehicleNotFoundException Exception)
                {
                    TheException = string.Format("Error: The vehicle whose license number is {0} not found ",
                      Exception.LicenseNum);
                    Console.WriteLine(TheException);

                }


                catch (FormatException)
                {
                    Console.WriteLine("Error: The argument format is invalid");

                }


                catch (ArgumentException)
                {
                    Console.WriteLine("Error: The argument provided is not valid");

                }

            }
        }




        private static void showInitialMenu()
        {
            Console.WriteLine(k_TextMain);

        }


        private static int parseUserSelection(string i_InputTypeInString, int i_RangeOfCurrentEnum)
        {
            int UserChoice;

            if (int.TryParse(i_InputTypeInString, out UserChoice) == false)
            {
                {
                    throw new FormatException();
                }
            }

            if (UserChoice < 1 || UserChoice > i_RangeOfCurrentEnum)
            {
                throw new ValueOutOfRangeException(i_RangeOfCurrentEnum, 1);
            }

            return UserChoice;
        }



        private static void addVehicleToGarage()
        {
            string ownerName;
            string ownerPhone;
            bool vehicleIsAlreadyInGarage = false;
            Vehicles vehicleToAdd;

            vehicleToAdd = AddNewVehicleFromUser();

            Console.WriteLine("please enter Name of vehicle owner");

            ownerName = Console.ReadLine();

            Console.WriteLine("please enter phone of vehicle owner");

            ownerPhone = Console.ReadLine();

            vehicleIsAlreadyInGarage = ObjectOfGarage.AddVehicleToGarage(vehicleToAdd, ownerPhone, ownerName);

            if (vehicleIsAlreadyInGarage == true)
            {
                Console.WriteLine(string.Format("{0}" +
                     "There is already found in the garage,{0}"
                    + "Changing status to in-progress",
                    Environment.NewLine));
            }

            else
            {
                Console.WriteLine("Vehicle was added succesfully");

            }

        }



        private static Vehicles AddNewVehicleFromUser()
        {
            eTypeOfVehicles TypeOfVehicles;
            Vehicles NewVehicles = null;

            TypeOfVehicles = ChooseTypeOfVehicles();

            switch (TypeOfVehicles)
            {
                case eTypeOfVehicles.GasCar:
                    NewVehicles = CreateGasCarObject();
                    break;

                case eTypeOfVehicles.ElectricCar:
                    NewVehicles = CreateElectricCarObject();
                    break;

                case eTypeOfVehicles.GasMotorcycle:
                    NewVehicles = CreateGasMotorcycleObject();
                    break;

                case eTypeOfVehicles.ElectricMotorsycle:
                    NewVehicles = CreateElectricMotorsycleObject();
                    break;

                case eTypeOfVehicles.TruckGas:
                    NewVehicles = CreateGasTruckObject();
                    break;

                default:
                    break;
            }

            return NewVehicles;
        }


        private static void GetNewVehiclePharameter(ref string io_LicenseNumber, ref string io_ModelName, ref float io_ToFloatPercentageOfEnergyRemainingInItsEnergysource,
            ref float io_CurrentAirPressur, ref string io_WheelManufacturerName)
        {
            string PercentageOfEnergyRemainingInItsEnergysource, CurrentAirPressur;

            Console.WriteLine("please enter License Number");

            io_LicenseNumber = Console.ReadLine();

            Console.WriteLine("please enter Model Name:");
            io_ModelName = Console.ReadLine();


            Console.WriteLine("please enter Percentage Of Energy Remaining In Its Energysource :");

            PercentageOfEnergyRemainingInItsEnergysource = Console.ReadLine();

            if (!float.TryParse(PercentageOfEnergyRemainingInItsEnergysource, out io_ToFloatPercentageOfEnergyRemainingInItsEnergysource))
            {
                throw new FormatException();
            }

            else if (io_ToFloatPercentageOfEnergyRemainingInItsEnergysource < 0 || io_ToFloatPercentageOfEnergyRemainingInItsEnergysource > 100)
            {
                throw new ValueOutOfRangeException(100, 0);
            }

            Console.WriteLine("please enter Wheel Manufacturer Name ");

            io_WheelManufacturerName = Console.ReadLine();

            Console.WriteLine("please enter Current Air Pressur in wheels ");

            CurrentAirPressur = Console.ReadLine();

            if (!float.TryParse(CurrentAirPressur, out io_CurrentAirPressur))
            {
                throw new FormatException();
            }

        }


        private static void GetElectricVehiclesPharameter(ref float io_BatteryTimeremainingInhours)
        {

            string BatteryTimeremainingInhours;

            Console.WriteLine("please enter Battery Timer emaining In hours");

            BatteryTimeremainingInhours = Console.ReadLine();

            if (!float.TryParse(BatteryTimeremainingInhours, out io_BatteryTimeremainingInhours))
            {
                throw new FormatException();
            }

        }


        private static void GetGasVehiclesPharameter(ref float io_FuelPresentInLiters)
        {
            string AmountOfFuelPresentInLiters = "";

            Console.WriteLine("please enter Amount Of Fuel Present In Liters ");

            AmountOfFuelPresentInLiters = Console.ReadLine();
            float.TryParse(AmountOfFuelPresentInLiters, out io_FuelPresentInLiters);

        }


        private static void GetMotorcyclePharameter(ref int io_EngineVolumeInCc, ref Motorcycle.eLicenseType io_LicenseType)//קליטת פרמטרים לאופנוע
        {
            string EngineVolumeInCc;
            Motorcycle.eLicenseType LicenseType;
            LicenseType = ChooseLicenseType();

            Console.WriteLine("Please enter Engine Volume In Cc");

            EngineVolumeInCc = Console.ReadLine();

            if (!int.TryParse(EngineVolumeInCc, out io_EngineVolumeInCc))
            {
                throw new FormatException();
            }

        }


        private static void GetCarPharameter(ref Car.eColor io_ColorOfVehicles, ref int io_AmountOfDoors)//קליטת פרמטרים למכונית-v
        {
            string AmountOfDoors;
            io_ColorOfVehicles = SelectColorOfVehicles();

            Console.WriteLine("please enter Amount Of Doors");

            AmountOfDoors = Console.ReadLine();

            if (!int.TryParse(AmountOfDoors, out io_AmountOfDoors))
            {
                throw new FormatException();
            }

            else if (io_AmountOfDoors < 2 || io_AmountOfDoors > 5)
            {
                throw new ValueOutOfRangeException(5, 2);
            }

        }


        private static void GetGasTruckPharameter(ref bool io_IsTransportingDangerousSubstances, ref float io_Cargovolume)
        {
            string IsTransportingDangerousSubstances, Cargovolume;

            Console.WriteLine("Is Transporting Dangerous Substances?" +
                "1.yes" +
                "2.no");

            IsTransportingDangerousSubstances = Console.ReadLine();

            if (IsTransportingDangerousSubstances.Equals("1"))
            {
                io_IsTransportingDangerousSubstances = true;
            }

            else if (IsTransportingDangerousSubstances.Equals("2"))
            {
                io_IsTransportingDangerousSubstances = false;
            }

            else
            {
                throw new FormatException();
            }

            Console.WriteLine("Please enter Cargo volume");

            Cargovolume = Console.ReadLine();
            if (!float.TryParse(Cargovolume, out io_Cargovolume))
            {
                throw new FormatException();
            }


        }


        public static Vehicles CreateGasTruckObject()
        {
            float Cargovolume = 0, PercentageOfEnergyRemainingInItsEnergysource = 0, CurrentAirPressur = 0, FuelPresentInLiters = 0;
            string LicenseNumber = "", ModelName = "", WheelManufacturerName = "";
            bool IsTransportingDangerousSubstances = false;
            Vehicles NewTruckGas;

            GetNewVehiclePharameter(ref LicenseNumber, ref ModelName, ref PercentageOfEnergyRemainingInItsEnergysource, ref CurrentAirPressur, ref WheelManufacturerName);

            if (CurrentAirPressur > TruckGas.CarWheelsMaxAirPressure || CurrentAirPressur < 0)
            {
                throw new ValueOutOfRangeException(TruckGas.CarWheelsMaxAirPressure, 0);
            }

            GetGasVehiclesPharameter(ref FuelPresentInLiters);
            if (FuelPresentInLiters > TruckGas.MaximumAmountOfFuelInLiters || FuelPresentInLiters < 0)
            {
                throw new ValueOutOfRangeException(TruckGas.MaximumAmountOfFuelInLiters, 0);
            }

            GetGasTruckPharameter(ref IsTransportingDangerousSubstances, ref Cargovolume);
            NewTruckGas = CreatNewObject.CreatGasTruc(FuelPresentInLiters, ModelName, LicenseNumber, PercentageOfEnergyRemainingInItsEnergysource,
             WheelManufacturerName, CurrentAirPressur, IsTransportingDangerousSubstances, Cargovolume);

            return NewTruckGas;

        }


        public static Vehicles CreateElectricMotorsycleObject()
        {
            float PercentageOfEnergyRemainingInItsEnergysource = 0, CurrentAirPressur = 0, BatteryTimeremainingInhours = 0;
            string LicenseNumber = "", ModelName = "", WheelManufacturerName = "";
            Motorcycle.eLicenseType LicenseType = 0;
            int EngineVolumeInCc = 0;
            Vehicles NewElectricMotorcycel;

            GetNewVehiclePharameter(ref LicenseNumber, ref ModelName, ref PercentageOfEnergyRemainingInItsEnergysource, ref CurrentAirPressur, ref WheelManufacturerName);

            if (CurrentAirPressur > Motorcycle.MotorcycleWheelsMaxAirPressure || CurrentAirPressur < 0)
            {
                throw new ValueOutOfRangeException(Motorcycle.MotorcycleWheelsMaxAirPressure, 0);
            }

            GetMotorcyclePharameter(ref EngineVolumeInCc, ref LicenseType);
            GetElectricVehiclesPharameter(ref BatteryTimeremainingInhours);

            if (BatteryTimeremainingInhours > ElectricMotorcycel.MaximumBatteryInHours || BatteryTimeremainingInhours < 0)
            {
                throw new ValueOutOfRangeException(ElectricMotorcycel.MaximumBatteryInHours, 0);
            }

            NewElectricMotorcycel = CreatNewObject.CreatElectricMotorcycel(LicenseType, BatteryTimeremainingInhours, EngineVolumeInCc, ModelName, LicenseNumber,
           PercentageOfEnergyRemainingInItsEnergysource, WheelManufacturerName, CurrentAirPressur);

            return NewElectricMotorcycel;
        }


        private static Vehicles CreateGasCarObject()
        {

            float PercentageOfEnergyRemainingInItsEnergysource = 0, FuelPresentInLiters = 0, CurrentAirPressur = 0;
            string LicenseNumber = "", ModelName = "", WheelManufacturerName = "";
            Car.eColor ColorOfCar = 0;
            int AmountOfDoors = 0;
            Vehicles NewGasCar;

            GetNewVehiclePharameter(ref LicenseNumber, ref ModelName, ref PercentageOfEnergyRemainingInItsEnergysource, ref CurrentAirPressur, ref WheelManufacturerName);
            if (CurrentAirPressur > Car.CarWheelsMaxAirPressure || CurrentAirPressur < 0)
            {
                throw new ValueOutOfRangeException(Car.CarWheelsMaxAirPressure, 0);
            }

            GetGasVehiclesPharameter(ref FuelPresentInLiters);

            if (FuelPresentInLiters > CarWorkingOnGas.MaximumAmountOfFuelInLiters || FuelPresentInLiters < 0)
            {
                throw new ValueOutOfRangeException(CarWorkingOnGas.MaximumAmountOfFuelInLiters, 0);
            }

            GetCarPharameter(ref ColorOfCar, ref AmountOfDoors);
            NewGasCar = CreatNewObject.CreatGasCar(AmountOfDoors, FuelPresentInLiters, ColorOfCar
           , ModelName, LicenseNumber,
           PercentageOfEnergyRemainingInItsEnergysource, CurrentAirPressur, WheelManufacturerName);

            return NewGasCar;


        }
        private static Vehicles CreateGasMotorcycleObject()
        {
            float PercentageOfEnergyRemainingInItsEnergysource = 0, FuelPresentInLiters = 0, CurrentAirPressur = 0;
            string LicenseNumber = "", ModelName = "", WheelManufacturerName = "";
            Motorcycle.eLicenseType LicenseType = 0;
            int EngineVolumeInCc = 0;
            Vehicles NewGasMotorcycel;

            GetNewVehiclePharameter(ref LicenseNumber, ref ModelName,
                 ref PercentageOfEnergyRemainingInItsEnergysource, ref CurrentAirPressur, ref WheelManufacturerName);

            if (CurrentAirPressur > Motorcycle.MotorcycleWheelsMaxAirPressure || CurrentAirPressur < 0)
            {
                throw new ValueOutOfRangeException(Motorcycle.MotorcycleWheelsMaxAirPressure, 0);
            }

            GetGasVehiclesPharameter(ref FuelPresentInLiters);

            if (FuelPresentInLiters > MotorcycelWorkingOnGas.MaximumAmountOfFuelInLiters || FuelPresentInLiters < 0)
            {
                throw new ValueOutOfRangeException(MotorcycelWorkingOnGas.MaximumAmountOfFuelInLiters, 0);
            }

            GetMotorcyclePharameter(ref EngineVolumeInCc, ref LicenseType);

            NewGasMotorcycel = CreatNewObject.CreatGasMotorcycel(FuelPresentInLiters, LicenseType, EngineVolumeInCc, ModelName, LicenseNumber,
           PercentageOfEnergyRemainingInItsEnergysource, WheelManufacturerName, CurrentAirPressur);

            return NewGasMotorcycel;

        }
        private static Vehicles CreateElectricCarObject()
        {
            float PercentageOfEnergyRemainingInItsEnergysource = 0, BatteryTimeremainingInhours = 0, CurrentAirPressur = 0;
            string LicenseNumber = "", ModelName = "", WheelManufacturerName = "";
            int AmountOfDoors = 0;
            Car.eColor ColorOfCar = 0;
            Vehicles NewElectricCarObject;

            GetNewVehiclePharameter(ref LicenseNumber, ref ModelName,
                 ref PercentageOfEnergyRemainingInItsEnergysource, ref CurrentAirPressur, ref WheelManufacturerName);

            if (CurrentAirPressur > Car.CarWheelsMaxAirPressure || CurrentAirPressur < 0)
            {
                throw new ValueOutOfRangeException(Car.CarWheelsMaxAirPressure, 0);
            }

            GetCarPharameter(ref ColorOfCar, ref AmountOfDoors);

            GetElectricVehiclesPharameter(ref BatteryTimeremainingInhours);

            if (BatteryTimeremainingInhours > ElectricCar.MaximumBatteryInHours || BatteryTimeremainingInhours < 0)
            {
                throw new ValueOutOfRangeException(ElectricCar.MaximumBatteryInHours, 0);
            }

            NewElectricCarObject = CreatNewObject.CreatElectricCar(AmountOfDoors, BatteryTimeremainingInhours, ColorOfCar
           , ModelName, LicenseNumber,
           PercentageOfEnergyRemainingInItsEnergysource, CurrentAirPressur, WheelManufacturerName);

            return NewElectricCarObject;
        }

        private static void ViewAllGarageLicenseNumbers()
        {
            List<string> licenseNumber = ObjectOfGarage.GetLicenseNumbers();

            if (licenseNumber.Count <= 0)
            {
                Console.WriteLine("There are no vehicles in the garage");

            }

            else
            {
                foreach (string CurrentLicenseNumber in licenseNumber)
                {
                    Console.WriteLine(CurrentLicenseNumber);
                }
            }
        }

        private static void ModifyVehicleState()
        {
            string LicenseNumber;
            NewVehiclesInTheGarage.eVehicleConditionIngarage NewVehicleState;

            Console.WriteLine("Please enter licence number");

            LicenseNumber = Console.ReadLine();

            NewVehicleState = SelectVehicleRepairMode();

            ObjectOfGarage.ChangeExistingVehicleState(LicenseNumber, NewVehicleState);

            Console.WriteLine("Vehicle state changed successfully");

        }


        private static void DisplayFilteredLicenseNumbers()
        {

            NewVehiclesInTheGarage.eVehicleConditionIngarage choiceOfehVicleMode = SelectVehicleRepairMode();
            List<string> licenseNumber = ObjectOfGarage.GetLicenseNumbers(choiceOfehVicleMode);

            if (licenseNumber.Count == 0)
            {
                Console.WriteLine("There are no vehicles in the garage as per this filter");

            }

            else
            {
                foreach (string CurrentLicenseNumber in licenseNumber)
                {
                    Console.WriteLine(CurrentLicenseNumber);
                }
            }
        }


        private static Motorcycle.eLicenseType ChooseLicenseType()
        {
            Motorcycle.eLicenseType LicenseType;
            int choiceOfLicenseType;
            string InputTypesOfLicense;
            string TypesOfLicense;

            TypesOfLicense = @"please enter License Type:
                1. A
                2. A1
                3. AA
                4. B";
            Console.WriteLine(TypesOfLicense);

            InputTypesOfLicense = Console.ReadLine();

            choiceOfLicenseType = parseUserSelection(InputTypesOfLicense, Enum.GetNames(typeof(Motorcycle.eLicenseType)).Length);

            LicenseType = (Motorcycle.eLicenseType)Enum.GetValues(typeof(Motorcycle.eLicenseType)).GetValue(choiceOfLicenseType - 1);

            return LicenseType;

        }

        private static eTypeOfVehicles ChooseTypeOfVehicles()
        {
            eTypeOfVehicles TypeOfVehicles;
            int choiceOfehVicleType;
            string TypesOfVehicles;

            TypesOfVehicles = @"please enter type of vehicles:
                1. gas car
                2. electric car
                3. gas motorcycle
                4. electric motorsycle
                5 truck gas";

            Console.WriteLine(TypesOfVehicles);

            string InputTypesOfVehicles = Console.ReadLine();

            choiceOfehVicleType = parseUserSelection(InputTypesOfVehicles, Enum.GetNames(typeof(eTypeOfVehicles)).Length);

            TypeOfVehicles = (eTypeOfVehicles)Enum.GetValues(typeof(eTypeOfVehicles)).GetValue(choiceOfehVicleType - 1);

            return TypeOfVehicles;

        }

        private static FuelEnergy.eTypeOfFuel SelectFuelType()
        {
            FuelEnergy.eTypeOfFuel TypeOfFuel;
            int choiceOfehVicleType;
            string TypeOfFuels;

            TypeOfFuels = @"please enter type of Fuel:
                1. Soler
                2. Occtan05
                3. Occtan96
                4. Occtan98 ";

            Console.WriteLine(TypeOfFuels);

            string inputAsString = Console.ReadLine();

            choiceOfehVicleType = parseUserSelection(inputAsString, Enum.GetNames(typeof(FuelEnergy.eTypeOfFuel)).Length);

            TypeOfFuel = (FuelEnergy.eTypeOfFuel)Enum.GetValues(typeof(FuelEnergy.eTypeOfFuel)).GetValue(choiceOfehVicleType - 1);

            return TypeOfFuel;

        }



        private static Car.eColor SelectColorOfVehicles()
        {
            Car.eColor ColorOfVehicles;
            int choiceOfVehicleColor;
            string TypeOfColors;

            TypeOfColors = @"please enter color of vehicles:
                1. Red
                2. White
                3. Silver
                4. Black ";

            Console.WriteLine(TypeOfColors);

            string inputTypeOfColors = Console.ReadLine();

            choiceOfVehicleColor = parseUserSelection(inputTypeOfColors, Enum.GetNames(typeof(Car.eColor)).Length);

            ColorOfVehicles = (Car.eColor)Enum.GetValues(typeof(Car.eColor)).GetValue(choiceOfVehicleColor - 1);

            return ColorOfVehicles;

        }

        private static NewVehiclesInTheGarage.eVehicleConditionIngarage SelectVehicleRepairMode()
        {

            NewVehiclesInTheGarage.eVehicleConditionIngarage choiceOfehVicleMode;
            int IntchoiceOfehVicleMode;
            string ModesOfVehicles;

            ModesOfVehicles = @"Choose a mode of the vehicle you want:
                1. InRepair 
                2. Repaired
                3. Paid";

            Console.WriteLine(ModesOfVehicles);

            string inputAsString = Console.ReadLine();

            IntchoiceOfehVicleMode = parseUserSelection(inputAsString, Enum.GetNames(typeof(NewVehiclesInTheGarage.eVehicleConditionIngarage)).Length);

            choiceOfehVicleMode = (NewVehiclesInTheGarage.eVehicleConditionIngarage)Enum.GetValues(typeof(NewVehiclesInTheGarage.eVehicleConditionIngarage)).GetValue(IntchoiceOfehVicleMode - 1);

            return choiceOfehVicleMode;


        }

        private static CollectionofWheels DateilfOfWheel()
        {

            float ManufacturerMaximumPressureOfCar, CurrentAirPressurOfCar;
            string ManufactUrerName, CurrentAirPressur, ManufacturerMaximumPressure;

            Console.WriteLine("Manufact UrerName:");

            ManufactUrerName = Console.ReadLine();

            Console.WriteLine(" Current Air Pressur:");

            CurrentAirPressur = Console.ReadLine();

            Console.WriteLine("Manufact Urer Maximum Pressure :");

            ManufacturerMaximumPressure = Console.ReadLine();

            float.TryParse(ManufacturerMaximumPressure, out ManufacturerMaximumPressureOfCar);

            float.TryParse(CurrentAirPressur, out CurrentAirPressurOfCar);

            CollectionofWheels NewCollectionofWheels = new CollectionofWheels(ManufactUrerName, CurrentAirPressurOfCar, ManufacturerMaximumPressureOfCar);

            return NewCollectionofWheels;
        }


        private static void ViewFullVehicleData()
        {
            string LicenseNumber;

            Console.WriteLine("please enter license number");

            LicenseNumber = Console.ReadLine();

            Console.WriteLine(ObjectOfGarage.GetVehicleData(LicenseNumber));

        }


        public static void InflateVehicleWheels()
        {
            string LicenseNumber;

            Console.WriteLine("Please enter licence number");

            LicenseNumber = Console.ReadLine();

            ObjectOfGarage.InflateVehicleWheelsToMax(LicenseNumber);

            Console.WriteLine("Blowing the wheels to maximum succeeded");
        }


        public static void AddGasToVehicle()
        {

            float gasAmountToAdd;
            string gasAmountAsString;

            Console.WriteLine("Please enter licence number");

            string license = Console.ReadLine();

            Console.WriteLine("Please insert a few liters of fuel to fill: ");

            gasAmountAsString = Console.ReadLine();

            FuelEnergy.eTypeOfFuel ChoiceOfFuelType = SelectFuelType();

            if (!float.TryParse(gasAmountAsString, out gasAmountToAdd))
            {
                throw new FormatException();
            }

            ObjectOfGarage.AddFulToVehicle(license, gasAmountToAdd, ChoiceOfFuelType);

            Console.WriteLine("The fuel refill succeeded");

        }


        public static void ChargeElectricVehicle()
        {

            string LicenseNumber, AddMinutesToBatteryInString;
            float AddMinutesToBattery;

            Console.WriteLine("please enter License Number ");

            LicenseNumber = Console.ReadLine();

            Console.WriteLine("How many minutes to recharge?");

            AddMinutesToBatteryInString = Console.ReadLine();

            if (float.TryParse(AddMinutesToBatteryInString, out AddMinutesToBattery) == false)
            {
                throw new FormatException();
            }

            ObjectOfGarage.LoadingVehicle(LicenseNumber, AddMinutesToBattery);

            Console.WriteLine("The vehicle's claim was successful");

        }


        private static void MenuSelection(int userMenuSelection)
        {

            if (userMenuSelection == 1)
            {
                addVehicleToGarage();
            }

            else if (userMenuSelection == 2)
            {
                ViewAllGarageLicenseNumbers();
            }

            else if (userMenuSelection == 3)
            {
                DisplayFilteredLicenseNumbers();
            }

            else if (userMenuSelection == 4)
            {
                ModifyVehicleState();
            }

            else if (userMenuSelection == 5)
            {
                InflateVehicleWheels();
            }

            else if (userMenuSelection == 6)
            {
                AddGasToVehicle();
            }

            else if (userMenuSelection == 7)
            {
                ChargeElectricVehicle();
            }

            else if (userMenuSelection == 8)
            {
                ViewFullVehicleData();
            }

            else if (userMenuSelection == 9)
            {
                Environment.Exit(0);
            }

        }

    }

}