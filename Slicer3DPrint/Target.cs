using System;
using System.Collections.Generic;
using System.Text;

using Rhino.Geometry;

namespace Slicer.CORE
{
    public class Target
    {
        #region CONSTRUCTORS
        public Target()
        {

        }

        public Target(Point3d point)
        {
            Position = point;
        } 
        #endregion

        #region PROPERTIES
        public Point3d Position { get; set; }

        public double H_ { get; set; }

        public double V_ { get; set; }

        public double B_ { get; set; } 

        public double omega { get; set; }

        public double tau { get; set; }
        #endregion


    }
}
