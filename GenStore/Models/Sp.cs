
namespace GenStore.Models
{
    /// <summary>
    /// Gets or sets the name of the SpResultElement.
    /// </summary>
    public class Sp
    {
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>   
        public string Schema { get; set; }
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>

        public List<SpParam> Params = new List<SpParam>();
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public List<SpResultElement> Results = new List<SpResultElement>();
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public string GetMethodDefinition()
        {
            if (this.Results.Count == 0)
            {
                return $@"public void {this.Name}";
            }
            else
            {
                return $@"public async Task<List<{this.Name}Result>> {this.Name}Async";
            }
        }

    }

}
