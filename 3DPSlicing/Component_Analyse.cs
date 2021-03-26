using System;
using System.Collections.Generic;
using System.Linq;

using Grasshopper.Kernel;
using Rhino.Geometry;

using Slicer.CORE;



// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace Slicer.Components
{
    public class Analyse : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public Analyse()
          : base("3DPSlicing", "Slicer",
              "Slicer",
              "Slicer", "Input")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddCurveParameter("layers", "layers", "layers", GH_ParamAccess.list);
            pManager.AddIntegerParameter("resolution", "resolution", "resolution", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            List<Curve> curves = new List<Curve>();
            DA.GetDataList(0, curves);

            int N = curves.Count;

            List<Layer> layers = new List<Layer>();

            int m = 100;
            
            //Create layers
            foreach (Curve l in curves) layers.Add(new Layer(l));

            //Calculate the distance from each point to the previous layer
            for (int i = 1; i < N; i++)
            {
                foreach (Target p in layers[i].Nodes)
                {
                    Plane orthoPlane = new Plane(p.Position, layers[i].LayerCurve.TangentAt(layers[i].CurveParameters[p]));

                    Rhino.Geometry.Intersect.CurveIntersections layerPlane = Rhino.Geometry.Intersect.Intersection.CurvePlane(layers[i-1].LayerCurve, orthoPlane, 0.001);

                    double h = 1000;
                    foreach(Rhino.Geometry.Intersect.IntersectionEvent e in layerPlane)
                    {
                        if (e.PointA.DistanceTo(p.Position) < h) h = e.PointA.DistanceTo(p.Position);
                    }

                    p.H_ = h;                    
                }
            }

        }

        /// <summary>
        /// Provides an Icon for every component that will be visible in the User Interface.
        /// Icons need to be 24x24 pixels.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                // You can add image files to your project resources and access them like this:
                //return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Each component must have a unique Guid to identify it. 
        /// It is vital this Guid doesn't change otherwise old ghx files 
        /// that use the old ID will partially fail during loading.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("0ce04df8-a3ee-4686-b66d-58b651e27d50"); }
        }
    }
}
