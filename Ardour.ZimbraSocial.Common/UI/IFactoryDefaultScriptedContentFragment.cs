using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ardour.ZimbraSocial.Common.UI
{
    public interface IFactoryDefaultScriptedContentFragment
    {
        Guid ContentFragmentId { get; }

        string DefinitionFile { get; }

        IEnumerable<SupplementaryFile> SupplementaryFiles { get; }
    }
}
