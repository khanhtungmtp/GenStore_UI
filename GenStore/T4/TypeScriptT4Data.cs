
using GenStore.Models;

namespace GenStore.T4
{
    partial class TypeScriptT4
    {
        private List<Sp> SpList { get; set; }

        private string ProgramName { get { return AppDomain.CurrentDomain.FriendlyName; } }
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public TypeScriptT4(List<Sp> _spList)
        {
            SpList = _spList;
        }
    }


}
