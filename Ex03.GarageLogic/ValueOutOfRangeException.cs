
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {

        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
        {
            this.r_MaxValue = i_MaxValue;
            this.r_MinValue = i_MinValue;
        }


        public float MaxValue
        {
            get { return r_MaxValue; }
        }


        public float MinValue
        {
            get { return r_MinValue; }
        }


    }
}
