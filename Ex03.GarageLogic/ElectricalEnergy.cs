using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricalEnergy : VehicleEnergy
    {

        public ElectricalEnergy(float i_MaximumAmountOfElectricInMinutes, float i_AmountOfElectriclPresentMinutes) :
            base(i_MaximumAmountOfElectricInMinutes, i_AmountOfElectriclPresentMinutes)
        {

        }

        public void BatteryCharging(float i_AddHoursToBattery)
        {

            float AddMinutesToBattery = i_AddHoursToBattery * 60;
            AddEnergy(AddMinutesToBattery);

        }
    }
}
