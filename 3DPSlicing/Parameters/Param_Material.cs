using System;
using System.Collections.Generic;

using Rhino.Geometry;

using Grasshopper.Kernel;
using Slicer.Components.Types;


namespace Slicer.Components.Parameters
{
    public class Param_Material : GH_Param<GH_Material>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Param_FD_Model class.
        /// </summary>
        public Param_Material()
          : base("Material Properties", "Material Properties",
              "The properties of the material used in the model",
              "ENPC", "Parameters", GH_ParamAccess.item)
        {
        }

        #endregion Constructors

        #region GH_Param<>

        /// <summary>
        /// Gets the unique ID for this component. Do not change this ID after release.
        /// </summary>
        public override Guid ComponentGuid
        {
            get { return new Guid("{2453E28E-3792-4660-A04E-A073A3FE6674}"); }
        }

        /// <summary>
        /// Define a position in the grasshopper toolbar.
        /// </summary>
        public override GH_Exposure Exposure
        {
            get { return GH_Exposure.primary; }
        }

        /// <summary>
        /// Provides an Icon for the component.
        /// </summary>
        protected override System.Drawing.Bitmap Icon
        {
            get
            {
                //You can add image files to your project resources and access them like this:
                // return Resources.IconForThisComponent;
                return null;
            }
        }

        /// <summary>
        /// Gets or sets the enabled flag of this object.
        /// </summary>
        public override bool Locked
        {
            get { return base.Locked; }
            set
            {
                if (base.Locked != value)
                {
                    base.Locked = value;
                }
            }
        }

        #endregion
    }
}