using System;
using System.Collections.Generic;
using System.Linq;

using Grasshopper.Kernel;
using Rhino.Geometry;

using Slicer.Components.Parameters;
using Slicer.Components.Types;

using Slicer.CORE;



// In order to load the result of this wizard, you will also need to
// add the output bin/ folder of this project to the list of loaded
// folder in Grasshopper.
// You can use the _GrasshopperDeveloperSettings Rhino command for that.

namespace Slicer.Components
{
    public class MaterialComponent : GH_Component
    {
        /// <summary>
        /// Each implementation of GH_Component must provide a public 
        /// constructor without any arguments.
        /// Category represents the Tab in which the component will appear, 
        /// Subcategory the panel. If you use non-existing tab or panel names, 
        /// new tabs/panels will automatically be created.
        /// </summary>
        public MaterialComponent()
          : base("Material", "Material",
              "Material Properties",
              "Slicer", "Input")
        {
        }

        /// <summary>
        /// Registers all the input parameters for this component.
        /// </summary>
        protected override void RegisterInputParams(GH_Component.GH_InputParamManager pManager)
        {
            pManager.AddIntegerParameter("Initial Yield Stress", "YS", "Initial Yield Stress (Pa)", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Structuration Rate", "SR", "Structuration Rate (Pa/s)", GH_ParamAccess.item);
            pManager.AddIntegerParameter("Density", "d", "Density (t/m3)", GH_ParamAccess.item);
        }

        /// <summary>
        /// Registers all the output parameters for this component.
        /// </summary>
        protected override void RegisterOutputParams(GH_Component.GH_OutputParamManager pManager)
        {
            pManager.AddParameter(new Param_Material(), "Material", "M","Material Properties", GH_ParamAccess.item);
        }

        /// <summary>
        /// This is the method that actually does the work.
        /// </summary>
        /// <param name="DA">The DA object can be used to retrieve data from input parameters and 
        /// to store data in output parameters.</param>
        protected override void SolveInstance(IGH_DataAccess DA)
        {
            double density=0;
            double initialYieldStress=0;
            double structurationRate=0;

            DA.GetData(0, ref initialYieldStress);
            DA.GetData(1, ref structurationRate);
            DA.GetData(2, ref density);

            Material material = new Material(initialYieldStress, structurationRate, density);

            DA.SetData(0, (GH_Material)material);
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
            get { return new Guid("42117432-81B1-48D2-80E4-4552D86371BC"); }
        }
    }
}
