using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;


public abstract class AbstApiDB
{

    public abstract void WriteLog(string _msg);
    public abstract string ReplaceVal(string msg);
    public abstract string Encrypt(string sData);
    public abstract string Decrypt(string sData);
    public abstract void ByText(string Query);
    public abstract void ByText(string Query, SqlConnection Con, SqlTransaction Tran);
    public abstract DataSet ByDataSet(string Query);
    public abstract void ResizeImage(Image ImageId, int ResizeWidth, int ResizeHeight);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataSetAlert);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataSetAlert);
    public abstract DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataTableAlert, string PassEmptyText);
    public abstract DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataTableAlert, string PassEmptyText);
    public abstract DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, SqlConnection Cnn, SqlTransaction Tran, string ByDataTableAlert);

    public abstract DataSet ByProcedure(string ProcedureName, string ByDataSetAlert);
    public abstract void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, Char BySaveAlert);
    public abstract void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, string byWithTranSaveAlert, SqlConnection Cnn, SqlTransaction Trans);
    public abstract bool CheckFileHeader(byte[] buffer, string extension);
    public abstract string uploadFile(FileUpload FileUpload1, string FolderName, int FileSize);

}

public class APIProcedure : AbstApiDB
{

    public int _NewWidth, _NewHeight;
    public string _ErrorMessage;
    public string _mobileNo, _textMsg, _firstname, _bymemId, _verificationcode,
      _loginpwd, _transPwd, _amount, _description, _pinqty, _tomemID, _generateAPI,
        _FileName, _fileExt;
    public string FileExt
    {
        get
        {
            return _fileExt;
        }
        set
        {
            _fileExt = value;
        }
    }
    public string FullFileName
    {
        set
        {
            _FileName = value;
        }
        get
        {
            return _FileName;
        }
    }
    public string TomemID
    {
        get { return string.IsNullOrEmpty(_tomemID) ? "" : _tomemID; }
        set { _tomemID = value; }
    }
    public string Pinqty
    {
        get { return string.IsNullOrEmpty(_pinqty) ? "" : _pinqty; }
        set { _pinqty = value; }
    }
    public string Descrp
    {
        get { return string.IsNullOrEmpty(_description) ? "" : _description; }
        set { _description = value; }
    }
    public string Amt
    {
        get { return string.IsNullOrEmpty(_amount) ? "" : _amount; }
        set { _amount = value; }
    }

    public string TransPwd
    {
        get { return string.IsNullOrEmpty(_transPwd) ? "" : _transPwd; }
        set { _transPwd = value; }
    }
    public string Mobileno
    {
        get { return string.IsNullOrEmpty(_mobileNo) ? "" : _mobileNo; }
        set { _mobileNo = value; }
    }
    public string TextMsg
    {
        get { return string.IsNullOrEmpty(_textMsg) ? "" : _textMsg; }
        set { _textMsg = value; }
    }

    public string Firstname
    {
        get { return string.IsNullOrEmpty(_firstname) ? "" : _firstname; }
        set { _firstname = value; }
    }
    public string BymemId
    {
        get { return string.IsNullOrEmpty(_bymemId) ? "" : _bymemId; }
        set { _bymemId = value; }
    }
    public string Verificationcode
    {
        get { return string.IsNullOrEmpty(_verificationcode) ? "" : _verificationcode; }
        set { _verificationcode = value; }
    }
    public string Loginpwd
    {
        get { return string.IsNullOrEmpty(_loginpwd) ? "" : _loginpwd; }
        set { _loginpwd = value; }
    }
    public string GenerateAPI
    {
        get { return string.IsNullOrEmpty(_generateAPI) ? "" : _generateAPI; }
        set { _generateAPI = value; }
    }
    public int NewWidth
    {
        get { return _NewWidth; }
        set { _NewWidth = value; }
    }
    public int NewHeight
    {
        get { return _NewHeight; }
        set { _NewHeight = value; }
    }
    public string ErrorMessage
    {
        get { return _ErrorMessage; }
        set { _ErrorMessage = value; }
    }
    public string Cn;
    public DataSet ds;
    public DataTable dt;
    public SqlCommand cmd;

    public string getconnection
    {

        get
        {
            try
            {
                Cn = "";// objdb.getconnection();
            }
            catch { ErrorMessage = "Yes"; throw new Exception("Please Provide Connection Object Name:Conn"); }

            return Cn;
        }
    }

    public string SingleuploadFileExcel(FileUpload FileUpload1, string FolderName, int MaxFileSizeInKB)
    {
        string Msg = "", SaveSts = "";
        int NewFileSizeInKB = 0;
        try
        {
            byte[] FileInBytes = null;
            // 1 MB= 1000 KB
            //1024 Bytes =1 KB
            //1 kb  =1*1024=1 MB 
            NewFileSizeInKB = MaxFileSizeInKB * 1024;
            StringBuilder sb = new StringBuilder();
            string dirName = HttpContext.Current.Server.MapPath("~/" + FolderName);
            Random Rnd = new Random();
            //Create Directory if not exist.
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            else
            {

                // HttpPostedFile file = FileUpload1; //uploadFilCol[i];
                string fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
                //get file extention like .jpg
                string FilePath = HttpContext.Current.Server.MapPath("~/" + FileUpload1.FileName);
                //Uploaded File Location 
                long ContentFileSize = FileUpload1.FileContent.Length;
                FileInBytes = new byte[FileUpload1.FileContent.Length];
                FileUpload1.FileContent.Read(FileInBytes, 0, FileInBytes.Length);
                if (NewFileSizeInKB > ContentFileSize || MaxFileSizeInKB == 0)
                {

                    //File Extention
                    if (fileExt == ".jpg" || fileExt == ".pdf" || fileExt == ".xls" || fileExt == ".xlsx" || fileExt == ".gif" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".doc" || fileExt == ".docx")
                    {
                        FileExt = fileExt;
                        FullFileName = System.DateTime.Now.ToString("ddMMyyyymmttss") + "_" + Convert.ToString(Rnd.Next(0, 99999)) + fileExt;
                        FileUpload1.SaveAs(dirName + "/" + FullFileName);
                        //File save in to Directory With New Name.
                        //FileInfo fileinfo = new FileInfo(dirName + "\\" + FileFullName);
                        //sb.Append(dirName + "\\" + FileFullName + " :: <span style='Color:Green'>File Size : </span>" + fileinfo.Length * 1024 + " <span style='Color:Green'> bytes </span>" + fileinfo.Length / 1024 + " <span style='Color:Green'>KB </span>" + fileinfo.Length / 1024000 + " <span style='Color:Red'>MB </span></br>");
                        SaveSts = "Ok";
                    }
                    else
                    {
                        SaveSts = "NotOk";
                        Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                    }

                }
                else
                {
                    SaveSts = "NotOk";
                    Msg = "<span style='Color:Red'> Maximum length of uploading file should be " + MaxFileSizeInKB + " KB.</span>";
                }

                if (SaveSts == "Ok" || SaveSts == "NotOk")
                {
                    if (SaveSts == "NotOk")
                    {

                    }
                    else
                    {
                        Msg = SaveSts;
                    }
                }
                else
                {
                    Msg = "Please upload files.";
                }
            }
        }
        catch (Exception ex) { throw ex; }
        return Msg;
    }

    public override bool CheckFileHeader(byte[] buffer, string extension)
    {
        ASCIIEncoding enc = new System.Text.ASCIIEncoding();
        string header = enc.GetString(buffer);
        switch (extension)
        {
            case "pdf":
                return header.StartsWith("%PDF-");
            case "jpg":
                return header.StartsWith("jpg") && !header.StartsWith("?jpg");
            case "jpeg":
                return header.StartsWith(".jpeg") && !header.StartsWith("?jpeg");
            //case "txt":
            //    return header.StartsWith("??") && !header.StartsWith("???");
            case "doc":
                return header.StartsWith(".doc");
            case "docx":
                return header.StartsWith(".docx");
            //case "xls":
            //    return header.StartsWith("??_???_?");
            case "png":
                return header.StartsWith(".PNG") || header.StartsWith("?PNG");
            //case "tiff":
            //    return header.StartsWith("MM*");
            case "gif":
                return header.StartsWith("GIF87a") || header.StartsWith("GIF89a");
            //case "exe":
            //    return header.StartsWith("MZ");
            //case "zip":
            //    return header.StartsWith("PK");
            //case "rar":
            //    return header.StartsWith("Rar!");
            //case "ico":
            //    return header.StartsWith("\\0\\0");
            //case "mp3":
            //    return header.StartsWith("ID3");
            //case "kml":
            //    return (header.StartsWith("<?xml") & !header.EndsWith("</kml>"));
            //case "kmz":
            //    return header.StartsWith("PK");
            case "OnlyImages":
                if (header.StartsWith("????") && !header.StartsWith("?????"))
                {
                    return true;
                }
                else if (header.StartsWith(".PNG") || header.StartsWith("?PNG"))
                {
                    return true;
                }
                else if (header.StartsWith("MM*"))
                {
                    return true;
                }
                else if (header.StartsWith("MM*"))
                {
                    return true;
                }
                else if (header.StartsWith("GIF87a") || header.StartsWith("GIF89a"))
                {
                    return true;
                }
                else if (header.StartsWith("\\0\\0"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return false;
        }
    }
    public override string uploadFile(FileUpload FileUpload1, string FolderName, int MaxFileSizeInKB)
    {
        string Msg = "", SaveSts = "";
        int NewFileSizeInKB = 0;
        try
        {
            byte[] FileInBytes = null;

            // 1 MB= 1000 KB
            //1024 Bytes =1 KB
            //1 kb  =1*1024=1 MB 
            NewFileSizeInKB = MaxFileSizeInKB * 1024;
            StringBuilder sb = new StringBuilder();
            string dirName = HttpContext.Current.Server.MapPath("~/" + FolderName);
            Random Rnd = new Random();
            //Create Directory if not exist.
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            else
            {
                HttpFileCollection uploadFilCol = HttpContext.Current.Request.Files;

                for (int i = 0; i < uploadFilCol.Count; i++)
                {
                    HttpPostedFile file = uploadFilCol[i];
                    string fileExt = Path.GetExtension(file.FileName).ToLower();
                    FileInBytes = new byte[file.ContentLength];
                    file.InputStream.Read(FileInBytes, 0, FileInBytes.Length);
                    //get file extention like .jpg
                    string FilePath = HttpContext.Current.Server.MapPath("~/" + file.FileName);
                    //Uploaded File Location 
                    int ContentFileSize = file.ContentLength;
                    if (NewFileSizeInKB > ContentFileSize || MaxFileSizeInKB == 0)
                    {
                        //File Extention
                        if (CheckFileHeader(FileInBytes, fileExt.Replace(".", "")))
                        {
                            if (fileExt == ".jpg" || fileExt == ".pdf" || fileExt == ".gif" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".doc" || fileExt == ".docx")
                            {
                                FileExt = fileExt;
                                FullFileName = System.DateTime.Now.ToString("ddMMyyyymmttss") + "_" + Convert.ToString(Rnd.Next(0, 99999)) + fileExt;
                                file.SaveAs(dirName + "/" + FullFileName);
                                //File save in to Directory With New Name.
                                //FileInfo fileinfo = new FileInfo(dirName + "\\" + FileFullName);
                                //sb.Append(dirName + "\\" + FileFullName + " :: <span style='Color:Green'>File Size : </span>" + fileinfo.Length * 1024 + " <span style='Color:Green'> bytes </span>" + fileinfo.Length / 1024 + " <span style='Color:Green'>KB </span>" + fileinfo.Length / 1024000 + " <span style='Color:Red'>MB </span></br>");
                                SaveSts = "Ok";
                            }
                            else
                            {
                                SaveSts = "NotOk";
                                Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                            }
                        }
                        else
                        {
                            SaveSts = "NotOk";
                            Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                        }
                    }
                    else
                    {
                        SaveSts = "NotOk";
                        Msg = "<span style='Color:Red'> Maximum length of uploading file should be " + MaxFileSizeInKB + " KB.</span>";
                    }
                }
                if (SaveSts == "Ok" || SaveSts == "NotOk")
                {
                    if (SaveSts == "NotOk")
                    {

                    }
                    else
                    {
                        Msg = SaveSts;
                    }
                }
                else
                {
                    Msg = "Please upload files.";
                }
            }
        }
        catch (Exception ex) { throw ex; }
        return Msg;
    }
    public string SingleuploadFile(FileUpload FileUpload1, string FolderName, int MaxFileSizeInKB)
    {
        string Msg = "", SaveSts = "";
        int NewFileSizeInKB = 0;
        try
        {
            byte[] FileInBytes = null;
            // 1 MB= 1000 KB
            //1024 Bytes =1 KB
            //1 kb  =1*1024=1 MB 
            NewFileSizeInKB = MaxFileSizeInKB * 1024;
            StringBuilder sb = new StringBuilder();
            string dirName = HttpContext.Current.Server.MapPath("~/" + FolderName);
            Random Rnd = new Random();
            //Create Directory if not exist.
            //if (!Directory.Exists(dirName))
            //{
            //    Directory.CreateDirectory(dirName);
            //}
            //else
            //{
                
                // HttpPostedFile file = FileUpload1; //uploadFilCol[i];
                string fileExt = Path.GetExtension(FileUpload1.FileName).ToLower();
                //get file extention like .jpg
                string FilePath = HttpContext.Current.Server.MapPath("~/" + FileUpload1.FileName);
                //Uploaded File Location 
                long ContentFileSize = FileUpload1.FileContent.Length;
                    FileInBytes = new byte[FileUpload1.FileContent.Length];
                    FileUpload1.FileContent.Read(FileInBytes, 0, FileInBytes.Length);
                //if (NewFileSizeInKB > ContentFileSize || MaxFileSizeInKB == 0)
                //{
                    //if (CheckFileHeader(FileInBytes, fileExt.Replace(".", "")))
                    //{
                        //File Extention
                        if (fileExt == ".jpg" || fileExt == ".pdf" || fileExt == ".gif" || fileExt == ".jpeg" || fileExt == ".png" || fileExt == ".doc" || fileExt == ".docx")
                        {
                            FileExt = fileExt;
                            FullFileName = System.DateTime.Now.ToString("ddMMyyyymmttss") + "_" + Convert.ToString(Rnd.Next(0, 99999)) + fileExt;
                            FileUpload1.SaveAs(dirName + "/" + FullFileName);
                            //File save in to Directory With New Name.
                            //FileInfo fileinfo = new FileInfo(dirName + "\\" + FileFullName);
                            //sb.Append(dirName + "\\" + FileFullName + " :: <span style='Color:Green'>File Size : </span>" + fileinfo.Length * 1024 + " <span style='Color:Green'> bytes </span>" + fileinfo.Length / 1024 + " <span style='Color:Green'>KB </span>" + fileinfo.Length / 1024000 + " <span style='Color:Red'>MB </span></br>");
                            SaveSts = "Ok";
                        }
                        else
                        {
                            SaveSts = "NotOk";
                            Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                        }
                    //}
                    //else
                    //{
                    //    SaveSts = "NotOk";
                    //    Msg = "File format not recognised." + " jpg/jpeg/gif/png/pdf/doc/docx formats";
                    //}
                //}
                //else
                //{
                //    SaveSts = "NotOk";
                //    Msg = "<span style='Color:Red'> Maximum length of uploading file should be " + MaxFileSizeInKB + " KB.</span>";
                //}

                if (SaveSts == "Ok" || SaveSts == "NotOk")
                {
                    if (SaveSts == "NotOk")
                    {

                    }
                    else
                    {
                        Msg = SaveSts;
                    }
                }
                else
                {
                    Msg = "Please upload files.";
                }
            //}
        }
        catch (Exception ex) { throw ex; }
        return Msg;
    }
    public override void WriteLog(string _msg)
    {
        string filepath;
        try
        {
            filepath = HttpContext.Current.Server.MapPath("~/exLog.html");
            if (System.IO.File.Exists(filepath))
            {
                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/exLog.html"), true))
                {

                    //for writing time....

                    writer.Write("<br>" + "[<b style='color:Red;'>Date:</b> " + DateTime.Now.ToLongDateString() + "] & [<b style='color:Red;'>Time:</b> " + DateTime.Now.ToLongTimeString() + "]");
                    writer.WriteLine();
                    //actual write cintent.....            

                    writer.Write("<br>" + ReplaceVal(_msg));
                    writer.WriteLine();
                    //For Record Sepration....            

                    writer.WriteLine("<br><hr>");
                    writer.Close();
                }
            }
            else
            {
                System.IO.StreamWriter sw = System.IO.File.CreateText(filepath);
                //for writing time....            

                using (StreamWriter writer = new StreamWriter(HttpContext.Current.Server.MapPath("~/exLog.html"), true))
                {

                    //for writing time....

                    writer.Write("[<b style='color:Red;'>Date:</b> " + DateTime.Now.ToLongDateString() + "] & [<b style='color:Red;'>Time:</b> " + DateTime.Now.ToLongTimeString() + "]");
                    writer.WriteLine();

                    //actual write cintent.....            

                    writer.Write("<br>" + ReplaceVal(_msg));
                    writer.WriteLine();
                    //For Record Sepration....            

                    writer.WriteLine("<br><hr>");
                    writer.Close();
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
    }
    public override string ReplaceVal(string msg)
    {
        string Msg = "";
        try
        {
            Msg = msg;
            Msg.Replace(@"at System.Data.SqlClient.SqlConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.SqlInternalConnection.OnError(SqlException exception, Boolean breakConnection)
   at System.Data.SqlClient.TdsParser.ThrowExceptionAndWarning(TdsParserStateObject stateObj)
   at System.Data.SqlClient.TdsParser.Run(RunBehavior runBehavior, SqlCommand cmdHandler, SqlDataReader dataStream, BulkCopySimpleResultSet bulkCopyHandler, TdsParserStateObject stateObj)
   at System.Data.SqlClient.SqlCommand.RunExecuteNonQueryTds(String methodName, Boolean async)
   at System.Data.SqlClient.SqlCommand.InternalExecuteNonQuery(DbAsyncResult result, String methodName, Boolean sendToPipe)
   at System.Data.SqlClient.SqlCommand.ExecuteNonQuery()", "").Replace("Error Msg :", "<b style='color:Red;'>Error Msg :</b>").Replace("Event Info :", "<b style='color:Red;'>Event Info :</b>");
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        return Msg;
    }
    public override string Decrypt(string sData)
    {
       
        string EncryptionKey = "%&$:";
        byte[] cipherBytes = Convert.FromBase64String(sData.Replace(" ", "+"));
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 });
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cipherBytes, 0, cipherBytes.Length);
                    cs.Close();
                }
                sData = Encoding.Unicode.GetString(ms.ToArray());
            }
        }
        return sData;
    }
    public override string Encrypt(string sData)
    {
      
        string EncryptionKey = "%&$:";
        byte[] clearBytes = Encoding.Unicode.GetBytes(sData.Replace(" ", ""));
        using (Aes encryptor = Aes.Create())
        {
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64 });//, 0x76, 0x65, 0x64, 0x65, 0x76 
            encryptor.Key = pdb.GetBytes(32);
            encryptor.IV = pdb.GetBytes(16);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(clearBytes, 0, clearBytes.Length);
                    cs.Close();
                }
                sData = Convert.ToBase64String(ms.ToArray());
            }
        }
        return sData;
    }
    public override void ByText(string Query)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter())
                {
                    adp.SelectCommand = new SqlCommand(Query, cn);
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                //cmd.Dispose();
                ds.Dispose();
            }
        }

    }
    public override void ByText(string Query, SqlConnection Con, SqlTransaction Tran)
    {
        try
        {
            cmd = new SqlCommand(Query, Con, Tran);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally { cmd.Dispose(); }
    }
    public override DataSet ByDataSet(string Query)
    {
        try
        {

            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                using (SqlDataAdapter adp = new SqlDataAdapter())
                {
                    adp.SelectCommand = new SqlCommand(Query, cn);
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                //cmd.Dispose();
                ds.Dispose();
            }
        }
        return ds;
    }
    public override void ResizeImage(Image ImageId, int ResizeWidth, int ResizeHeight)
    {
        int width = 0, height = 0, newWidth = 0, newHeight = 0, wHStatus = 0, MainWidth = 0, MainHeight = 0;
        try
        {
            System.Drawing.Image image101 = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath(ImageId.ImageUrl));
            width = image101.Width;
            height = image101.Height;

            if (width > height)
            { wHStatus = 1; }
            if (width < height)
            { wHStatus = 2; }
            if (width == height)
            { wHStatus = 3; }

            if (wHStatus == 1)
            {
                if (width > ResizeWidth)
                {
                    MainWidth = ResizeWidth;
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    //check = 1;
                }
                else
                {
                    MainWidth = width;

                    if (height > ResizeHeight)
                    {
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        MainWidth = newWidth;
                    }
                    else
                    {
                        MainHeight = height;
                    }
                }
            }
            if (wHStatus == 2)
            {
                if (height > ResizeHeight)
                {
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    MainWidth = newWidth;
                }
                else
                {
                    MainHeight = height;
                    if (width > ResizeWidth)
                    {
                        MainWidth = ResizeWidth;
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        //check = 1;
                    }
                    else
                    {
                        MainWidth = width;
                    }
                }
            }
            if (wHStatus == 3)
            {
                if (width > ResizeWidth)
                {
                    MainWidth = ResizeWidth;
                    double ratioX = (double)ResizeWidth / image101.Width;
                    double ratioY = (double)ResizeHeight / image101.Height;
                    double ratio1 = Math.Min(ratioX, ratioY);

                    newWidth = (int)(image101.Width * ratio1);
                    newHeight = (int)(image101.Height * ratio1);
                    MainHeight = newHeight;
                    //check = 1;
                }
                else
                {
                    MainWidth = width;

                    if (height > ResizeHeight)
                    {
                        double ratioX = (double)ResizeWidth / image101.Width;
                        double ratioY = (double)ResizeHeight / image101.Height;
                        double ratio1 = Math.Min(ratioX, ratioY);

                        newWidth = (int)(image101.Width * ratio1);
                        newHeight = (int)(image101.Height * ratio1);
                        MainHeight = newHeight;
                        MainWidth = newWidth;
                    }
                    else
                    {
                        MainHeight = height;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        NewWidth = MainWidth;
        NewHeight = MainHeight;

    }
    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataSetAlert)
    {
        try
        {

            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + OutPutParamName, SqlDbType.Int).Direction = ParameterDirection.Output;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
            //throw;
        }
        finally
        {

            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        TotRecord = (int)cmd.Parameters["@" + OutPutParamName].Value;
        return ds;
    }
    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataSetAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {

                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }
    public override DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string OutPutParamName, out int TotRecord, string ByDataTableAlert, string PassEmptyText)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@" + OutPutParamName, SqlDbType.Int).Direction = ParameterDirection.Output;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adp.Fill(dt);
                }
            }

        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
            //throw;
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                dt.Dispose();
                cmd.Dispose();
            }
        }
        TotRecord = (int)cmd.Parameters["@" + OutPutParamName].Value;
        return dt;
    }
    public override DataTable ByProcedure(string ProcedureName, string[] Parameter, string[] Values, string ByDataTableAlert, string PassEmptyText)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < Parameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    dt = new DataTable();
                    adp.Fill(dt);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                dt.Dispose();
                cmd.Dispose();
            }
        }
        return dt;
    }

    public override DataSet ByProcedure(string ProcedureName, string[] Parameter, string[] Values, SqlConnection Cnn, SqlTransaction Tran, string ByDataTableAlert)
    {
        try
        {
            cmd = new SqlCommand(ProcedureName, Cnn, Tran);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Parameter.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + Parameter[i].ToString(), Values[i].ToString());
            }
            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                ds = new DataSet();
                adp.Fill(ds);
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }

    public override DataSet ByProcedure(string ProcedureName, string ByDataSetAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                ds.Dispose();
                cmd.Dispose();
            }
        }
        return ds;
    }
    public override void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, Char BySaveAlert)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(getconnection))
            {
                cmd = new SqlCommand(ProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < SaveParameter.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + SaveParameter[i].ToString(), SaveValues[i].ToString());
                }
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    ds = new DataSet();
                    adp.Fill(ds);
                }
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            if (ErrorMessage != "Yes")
            {
                cmd.Dispose();
                ds.Dispose();
            }
        }

    }
    public override void ByProcedure(string ProcedureName, string[] SaveParameter, string[] SaveValues, string byWithTranSaveAlert, SqlConnection Cnn, SqlTransaction Trans)
    {
        try
        {
            cmd = new SqlCommand(ProcedureName, Cnn, Trans);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < SaveParameter.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + SaveParameter[i].ToString(), SaveValues[i].ToString());
            }

            using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
            {
                ds = new DataSet();
                adp.Fill(ds);
            }
        }
        catch (Exception ex)
        {
            WriteLog(" Error Msg :" + ex.Message + "\n" + "Event Info :" + ex.StackTrace);
        }
        finally
        {
            cmd.Dispose();
            ds.Dispose();

        }
    }
    public string DepoHeadIDSendToID(string BranchID)
    {
        CommonFuction objExec = new CommonFuction();
        return objExec.FillDatasetByProc("SELECT Flag,ForwordedID FROM tblintigforwardedempid WHERE Flag='Depot Head' and BranchID='" + BranchID + "'").Tables[0].Rows[0]["ForwordedID"].ToString();
    }
}


