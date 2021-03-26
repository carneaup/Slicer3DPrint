using System;
using System.Collections.Generic;
using System.Linq;

using Rhino.Geometry;

namespace Slicer.CORE
{
    public class Layer
    {
        #region CONSTRUCTOR
        public Layer(Curve curve, int m = 50)
        {
            Resolution = m;
            LayerCurve = curve;

            Point3d[] points = new Point3d[m];
            double[] nodeParameter = curve.DivideByCount(m, false, out points);

            Dictionary<Target, double> curveParameters = new Dictionary<Target, double>();

            for (int i = 0; i < points.Count(); i++)
            {
                Nodes[i] = new Target(points[i]);
                curveParameters.Add(Nodes[i], nodeParameter[i]);
            }

            CurveParameters = curveParameters;
        }
        #endregion

        #region PROPERTIES
        public int Resolution { get; set; }
        public Curve LayerCurve { get; set; }
        public Target[] Nodes { get; set; }

        public Dictionary<Target, double> CurveParameters { get; set; }

        public double Length
        {
            get
            {
                return LayerCurve.GetLength();
            }
        }

        public double A_ { get; set; }

        public double InterLayerTime { get; set; }
        #endregion

        public void EvaluateStructurationRatio()
        {
            foreach(Target t in Nodes)
            {
                double inverseVelocitySum = Nodes.Select(i => 1 / i.V_).Sum();
            }
        }
    }



}
