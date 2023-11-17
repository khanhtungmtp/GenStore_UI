
using GenStore.Models;

namespace GenStore.T4
{
    partial class ModelT4
    {
        private List<Sp> SpList { get; set; }

        private string Namespace { get; set; }
        private string SolutionDestinationFolder { get; set; }
        private string ProgramName { get { return AppDomain.CurrentDomain.FriendlyName; } }
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public ModelT4(List<Sp> _spList,
            string _namespace,
            string _solutionDestinationFolder
            )
        {
            SpList = _spList;
            Namespace = _namespace;
            SolutionDestinationFolder = _solutionDestinationFolder;
        }
    }


}
