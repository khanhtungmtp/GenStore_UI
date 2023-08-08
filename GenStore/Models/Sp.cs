
using System.Reflection;
using System.Text;

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

        public string ConvertToStandardPropertyName(string inputName)
        {
            string[] words = inputName.Split('_');
            var sb = new StringBuilder();

            foreach (string word in words)
            {
                sb.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower());
            }

            return sb.ToString();
        }

        public void GenerateTypeScript(string tsCode)
        {
            // Đường dẫn và tên tệp TypeScript bạn muốn tạo
            string tsFilePath = Path.Combine(Directory.GetCurrentDirectory(), "abc.ts");

            // Ghi mã TypeScript vào tệp
            File.WriteAllText(tsFilePath, tsCode);
        }

        public string GetTsType(string csharpType)
        {
            switch (csharpType)
            {
                case "string":
                    return "string";
                case "int":
                case "decimal":
                    return "number";
                // Thêm các kiểu dữ liệu C# khác và kiểu tương ứng trong TypeScript
                default:
                    return "any";
            }
        }


    }

}
