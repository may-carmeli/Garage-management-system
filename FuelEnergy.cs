using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEnergy : VehicleEnergy
    {
        public enum eTypeOfFuel { Soler, Occtan95, Occtan96, Occtan98 };
        public eTypeOfFuel m_TypeOfGas;

        public FuelEnergy(float i_MaximumAmountOfFuelInLiters, float i_AmountOfFuelPresentInLiters, eTypeOfFuel TypeOfFuel) :
    base(i_MaximumAmountOfFuelInLiters, i_AmountOfFuelPresentInLiters)
        {
            TypeOfGas = TypeOfFuel;
        }



        public eTypeOfFuel TypeOfGas
        {
            get { return m_TypeOfGas; }
            set { m_TypeOfGas = value; }
        }


        public void RefuelingOperation(float i_QuantityOfGallons, eTypeOfFuel i_TypeOfGas)

        {
            if (i_TypeOfGas != TypeOfGas)
            {
                throw new ArgumentException();
            }

            AddEnergy(i_QuantityOfGallons);
        }

    }
}
