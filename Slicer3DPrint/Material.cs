using System;
using System.Collections.Generic;
using System.Text;

namespace Slicer.CORE
{
    public class Material 
    {
        #region CONSTRUCTORS

        public Material()
        {

        }

        public Material(double initYieldStress, double structRate, double density)
        {
            InitialYieldStress = initYieldStress;
            StructurationRate = structRate;
            Density = density;
        }
        #endregion

        #region PROPERTIES

        public double InitialYieldStress { get; set; }

        public double StructurationRate { get; set; }

        public double Density { get; set; }
               

        public Material Clone()
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
