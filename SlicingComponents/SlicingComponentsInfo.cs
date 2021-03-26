using System;
using System.Drawing;
using Grasshopper.Kernel;

namespace SlicingComponents
{
    public class SlicingComponentsInfo : GH_AssemblyInfo
    {
        public override string Name
        {
            get
            {
                return "SlicingComponents";
            }
        }
        public override Bitmap Icon
        {
            get
            {
                //Return a 24x24 pixel bitmap to represent this GHA library.
                return null;
            }
        }
        public override string Description
        {
            get
            {
                //Return a short string describing the purpose of this GHA library.
                return "";
            }
        }
        public override Guid Id
        {
            get
            {
                return new Guid("be5cbbea-7793-4d08-8d8a-6df0e2f5dec5");
            }
        }

        public override string AuthorName
        {
            get
            {
                //Return a string identifying you or your company.
                return "";
            }
        }
        public override string AuthorContact
        {
            get
            {
                //Return a string representing your preferred contact details.
                return "";
            }
        }
    }
}
