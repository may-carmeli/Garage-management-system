using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{

    public abstract class VehicleEnergy
    {
        private readonly float r_MaximumEnergy;
        private float m_RemainingEnergy;

        public VehicleEnergy(float i_MaximumEnergy, float i_RemainingEnergy)
        {
            r_MaximumEnergy = i_MaximumEnergy;
            RemainingEnergy = i_RemainingEnergy;
        }


        public void AddEnergy(float i_AddEnergy)
        {
            if (MaximumEnergy - RemainingEnergy < i_AddEnergy)
            {

                throw new ValueOutOfRangeException(MaximumEnergy - RemainingEnergy, 0);
            }
            m_RemainingEnergy += i_AddEnergy;

        }


        public float RemainingEnergy
        {
            get { return m_RemainingEnergy; }
            set { m_RemainingEnergy = value; }
        }


        public float MaximumEnergy
        {
            get { return r_MaximumEnergy; }
        }

    }

}
