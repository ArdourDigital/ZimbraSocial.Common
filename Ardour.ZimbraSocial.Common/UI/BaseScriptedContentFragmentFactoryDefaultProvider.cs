using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telligent.Evolution.Extensibility.UI.Version1;

namespace Ardour.ZimbraSocial.Common.UI
{
    public abstract class BaseScriptedContentFragmentFactoryDefaultProvider : IScriptedContentFragmentFactoryDefaultProvider
    {
        public abstract string Description
        {
            get;
        }

        public virtual IEnumerable<IFactoryDefaultScriptedContentFragment> ScriptedContentFragments
        {
            get
            {
                var type = GetType();

                foreach (var fragmentType in type.Assembly.GetTypes().
                    Where(t => t.IsPublic
                        && t.IsClass
                        && !t.IsAbstract
                        && t.Namespace.Equals(type.Namespace, StringComparison.OrdinalIgnoreCase)
                        && t.GetInterfaces().Contains(typeof(IFactoryDefaultScriptedContentFragment))))
                {
                    yield return (IFactoryDefaultScriptedContentFragment)Activator.CreateInstance(fragmentType);
                }
            }
        }

        public abstract string Name
        {
            get;
        }

        public abstract Guid ScriptedContentFragmentFactoryDefaultIdentifier
        {
            get;
        }

        public virtual void Initialize()
        {
            var assembly = GetType().Assembly;

            foreach (var fragment in ScriptedContentFragments)
            {
                FactoryDefaultScriptedContentFragmentProviderFiles.AddUpdateDefinitionFile(this, string.Format("{0}.xml", fragment.GetType().Name), assembly.GetManifestResourceStream(fragment.DefinitionFile));

                foreach (var supplementaryFile in fragment.SupplementaryFiles)
                {
                    FactoryDefaultScriptedContentFragmentProviderFiles.AddUpdateSupplementaryFile(this, fragment.ContentFragmentId, supplementaryFile.Filename, assembly.GetManifestResourceStream(supplementaryFile.ResourceName));
                }
            }
        }
    }
}
