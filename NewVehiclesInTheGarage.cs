using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{


    public class NewVehiclesInTheGarage
    {
        private Vehicles m_Vehicle;
        private string m_OwnerName;
        private string m_PhoneOwner;
        private eVehicleConditionIngarage m_VehicleConditionIngarage;

        public enum eVehicleConditionIngarage
        {
            InRepair,
            Repaired,
            Paid
        }

        public NewVehiclesInTheGarage(Vehicles i_Vehicle, string i_OwnerName, string i_OwnerPhoneNum)
        {

            Vehicle = i_Vehicle;
            OwnerName = i_OwnerName;
            PhoneOwner = i_OwnerPhoneNum;
            Vehicle = i_Vehicle;
            VehicleConditionIngarage = eVehicleConditionIngarage.InRepair;
        }




        public override string ToString()
        {
            string DataOfElectroniCar;

            DataOfElectroniCar = string.Format(
                "Owner Name:{0}{3}Phone Owner :{1}{3}Vehicle Condition In garage:{2}{3} ",
                OwnerName, PhoneOwner, VehicleConditionIngarage.ToString(), Environment.NewLine);

            return DataOfElectroniCar + m_Vehicle.ToString();
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string PhoneOwner
        {
            get { return m_PhoneOwner; }
            set { m_PhoneOwner = value; }
        }

        public eVehicleConditionIngarage VehicleConditionIngarage
        {
            get { return m_VehicleConditionIngarage; }
            set { m_VehicleConditionIngarage = value; }
        }

        public Vehicles Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }


    }
}
