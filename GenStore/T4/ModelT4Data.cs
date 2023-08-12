
using GenStore.Models;

namespace GenStore.T4
{
    partial class ModelT4
    {
        private List<Sp> SpList { get; set; }

        private string Namespace { get; set; }
        private string SolutionDestinationFolder { get; set; }
        private string DestinationDbContext { get; set; }
        private string ProgramName { get { return System.AppDomain.CurrentDomain.FriendlyName; } }
        private string SourceDbContext { get; set; }
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public ModelT4(List<Sp> _spList,
            string _namespace,
            string _solutionDestinationFolder,
            string _sourceDbContext)
        {
            SpList = _spList;
            Namespace = _namespace;
            SolutionDestinationFolder = _solutionDestinationFolder;
            DestinationDbContext = "GenSPContext";
            SourceDbContext = _sourceDbContext;
        }
    }


}
