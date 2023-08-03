using GenStore.Helpers;
using GenStore.Models;
using GenStore.T4;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GenStore
{
    public partial class MainGenSP : Form
    {
        public string P_Schema = "";
        public string P_ConnectionString;
        public string P_NameSpace;
        public string P_ContextSource;
        public bool P_ExcludeSystemObject = true;
        public string P_OutPutSolutionFolder;
        public string P_OutPutPhysicalFolder;
        public string P_OutPutFilename;
        public List<Sp> SpList = new List<Sp>();
        public List<SpException> ExceptionList = new List<SpException>();
        private LogForm logForm;
        public MainGenSP()
        {
            InitializeComponent();
            logForm = new LogForm();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clear the log messages when the form is closing
            logForm.ClearLog();
            e.Cancel = true; // Prevent the form from closing

        }

        public MainGenSP(string p_Schema, string p_ConnectionString, string p_NameSpace, string p_ContextSource, bool p_ExcludeSystemObject, string p_OutPutSolutionFolder, string p_OutPutPhysicalFolder, string p_OutPutFilename, List<Sp> spList, List<SpException> exceptionList, LogForm logForm, IContainer components, Label label1, Label label2, PictureBox pictureBox1, Label label3, TextBox txtNamespace, TextBox txtContext, Label label4, TextBox txtEntityPath, Label label5, TextBox txtSchema, Label label6, TextBox txtPathOutput, Label label7, TextBox txtNameFileOutPut, Label label8, Button btnStartGen, TextBox txtNameConnectionString)
        {
            P_Schema = p_Schema;
            P_ConnectionString = p_ConnectionString;
            P_NameSpace = p_NameSpace;
            P_ContextSource = p_ContextSource;
            P_ExcludeSystemObject = p_ExcludeSystemObject;
            P_OutPutSolutionFolder = p_OutPutSolutionFolder;
            P_OutPutPhysicalFolder = p_OutPutPhysicalFolder;
            P_OutPutFilename = p_OutPutFilename;
            SpList = spList;
            ExceptionList = exceptionList;
            this.logForm = logForm;
            this.components = components;
            this.label1 = label1;
            this.lbNameConnectionString = label2;
            this.pictureBox1 = pictureBox1;
            this.label3 = label3;
            this.txtNamespace = txtNamespace;
            this.txtContext = txtContext;
            this.label4 = label4;
            this.txtEntityPath = txtEntityPath;
            this.label5 = label5;
            this.txtSchema = txtSchema;
            this.label6 = label6;
            this.txtPathOutput = txtPathOutput;
            this.label7 = label7;
            this.txtNameFileOutPut = txtNameFileOutPut;
            this.label8 = label8;
            this.btnStartGen = btnStartGen;
            this.txtNameConnectionString = txtNameConnectionString;
        }

        private void btnStartGen_Click(object sender, EventArgs e)
        {
            SpList.Clear();
            ExceptionList.Clear();
            // Get user inputs from textboxes
            string nameConnectionString = txtNameConnectionString.Text.Trim();
            string namespaceValue = txtNamespace.Text.Trim();
            string contextValue = txtContext.Text.Trim();
            string sFolderValue = txtEntityPath.Text.Trim();
            string fFolderValue = txtPathOutput.Text.Trim();
            string filenameValue = txtNameFileOutPut.Text.Trim();
            string schema = txtSchema.Text.Trim();

            if (logForm == null || logForm.IsDisposed)
            {
                logForm = new LogForm();
                logForm.FormClosing += LogForm_FormClosing; // Attach the FormClosing event handler
            }

            logForm.Show();

            DateTime startTime = DateTime.Now;

            // Call GenSPScan function with user inputs
            GenSPScan(nameConnectionString, schema, namespaceValue, contextValue, sFolderValue, fFolderValue, filenameValue);
            // Stop the time after the method is completed
            DateTime endTime = DateTime.Now;
            // Calculate the time taken for the scaffold process
            TimeSpan duration = endTime - startTime;
            // Chuyển đổi duration sang mili giây
            long milliseconds = (long)duration.TotalMilliseconds;
            // Show the execution time in the MessageBox
            if (SpList.Count > 0)
            {
                MessageBox.Show($"Thời gian xử lý: {milliseconds} ms", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GenSPScan(string nameConnectionString, string schema, string namespaceValue, string contextValue, string sFolderValue, string fFolderValue, string filenameValue)
        {
            // Set default values for empty parameters
            if (string.IsNullOrEmpty(namespaceValue))
            {
                namespaceValue = "API";
            }

            if (string.IsNullOrEmpty(contextValue))
            {
                contextValue = "DBContext";
            }

            if (string.IsNullOrEmpty(sFolderValue))
            {
                sFolderValue = "Models";
            }

            if (string.IsNullOrEmpty(fFolderValue))
            {
                fFolderValue = Path.Combine(Directory.GetCurrentDirectory(), "output");
            }

            if (string.IsNullOrEmpty(filenameValue))
            {
                string currentTime = DateTime.Now.ToString("yyyyMMddHHmmss");
                if (schema == "+")
                    filenameValue = $"ResultAll_{currentTime}.cs";
                else
                    filenameValue = $"ResultSingle_{currentTime}.cs";
            }

            // Doc chuoi ket noi tu appsettings json dua tren ten chuoi ket noi
            string connectionString = GetConnectionString(nameConnectionString);
            P_ConnectionString = connectionString;
            P_NameSpace = namespaceValue;
            P_Schema = schema;
            P_ContextSource = contextValue;
            P_OutPutSolutionFolder = sFolderValue;
            P_OutPutPhysicalFolder = fFolderValue;
            P_OutPutFilename = filenameValue;

            if (!string.IsNullOrEmpty(connectionString) &&
                !string.IsNullOrEmpty(namespaceValue) &&
                !string.IsNullOrEmpty(contextValue) &&
                !string.IsNullOrEmpty(sFolderValue) &&
                !string.IsNullOrEmpty(fFolderValue) &&
                !string.IsNullOrEmpty(filenameValue))
            {
                // Check if the output physical folder exists, and create it if it doesn't.
                if (!Directory.Exists(fFolderValue))
                {
                    Directory.CreateDirectory(fFolderValue);
                }

                if (string.IsNullOrEmpty(schema))
                {
                    logForm.AddLogMessage("GenSP - ERROR: Parameter Missing: schema");
                }
                else if (schema == "+")
                {
                    P_Schema = "+"; // Set the schema to "+" to get all stored procedures
                    HandleGenSPScan();
                }
                else
                {
                    // get 1 store
                    HandleGenSPScan();
                }
            }
            else
            {
                // Output the missing parameters if any
                logForm.AddLogMessage("GenSP - ERROR:");
                if (string.IsNullOrEmpty(connectionString))
                {
                    logForm.AddLogMessage("Parameter Missing: connection");
                }
            }
        }

        private string FindConnectionStringRecursive(JToken token, string connectionName)
        {
            if (token.Type == JTokenType.Object)
            {
                foreach (var property in token.Children<JProperty>())
                {
                    if (property.Name == connectionName)
                    {
                        return property.Value.ToString();
                    }

                    var result = FindConnectionStringRecursive(property.Value, connectionName);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var item in token.Children())
                {
                    var result = FindConnectionStringRecursive(item, connectionName);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        private string GetConnectionString(string connectionName)
        {
            try
            {
                // Doc noi dung tu appsettings.json
                string jsonContent = File.ReadAllText("appsettings.json");

                // Parse JSON using JToken
                JToken jsonToken = JToken.Parse(jsonContent);

                // Find the connection string by connectionName recursively
                string connectionString = FindConnectionStringRecursive(jsonToken, connectionName);

                if (connectionString != null)
                {
                    return connectionString;
                }
            }
            catch (JsonReaderException ex)
            {
                logForm.AddLogMessage($"JSON parsing error: {ex.Message}");
            }

            return null;
        }

        public void HandleGenSPScan()
        {
            var dt_SpList = new DataTable();
            var dt_SpParam = new DataTable();
            var dt_SpResult = new DataTable();

            logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} STEP 1 - QUET STORED PROCEDURE");

            dt_SpList = Get_StoreProcedure_List();

            logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} STEP 2 - BAT DAU LAY STORED PROCEDURE");
            logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} STEP 2 - Total Stored Procedure: {dt_SpList.Rows.Count}");

            int i = 1;
            string _schema = "";
            string _sp = "";

            foreach (DataRow r in dt_SpList.Rows)
            {
                _schema = r["ROUTINE_SCHEMA"].ToString();
                _sp = r["ROUTINE_NAME"].ToString();

                dt_SpParam = Get_StoreProcedure_Param(_schema, _sp);
                dt_SpResult = Get_StoreProcedure_Result(_schema, _sp);

                logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} STEP 2 - {i} / {dt_SpList.Rows.Count} ==> \"{r["ROUTINE_NAME"]}\"");
                var pList = new List<SpParam>();
                foreach (DataRow par in dt_SpParam.Rows)
                {
                    var _p = new SpParam()
                    {
                        Param = par["Parameter"].ToString().Replace("@", ""),
                        Type = SP_GetType(par["Type"].ToString(), (bool)par["is_nullable"]),
                        Length = (par["Length"].GetType().Name == "DBNull" ? null : par["Length"].ToString()),
                        Precision = (par["Precision"].GetType().Name == "DBNull" ? null : par["Precision"].ToString()),
                        Scale = (par["Scale"].GetType().Name == "DBNull" ? null : par["Scale"].ToString()),
                        Order = (par["Order"].GetType().Name == "DBNull" ? null : par["Order"].ToString()),
                        isOutput = (bool)par["is_Output"],
                        isNullable = (bool)par["is_nullable"],
                        Collation = (par["Collation"].GetType().Name == "DBNull" ? null : par["Collation"].ToString()),
                        DbType = SP_GetDbType(par["Type"].ToString()),
                        sql_Param = (par["Parameter"].GetType().Name == "DBNull" ? null : par["Parameter"].ToString()),
                        sql_Type = (par["Type"].GetType().Name == "DBNull" ? null : par["Type"].ToString()),
                        sql_Length = (par["Length"].GetType().Name == "DBNull" ? null : par["Length"].ToString()),
                        sql_Prec = (par["Precision"].GetType().Name == "DBNull" ? null : par["Precision"].ToString()),
                        sql_Scale = (par["Scale"].GetType().Name == "DBNull" ? null : par["Scale"].ToString()),
                        sql_Order = (par["Order"].GetType().Name == "DBNull" ? null : par["Order"].ToString()),
                        sql_isOutput = (par["is_Output"].GetType().Name == "DBNull" ? null : par["is_Output"].ToString()),
                        sql_isNullable = (par["is_nullable"].GetType().Name == "DBNull" ? null : par["is_nullable"].ToString()),
                        sql_Collation = (par["Collation"].GetType().Name == "DBNull" ? null : par["Collation"].ToString()),
                    };

                    pList.Add(_p);
                }

                var rList = new List<SpResultElement>();
                int rCounter = 0;
                foreach (DataRow res in dt_SpResult.Rows)
                {
                    var _r = new SpResultElement()
                    {
                        Name = (string.IsNullOrEmpty(res["name"].ToString()) ? $"Col{rCounter}" : res["name"].ToString()),
                        Type = SP_GetType(res["system_type_name"].ToString(), (bool)res["is_nullable"]),
                        Length = (res["max_length"].GetType().Name == "DBNull" ? null : res["max_length"].ToString()),
                        Precision = (res["precision"].GetType().Name == "DBNull" ? null : res["precision"].ToString()),
                        Scale = (res["scale"].GetType().Name == "DBNull" ? null : res["scale"].ToString()),
                        Order = (res["column_ordinal"].GetType().Name == "DBNull" ? null : res["column_ordinal"].ToString()),
                        isNullable = (bool)res["is_nullable"],
                        Collation = (res["collation_name"].GetType().Name == "DBNull" ? null : res["collation_name"].ToString()),
                        sql_Name = (res["name"].GetType().Name == "DBNull" ? null : res["name"].ToString()),
                        sql_Type = (res["system_type_name"].GetType().Name == "DBNull" ? null : res["system_type_name"].ToString()),
                        sql_Length = (res["max_length"].GetType().Name == "DBNull" ? null : res["max_length"].ToString()),
                        sql_Precision = (res["precision"].GetType().Name == "DBNull" ? null : res["precision"].ToString()),
                        sql_Scale = (res["scale"].GetType().Name == "DBNull" ? null : res["scale"].ToString()),
                        sql_Order = (res["column_ordinal"].GetType().Name == "DBNull" ? null : res["column_ordinal"].ToString()),
                        sql_isNullable = (res["is_nullable"].GetType().Name == "DBNull" ? null : res["is_nullable"].ToString()),
                        sql_Collation = (res["collation_name"].GetType().Name == "DBNull" ? null : res["collation_name"].ToString()),

                    };

                    rList.Add(_r);
                }

                var sp = new Sp()
                {
                    Name = r["ROUTINE_NAME"].ToString(),
                    Schema = r["ROUTINE_SCHEMA"].ToString(),
                    Params = pList,
                    Results = rList
                };

                SpList.Add(sp);

                i++;
            }

            logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} XONG");

            GenSPT4 genSPT4Processed = new GenSPT4(SpList, P_NameSpace, P_OutPutSolutionFolder, P_ContextSource);

            File.WriteAllText(Path.Combine(P_OutPutPhysicalFolder, P_OutPutFilename), genSPT4Processed.TransformText());

            if (ExceptionList.Count > 0)
            {
                logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} Da tim thay exception! Vui long check o file GenSP_log.txt in '{P_OutPutPhysicalFolder}'");
                WriteException();
            }

        }

        private string SP_GetType(string type, bool isNullable)
        {
            type = type.ToLower().Trim();

            // kiem tra kieu du lieu trong sql server va tra ve kieu du lieu tuong ung trong c#
            if (type == "int")
                return "int" + (isNullable ? "?" : "");
            else if (type == "uniqueidentifier")
                return "Guid" + (isNullable ? "?" : "");
            else if (type == "money" || type.Contains("float") || type.Contains("numeric") || type.Contains("decimal"))
                return "decimal" + (isNullable ? "?" : "");
            else if (type == "text" || type.IndexOf("nvarchar") > -1 || type.IndexOf("varchar") > -1 || type.IndexOf("char") > -1)
                return "string";
            else if (type.Contains("table type"))
                return "DataTable";
            else if (type == "bigint" || type == "smallint")
                return type == "bigint" ? "Int64" : "int" + (isNullable ? "?" : "");
            else if (type == "tinyint")
                return "Byte" + (isNullable ? "?" : "");
            else if (type.IndexOf("smalldatetime") > -1 || type.IndexOf("datetimeoffset") > -1 || type.IndexOf("datetime") > -1 || type.IndexOf("date") > -1)
                return "DateTime" + (isNullable ? "?" : "");
            else if (type == "bit")
                return "bool" + (isNullable ? "?" : "");
            else
                throw new UnknownDBTypeException(type);
        }

        private string SP_GetDbType(string type)
        {
            type = type.ToLower().Trim();

            // Check the SQL Server data type and return the corresponding C# data type
            if (type == "int")
                return "Int32";
            else if (type == "text" || type.IndexOf("nvarchar") > -1 || type.IndexOf("varchar") > -1 || type.IndexOf("char") > -1)
                return "string";
            else if (type.Contains("table type"))
                return "DataTable";
            else if (type == "uniqueidentifier")
                return "Guid";
            else if (type == "money" || type.Contains("float") || type.Contains("numeric") || type.Contains("decimal"))
                return "decimal";
            else if (type == "bigint")
                return "Int64";
            else if (type == "smallint")
                return "Int16";
            else if (type == "tinyint")
                return "Byte";
            else if (type.IndexOf("smalldatetime") > -1 || type.IndexOf("datetimeoffset") > -1 || type.IndexOf("datetime") > -1 || type.IndexOf("date") > -1)
                return "DateTime";
            else if (type == "bit")
                return "Boolean";
            else
                throw new UnknownDBTypeException(type); // Throw an exception for unknown types
        }

        private DataTable Get_StoreProcedure_List()
        {
            DataTable dtResult = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(P_ConnectionString))
                {
                    string sql = @"
                SELECT * 
                  FROM INFORMATION_SCHEMA.ROUTINES
                 WHERE ROUTINE_TYPE = 'PROCEDURE'";

                    // Kiem tra neu nguoi dung khong nhap ten procedure hoac nhap + thi lay tat ca
                    if (!string.IsNullOrEmpty(P_Schema) && !P_Schema.Equals("+"))
                    {
                        // Chia cac ten procedure boi dau phay va tao danh sach tham so trong cau truy van
                        string[] procedureNames = P_Schema.Split(',');
                        string procedureFilter = string.Join(",", procedureNames.Select(p => $"'{p.Trim()}'"));
                        sql += $" AND ROUTINE_NAME IN ({procedureFilter})";
                    }

                    if (P_ExcludeSystemObject)
                    {
                        sql += " AND LEFT(ROUTINE_NAME, 3) NOT IN ('sp_', 'xp_', 'ms_')";
                    }

                    sql += " ORDER BY ROUTINE_NAME";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(sql, connection);
                    adapter.Fill(dtResult);
                }

                return dtResult;
            }
            catch (Exception e)
            {
                ExceptionList.Add(new SpException() { Method = "Get_StoreProcedure_List", Message = e.Message });

                return dtResult;
            }
        }

        private DataTable Get_StoreProcedure_Param(string schema, string sp)
        {
            DataTable dtResult = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(P_ConnectionString))
                {
                    string sql = $@"
                                SELECT  
                                   'Parameter' = name,  
                                   'Type'   = type_name(system_type_id),  
                                   'Length'   = CAST(max_length AS INT),  
                                   'Precision'   = CAST(case when type_name(system_type_id) = 'uniqueidentifier' 
                                              then precision  
                                              else OdbcPrec(system_type_id, max_length, precision) end AS INT),  
                                   'Scale'   = CAST(OdbcScale(system_type_id, scale) AS INT),  
                                   'Order'  = CAST(parameter_id AS INT),  
                                   'Collation'   = convert(sysname, 
                                                   case when system_type_id in (35, 99, 167, 175, 231, 239)  
                                                   then ServerProperty('collation') end),
                                  is_Output,
	                              is_nullable
                                  from sys.parameters where object_id = object_id('{schema}.{sp}')
                                  ORDER BY parameter_id
                                ";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(sql, connection);
                    adapter.Fill(dtResult);
                }

                return dtResult;
            }
            catch (Exception e)
            {
                ExceptionList.Add(new SpException() { Method = "Get_StoreProcedure_Param", FullName = $"{schema}.{sp}", Schema = schema, StoreProcedure = sp, Message = e.Message });
                return dtResult;
            }
        }

        private DataTable Get_StoreProcedure_Result(string schema, string sp)
        {
            DataTable dtResult = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(P_ConnectionString))
                {
                    string sql = $@"exec sp_describe_first_result_set N'{schema}.{sp}'";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(sql, connection);
                    adapter.Fill(dtResult);
                }

                return dtResult;
            }
            catch (Exception e)
            {
                ExceptionList.Add(new SpException() { Method = "Get_StoreProcedure_Result", FullName = $"{schema}.{sp}", Schema = schema, StoreProcedure = sp, Message = e.Message });
                return dtResult;
            }
        }

        private void WriteException()
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;
            try
            {
                foreach (var e in ExceptionList)
                {
                    sb.AppendLine($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} - EXCEPTION {i} / {ExceptionList.Count}: {e.StoreProcedure} - {e.Message}");
                    i++;
                }
                File.WriteAllText(Path.Combine(P_OutPutPhysicalFolder, "GenSP_log.txt"), sb.ToString());
            }
            catch (Exception e)
            {
                logForm.AddLogMessage($"{DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss")} ERROR!!! --> {e.Message}");
            }
        }

        private void MainGenSP_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
