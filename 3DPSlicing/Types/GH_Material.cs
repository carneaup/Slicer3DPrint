using System;
using System.Linq;

using Grasshopper;
using Grasshopper.Kernel;
using Grasshopper.Kernel.Types;

using Slicer.CORE;


namespace Slicer.Components.Types
{
    /// <summary>
    /// 
    /// </summary>
    public class GH_Material : GH_Goo<Material>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the<see cref= "GH_Material" /> class.
        /// </summary>
        public GH_Material() { }

        /// <summary>
        /// Initializes a new instance of the<see cref= "GH_Material" /> class.
        /// </summary>
        /// <param name="model"> Model to duplicate.</param>
        public GH_Material(GH_Material material)
        {
            this.Value = (Material)material.Value.Clone();
        }

        /// <summary>
        /// Initializes a new instance of the<see cref= "GH_Material" /> class.
        /// </summary>
        /// <param name="model"> Model to duplicate</param>
        public GH_Material(Material material)
        {
            this.Value = (Material)material.Clone();
        }

        #endregion Constructors

        #region GH_Goo<>

        // Properties
        /// <summary>
        /// 
        /// </summary>
        public override bool IsValid { get { return true; } }

        /// <summary>
        /// 
        /// </summary>
        public override string TypeDescription { get { return "Material Properties"; } }

        /// <summary>
        /// 
        /// </summary>
        public override string TypeName { get { return "GH_Material"; } }

        // Methods

        /// <summary>
        /// Returns the number of vertices, halfedge and faces of the halfedge mesh.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Material Properties.\nd : {0}; S : {1}; A : {2};",
                this.Value.Density, this.Value.InitialYieldStress, this.Value.StructurationRate);
        }
        /// <summary>
        /// Duplicate the point
        /// </summary>
        /// <returns>A deep copy of the point.</returns>
        public override IGH_Goo Duplicate()
        {
            return new GH_Material(this);
        }

        #endregion GH_Goo<>

        #region Operators

        /// <summary>
        /// Explicit conversion from a Model to a GH_FD_Model
        /// </summary>
        /// <param name="model"> A model for Force Density Method</param>
        public static explicit operator GH_Material(Material material) => new GH_Material(material);

        #endregion Operators
    }
}

