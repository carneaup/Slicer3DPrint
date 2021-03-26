using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slicer.CORE
{
    public class Model
    {
        #region CONSTRUCTORS
        public Model()
        { }

        public Model(List<Layer> layers, Material material, double nozzleDiameter, double width)
        {
            Layers = layers;
            MaterialProperties = material;
            Width = width;
            NozzleDiameter = nozzleDiameter;
        }
        #endregion

        #region PROPERTIES
        public Material MaterialProperties { get; set; }
        public List<Layer> Layers { get; set; }
        public double Width { get; set; }
        public double NozzleDiameter { get; set; }
        #endregion

        public void EvaluatePrintingVelocities()
        {
            foreach (Layer l in Layers)
            {
                foreach (Target t in l.Nodes)
                {
                    t.V_ = CalculateVelocity(t.H_, Width / NozzleDiameter);
                }
            }
        }

        internal double CalculateVelocity(double H_, double B_)
        {
            return 1 / (3.1415 * B_ * H_ / 4 - (4 / 3.1415 - 1) * H_ * H_);
        }
    }
}
