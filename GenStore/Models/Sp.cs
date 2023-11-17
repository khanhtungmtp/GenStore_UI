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

        public List<SpParam> Params = new();
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public List<SpResultElement> Results = new();
        /// <summary>
        /// Gets or sets the name of the SpResultElement.
        /// </summary>
        public string GetMethodDefinition()
        {
            if (!Results.Any())
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
                sb.Append(sb.Length > 0 ? " " : "");
                sb.Append(char.ToUpper(word[0]) + word.Substring(1).ToLower());
            }

            return sb.ToString().Replace(" ", "_");
        }

        public bool ContainsAnySpecialChars(string input)
        {
            char[] specialChars = new char[] { '.', ' ', '$', '-', '+', '#' };
            return input.Any(c => specialChars.Contains(c));
        }

        public string RemoveAndJoin(string input)
        {
            char[] specialChars = new char[] { '.', ' ', '$', '-', '+', '#' };
            string[] words = input.Split(specialChars, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder result = new();
            foreach (string word in words)
            {
                result.Append(word);
            }

            return result.ToString();
        }

        #region area typescript handle
        /// <summary>
        /// // Chuyển đổi chuỗi thành chữ thường và giữ nguyên chữ in hoa cuối cùng của phần truoc dấu '_' dau tien đến hết string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static string ConvertToLowerCaseWithUppercaseFirstAfterUnderscore(string input)
        {
            string[] parts = input.Split('_');

            if (parts.Length > 1)
            {
                if (parts[0].Length < 2)
                    parts[0] = parts[0].ToLower();
                else
                    parts[0] = ConvertLastCharToLowerCase(parts[0]);
                // Ghép các phần lại thành chuỗi mới
                return string.Join("_", parts);
            }

            return input;
        }

        public static string ConvertLastCharToLowerCase(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                // Lấy chiều dài của chuỗi
                int length = input.Length;

                // Chuyển đổi chữ cái cuối cùng thành chữ thường
                char lastChar = char.ToUpper(input[length - 1]);

                // Tạo chuỗi mới bằng cách ghép chuỗi cũ và chữ cái cuối cùng đã chuyển đổi
                return input.Substring(0, length - 1).ToLower() + lastChar;
            }

            return input;
        }

        public static string ConvertFirstCharToLowerCase(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                // Lấy chiều dài của chuỗi
                int length = input.Length;

                // Chuyển đổi chữ cái dau tien thành chữ thường
                char firstChar = char.ToLower(input[0]);

                // Tạo chuỗi mới bằng cách ghép chuỗi cũ và chữ cái dau tien đã chuyển đổi
                return firstChar + input.Substring(1, length - 1);
            }

            return input;
        }

        static bool IsAllUpperCase(string input)
        {
            return input == input.ToUpper();
        }

        public string ConvertToStandardPropertyNameTypeScript(string cSharpPropertyName)
        {
            if (ContainsAnySpecialChars(cSharpPropertyName))
                cSharpPropertyName = RemoveAndJoin(cSharpPropertyName);
            StringBuilder result = new();
            if (IsAllUpperCase(cSharpPropertyName))
            {
                // co 2 truong hop
                /*
                 1: khong co dau _   ex: MTP
                 2: co dau _         ex: KHANHTUNG_MTP
                */
                if (cSharpPropertyName.Contains('_'))
                {
                    // Chuyển đổi chuỗi thành chữ thường và giữ nguyên chữ in hoa cuối cùng của phần truoc dấu '_' dau tien đến hết string
                    string resultString = ConvertToLowerCaseWithUppercaseFirstAfterUnderscore(cSharpPropertyName);
                    result.Append(resultString);
                }
                else
                {
                    result.Append(cSharpPropertyName.ToLower());
                }
            }
            else
            {
                string resultString = ConvertFirstCharToLowerCase(cSharpPropertyName);
                result.Append(resultString);
            }


            return result.ToString();
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
                    if (csharpType.StartsWith("List<") && csharpType.EndsWith(">"))
                    {
                        // Extract the class name from List<className>
                        string className = csharpType.Substring(5, csharpType.Length - 6);
                        // Convert to TypeScript array notation
                        return $"{className}[]";
                    }
                    return "any";
            }
        }

        public string ConvertCSharpPropertyToTypeScript(string csharpPropertyName, string csharpType)
        {
            string tsPropertyName = ConvertToStandardPropertyNameTypeScript(csharpPropertyName);
            string tsType = ConvertCSharpTypeToTypeScript(csharpType);

            return $"{tsPropertyName}: {tsType};";
        }

        // Modify the ConvertCSharpClassToTypeScriptInterface method
        public string ConvertCSharpClassToTypeScriptInterface(string className, string csharpClass)
        {
            // Phân tách các dòng trong mã nguồn C#
            string[] lines = csharpClass.Split('\n');

            // Dùng List để lưu trữ các thuộc tính
            List<string> tsProperties = new();

            // Quét qua từng dòng mã nguồn C# để tìm thuộc tính
            foreach (string line in lines)
            {
                // Sử dụng regex hoặc cách kiểm tra để xác định dòng có phải là khai báo thuộc tính
                if (line.Contains("public") && line.Contains("{ get; set; }"))
                {
                    // Tìm tên thuộc tính và kiểu dữ liệu từ dòng khai báo
                    string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string csharpType = tokens[1];
                    string csharpPropertyName = tokens[2].Replace("{", "").Trim();

                    // Chuyển đổi thuộc tính C# sang TypeScript
                    string tsProperty = ConvertCSharpPropertyToTypeScript(csharpPropertyName, csharpType);
                    tsProperties.Add(tsProperty);
                }
            }

            // Ghép các thuộc tính TypeScript lại thành interface
            string tsInterface = $"export interface {className} {{\n\t{string.Join("\n\t", tsProperties)}\n}}";

            return tsInterface;
        }

        #endregion


    }

}
