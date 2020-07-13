using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class CollectionofWheels
    {

        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressur;
        private readonly float r_ManufacturerMaximumPressure;

        public CollectionofWheels(string i_ManufacturerName, float i_CurrentAirPressur, float i_ManufacturerMaximumPressure)
        {
            r_ManufacturerName = i_ManufacturerName;
            CurrentAirPressur = i_CurrentAirPressur;
            r_ManufacturerMaximumPressure = i_ManufacturerMaximumPressure;
        }


        public void WeightingOperation(float i_AmountOfAirToAddToTheWheel)
        {
            if (i_AmountOfAirToAddToTheWheel + CurrentAirPressur > ManufacturerMaximumPressure || i_AmountOfAirToAddToTheWheel < 0)
            {
                throw new ValueOutOfRangeException(ManufacturerMaximumPressure - CurrentAirPressur, 0);
            }

            CurrentAirPressur = CurrentAirPressur + i_AmountOfAirToAddToTheWheel;
        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }


        public float CurrentAirPressur
        {
            get { return m_CurrentAirPressur; }
            set { m_CurrentAirPressur = value; }
        }


        public float ManufacturerMaximumPressure
        {
            get { return r_ManufacturerMaximumPressure; }
        }


        public void inflateWheelToMax()
        {
            float SomeAirToAddToWheels = ManufacturerMaximumPressure - CurrentAirPressur;
            WeightingOperation(SomeAirToAddToWheels);
        }


        public override string ToString()
        {
            string DataOfCollectionofWheels;

            DataOfCollectionofWheels = string.Format("Wheel Manufacturer Name: {0}{3}" +
                "Current air pressure in the wheels: {1}{3}" +
                "Maximum wheel pressure: {2}{3}"
               , ManufacturerName, CurrentAirPressur.ToString(), ManufacturerMaximumPressure.ToString(),
                 Environment.NewLine);

            return DataOfCollectionofWheels;

        }

    }
}
