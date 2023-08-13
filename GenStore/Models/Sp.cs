
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

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
                return $@"public async Task<List<{this.Name}>> {this.Name}Async";
            }
        }

        //public string ConvertToStandardPropertyName(string inputName)
        //{
        //    string[] words = inputName.Split('_');
        //    var sb = new StringBuilder();

        //    foreach (string word in words)
        //    {
        //        sb.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower());
        //    }

        //    return sb.ToString();
        //}

        //public string ConvertToStandardPropertyName(string inputName)
        //{
        //    string[] words = inputName.Split('_');
        //    var sb = new StringBuilder();

        //    foreach (string word in words)
        //    {
        //        sb.Append(sb.Length > 0 ? "_" : "");
        //        sb.Append(word.ToLower());
        //    }

        //    return sb.ToString();
        //}

        public string ConvertToStandardPropertyName(string inputName)
        {
            string[] words = inputName.Split('_');
            var sb = new StringBuilder();

            foreach (string word in words)
            {
                sb.Append(sb.Length > 0 ? " " : "");
                sb.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower());
            }

            return sb.ToString().Replace(" ", "_");
        }

        public string ConvertToStandardPropertyNameTypeScript(string cSharpPropertyName)
        {
            // convert PascalCase to camelCase
            string[] words = Regex.Split(cSharpPropertyName, @"(?=[A-Z])");
            string camelCaseName = string.Join("", words.Select((word, index) =>
            {
                if (index == 0)
                {
                    return word.ToLower();
                }
                else
                {
                    return char.ToLower(word[0]) + word.Substring(1);
                }
            }));

            return camelCaseName;
        }

        public string ConvertCSharpTypeToTypeScript(string csharpType)
        {
            switch (csharpType)
            {
                case "int":
                case "float":
                case "double":
                case "decimal":
                    return "number";
                case "int?":
                case "float?":
                case "double?":
                case "decimal?":
                    return "number | null";
                case "string":
                    return "string";
                case "string?":
                    return "string | null";
                case "DateTime":
                    return "string | Date";
                case "DateTime?":
                    return "string | Date | null";
                case "bool":
                    return "boolean";
                default:
                    return "any"; 
            }
        }


    }

}
