using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteTheRest.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class PreferredImplementationAttribute : Attribute
    {
        public bool IsActive { get; }

        public PreferredImplementationAttribute(bool isActive = true)
        {
            IsActive = isActive;
        }
    }
}
