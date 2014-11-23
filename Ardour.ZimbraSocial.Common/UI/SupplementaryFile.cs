using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardour.ZimbraSocial.Common.UI
{
    public class SupplementaryFile
    {
        public SupplementaryFile(string fileName, string resourceName)
        {
            Filename = fileName;
            ResourceName = resourceName;
        }

        public string Filename { get; private set; }

        public string ResourceName { get; private set; }
    }
}
