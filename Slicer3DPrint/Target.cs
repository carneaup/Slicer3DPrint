using System;
using System.Collections.Generic;
using System.Text;

using Rhino.Geometry;

namespace Slicer.CORE
{
    public class Target
    {
        public Target()
        {

        }

        public Target(Point3d point)
        {
            Position = point;
        }

        public Point3d Position { get; set; }

        public double H_ {get; set;}

        public double V_ { get; set; }

        public double B_ { get; set; }


    }
}
