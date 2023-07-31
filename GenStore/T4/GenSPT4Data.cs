
using GenStore.Models;

namespace GenStore.T4
{
    partial class GenSPT4
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
        public GenSPT4(List<Sp> _spList,
            string _namespace,
            string _solutionDestinationFolder,
            string _sourceDbContext)
        {

            this.SpList = _spList;
            this.Namespace = _namespace;
            this.SolutionDestinationFolder = _solutionDestinationFolder;
            this.DestinationDbContext = "GenSPContext";

            this.SourceDbContext = _sourceDbContext;
        }
    }


}
