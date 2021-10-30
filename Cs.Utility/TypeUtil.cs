using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cs.Utility
{
    public class TypeUtil
    {
        public TypeUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static double GetRoundValue(double dValue, int iLength)
        {
            return Math.Round(dValue, iLength);
        }

        public static decimal GetRoundValue(decimal dValue, int iLength)
        {
            return Math.Round(dValue, iLength);
        }

        public static byte[] dbBlobToUIByte(object dt)
        {
            byte[] val = new byte[0];
            if (dt != DBNull.Value)
            {
                val = (byte[])dt;

            }
            return val;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str">string obj</param>
        /// <returns>decimal obj</returns>
        public static decimal decimalZeroIfNullStr(string str)
        {

            if (str == null)
            {
                return 0;
            }
            else if (str.Trim().Equals(""))
            {
                return 0;
            }
            else
                try
                {
                    return Convert.ToDecimal(str.Trim());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(str + " can not be converted to number");
                }
        }

        public static decimal decimalZeroIfDBNull(object val)
        {
            if (val == DBNull.Value)
                return 0;
            return decimalZeroIfNullStr(val.ToString());
        }

        public static string stringToVarchar(string str)
        {
            if (str == null)
            {
                return " ";
            }
            else if (str.Trim().Equals(""))
            {
                return " ";
            }
            else
                return str;
        }

        /// <summary>
        /// Created by: 
        /// Return the comma separated string
        /// </summary>
        /// <param name="val"></param>
        /// <param name="decimalPlace"></param>
        /// <returns>Return comma separated string</returns>
        public static string GetCommaSeparatedString(decimal val, int decimalPlace)
        {
            string res = "";
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalDigits = decimalPlace;
            nfi.NumberGroupSeparator = ",";
            nfi.NumberGroupSizes = new int[] { 3, 3, 3, 3, 3, 3, 3 };
            //nfi.NumberGroupSizes = new int[]  { 3, 2, 2 ,3 ,2 ,2 ,3 };
            res = val.ToString("N", nfi);
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <returns>Return comma separated string</returns>
        public static string GetCommaSeparatedString(decimal val)
        {
            return GetCommaSeparatedString(val, 2);
        }

        /// <summary>
        /// Return formated XML (DateTime) string
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string GetFormatedXML(DataSet ds)
        {
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = "MM/dd/yyyy";

            string strXML = "";
            DataSet dsCopy = ds.Copy();

            try
            {
                foreach (DataTable dt in ds.Tables)
                {
                    DataTable dtCopy = dsCopy.Tables[dt.TableName];
                    foreach (DataColumn dc in dt.Columns)
                    {
                        if (dc.DataType == System.Type.GetType("System.DateTime"))
                        {
                            DataColumn dcCopy = new DataColumn(dc.ColumnName, System.Type.GetType("System.String"));
                            dtCopy.Columns.Remove(dc.ColumnName);
                            dtCopy.Columns.Add(dcCopy);
                            for (int index = 0; index < dt.Rows.Count; index++)
                            {
                                dtCopy.Rows[index][dc.ColumnName] = (dt.Rows[index][dc.ColumnName] == System.DBNull.Value) ? "" :
                                    Convert.ToDateTime(dt.Rows[index][dc.ColumnName]).ToString("MM/dd/yyyy");
                            }
                        }
                    }
                }
                strXML = dsCopy.GetXml();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strXML;
        }

        public static DataSet ToDataSet<T>(IList<T> list)
        {
            Type elementType = typeof(T);
            DataSet ds = new DataSet("List" + elementType.Name);
            DataTable t = new DataTable(elementType.Name);
            ds.Tables.Add(t);

            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                Type ColType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;

                t.Columns.Add(propInfo.Name, ColType);
            }

            //go through each property on T and add each value to the table
            foreach (T item in list)
            {
                DataRow row = t.NewRow();

                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }

                t.Rows.Add(row);
            }

            return ds;
        }



        public static void SerializeToXML<T>(T obj, string path, string name)
        {
            Type elementType = typeof(T);

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter textWriter = new StreamWriter(path + name + ".xml");
            serializer.Serialize(textWriter, obj);
            textWriter.Close();
        }



        static public void SerializeToXML<T>(IList<T> list, string path)
        {
            // string path = Login.APPLICATION_ROOT_DIRECTORY;
            Type elementType = typeof(T);
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(elementType.Name + "s"));
            TextWriter textWriter = new StreamWriter(path + elementType.Name + ".xml");
            serializer.Serialize(textWriter, list);
            textWriter.Close();
        }



        public static List<T> DeserializeFromXMLList<T>(string path)
        {
            Type elementType = typeof(T);
            XmlSerializer deserializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(elementType.Name + "s"));
            TextReader textReader = new StreamReader(path + elementType.Name + ".xml");
            List<T> objList = (List<T>)deserializer.Deserialize(textReader);
            textReader.Close();

            return objList;
        }



        //public static string getNewlineText(string str)
        //{
        //    string ToEdit = str;
        //    string Edited = ToEdit.Replace(".", ".\r\n");
        //    return Edited;
        //}

        //public static void disAbleAllControl(Control parent)
        //{
        //    try
        //    {
        //        foreach (Control c in parent.Controls)
        //        {
        //            switch (c.GetType().Name.ToString())
        //            {
        //                case "TextBox":
        //                    TextBox tb = (TextBox)c;
        //                    tb.ReadOnly = true;
        //                    break;
        //                case "AdvancedTextBox":
        //                    TextBox tbb = (TextBox)c;
        //                    tbb.ReadOnly = true;
        //                    break;
        //                case "XpTextBox":
        //                    TextBox tbc = (TextBox)c;
        //                    tbc.ReadOnly = true;
        //                    break;
        //                case "RadioButton":
        //                    RadioButton rad = (RadioButton)c;
        //                    rad.Enabled = false;
        //                    break;
        //                case "XpRadioButton":
        //                    rad = (RadioButton)c;
        //                    rad.Enabled = false;
        //                    break;
        //                case "XpButton":
        //                    Button btn = (Button)c;
        //                    btn.Enabled = false;
        //                    break;
        //                //case "XpComboBox":
        //                //    ComboBox cmbx = (ComboBox)c;
        //                //    cmbx.Enabled = false;
        //                //    break;
        //                case "CheckBox":
        //                    CheckBox chkbx = (CheckBox)c;
        //                    chkbx.Enabled = false;
        //                    break;

        //            }
        //            //if (c.HasChildren)
        //            //{
        //            //    disAbleAllControl(c);

        //            //}
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public static void clearAllControls(Control parent)
        //{
        //    try
        //    {
        //        foreach (Control c in parent.Controls)
        //        {
        //            switch (c.GetType().Name.ToString())
        //            {
        //                case "TextBox":
        //                    TextBox tb = (TextBox)c;
        //                    //tb.ResetText();
        //                    break;
        //                case "AdvancedTextBox":
        //                    TextBox tbb = (TextBox)c;
        //                    //tbb.ResetText();
        //                    break;
        //                case "XpTextBox":
        //                    TextBox tbc = (TextBox)c;
        //                    //tbc.ResetText();
        //                    break;
        //                case "NumEdit":
        //                    TextBox tbe = (TextBox)c;
        //                    //tbe.ResetText();
        //                    break;
        //                case "MaskedTextBox":
        //                    TextBox mtb = (TextBox)c;
        //                    //mtb.ResetText();
        //                    break;
        //                case "UCLookUp":
        //                    TextBox ulu = (TextBox)c;
        //                    //ulu.ResetText();
        //                    break;




        //            }
        //            //if (c.HasChildren)
        //            //{
        //            //    clearAllControls(c);
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public static void ClearControls(object oparent)
        //{
        //    Control parent = (Control)oparent;
        //    try
        //    {
        //        foreach (Control c in parent.Controls)
        //        {
        //            switch (c.GetType().Name.ToString())
        //            {
        //                case "TextBox":
        //                    TextBox tb = (TextBox)c;
        //                    //tb.ResetText();
        //                    break;
        //                case "AdvancedTextBox":
        //                    TextBox tbb = (TextBox)c;
        //                    //tbb.ResetText();
        //                    break;
        //                case "XpTextBox":
        //                    TextBox tbc = (TextBox)c;
        //                    /// tbc.ResetText();
        //                    break;
        //                case "NumEdit":
        //                    TextBox tbe = (TextBox)c;
        //                    // tbe.ResetText();
        //                    break;
        //                case "MaskedTextBox":
        //                    TextBox mtb = (TextBox)c;
        //                    // mtb.ResetText();
        //                    break;
        //                case "UCLookUp":
        //                    TextBox ulu = (TextBox)c;
        //                    // ulu.ResetText();
        //                    break;
        //                case "XpCheckBox":
        //                    CheckBox cb = (CheckBox)c;
        //                    cb.Checked = true;
        //                    break;
        //                case "XpComboBox":
        //                    //ComboBox cmb = (ComboBox)c;
        //                    //cmb.SelectedIndex = 0;
        //                    break;


        //            }
        //            //if (c.HasChildren)
        //            //{
        //            //    clearAllControls(c);
        //            //}
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public static void disableAllGroupBox(Control parent)
        //{
        //    try
        //    {
        //        foreach (Control c in parent.Controls)
        //        {

        //            //if (c.GetType().Name.Equals("GroupBox"))
        //            //    c.Enabled = false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public static void enableAllGroupBox(Control parent)
        //{
        //    try
        //    {
        //        foreach (Control c in parent.Controls)
        //        {
        //            //if (c.GetType().Name.Equals("GroupBox"))
        //            //    c.Enabled = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }


        //}

        //public static string GetCurrencyToWords(string currency)
        //{
        //    getCurrencyInWords w = new getCurrencyInWords();
        //    currency = currency.Replace(",","");
        //    return w.changeCurrencyToWords(currency);
        //}

        #region DateUtil

        public const string DATE_FORMAT = "dd/MM/yyyy";
        public const int MIN_DAY = 1;
        public const int MIN_MONTH = 1;
        public const int MIN_YEAR = 1900;
        public static DateTime MIN_DATE = new DateTime(MIN_YEAR, MIN_MONTH, MIN_DAY);

        public const int YEAR_LENGTH_IN_DAY = 360;

        private static string convertDateToString(DateTime theDate)
        {
            return theDate.ToString(DATE_FORMAT);
        }

        /// <summary>
        /// returns a string representation of the date passed to it that is usable 
        /// in queries
        /// </summary>
        public static string getSqlStringForDate(DateTime theDate)
        {
            string strRep
                = "TO_DATE('"
                + convertDateToString(theDate)
                + "', '"
                + DATE_FORMAT
                + "')";
            return strRep;
        }

        public static DateTime strToDate(string str, string dateFormat)
        {
            if (null == str || str.Trim().Equals(""))
            {
                return DateTime.MinValue;
            }
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = dateFormat;

            return Convert.ToDateTime(str, myDTFI);
        }

        public static string dbDateToUIString(object dt)
        {
            string val = "";
            if (dt != DBNull.Value)
            {
                val = Convert.ToDateTime(dt).ToString("dd/MM/yyyy");

            }
            return val;
        }

        public static DateTime ToUIDate(string str, string dateFormat)
        {
            if (null == str || str.Trim().Equals(""))
            {
                return DateTime.MinValue;
            }
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = dateFormat;

            return Convert.ToDateTime(str, myDTFI);
        }

        public static DateTime ToUIDate(string str)
        {
            if (null == str || str.Trim().Equals(""))
            {
                return DateTime.MinValue;
            }
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = DATE_FORMAT;

            return Convert.ToDateTime(str, myDTFI);
        }

        public static string CurrentUIDate(string dateFormat)
        {
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = dateFormat;
            string str = DateTime.Today.ToString(dateFormat);

            return str;
        }

        public static string CurrentUIDate()
        {
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = DATE_FORMAT;
            string str = DateTime.Today.ToString(DATE_FORMAT);

            return str;
        }



        public static string AdvanceUIDate(int day, int month)
        {
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = DATE_FORMAT;
            string str = DateTime.Today.AddDays(day).AddMonths(month).ToString(DATE_FORMAT);

            return str;
        }

        public static string AdvanceFromUIDate(string Date, int day, int month)
        {
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = DATE_FORMAT;

            DateTime dateTimeUi = ToUIDate(Date);
            string str = dateTimeUi.AddDays(day).AddMonths(month).ToString(DATE_FORMAT);

            return str;
        }

        public static string AdvanceFromUIDate(string uiDate, string day, string month)
        {
            int addDays = 0;
            int addMonth = 0;

            if (day != null
              && !"".Equals(day.Trim()))
            {
                addDays = int.Parse(day.Trim());
            }

            if (month != null
               && !"".Equals(month.Trim()))
            {
                addMonth = int.Parse(month.Trim());
            }
            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            myDTFI.ShortDatePattern = DATE_FORMAT;

            DateTime dateTimeUi = ToUIDate(uiDate);
            string str = dateTimeUi.AddDays(addDays).AddMonths(addMonth).ToString(DATE_FORMAT);

            return str;
        }

        #endregion DateUtil

        #region FromUtill

        //convert database object to integer
        public static int convertToInt(object colValue)
        {
            if (System.DBNull.Value != colValue
                && !"".Equals(colValue.ToString()))
            {
                return int.Parse(colValue.ToString());
            }
            else
            {
                return 0;
            }
        }

        //convert database object to integer
        public static double convertToDouble(object colValue)
        {
            if (System.DBNull.Value != colValue
                && !"".Equals(colValue.ToString()))
            {
                return double.Parse(colValue.ToString());
            }
            else
            {
                return 0;
            }
        }

        //convert database object to integer
        public static decimal convertToDecimal(object colValue)
        {
            if (System.DBNull.Value != colValue
                && !"".Equals(colValue.ToString()))
            {
                return decimal.Parse(colValue.ToString());
            }
            else
            {
                return 0;
            }
        }

        //convert database object to string
        public static string convertToString(object colValue)
        {
            if (System.DBNull.Value != colValue)
            {
                return colValue.ToString();
            }
            else
            {
                return "";
            }
        }

        public static DateTime convertToDate2(object column)
        {
            if (column != System.DBNull.Value)
            {
                return (DateTime)column;
            }
            return MIN_DATE;
        }

        public static DateTime convertToDate(object column)
        {
            if (column != System.DBNull.Value)
            {
                string strDate = column.ToString();

                DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
                myDTFI.ShortDatePattern = DATE_FORMAT;


                // string str = column.ToString();
                // return Convert.ToDateTime(str, myDTFI);
                //string str = DateTime.Today.ToString(DATE_FORMAT);
                DateTime dt = (DateTime)column;
                string str = dt.ToString(DATE_FORMAT);
                //  DateTime test = Convert.ToDateTime(str);
                DateTime test1 = Convert.ToDateTime(str, myDTFI);
                return Convert.ToDateTime(str, myDTFI);
                // return convertStringToDate(strDate);
            }
            return MIN_DATE;
        }

        public static DateTime convertStringToDate(string strDate)
        {
            if (strDate != "")
            {
                DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
                myDTFI.ShortDatePattern = DATE_FORMAT;

                DateTime dt = Convert.ToDateTime(strDate, myDTFI);
                return Convert.ToDateTime(strDate, myDTFI);
            }
            return MIN_DATE;
        }

        public static object objectDateToDatabaseDate(DateTime objDate)
        {
            if (objDate.Date.Equals(MIN_DATE.Date))
            {
                return System.DBNull.Value;
            }
            return objDate;
        }

        public static bool convertToBoolean(object column)
        {
            if (column != System.DBNull.Value)
            {
                string val = column.ToString().Trim();
                if (bool.TrueString.Equals(val))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static double getUIDoubleValue(string theValue)
        {
            double returnValue = 0;
            try
            {
                returnValue = double.Parse(theValue);
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine("Exception at TypeUtil: getUIDoubleValue():" + fe.Message);
            }
            return returnValue;
        }

        public static int getUIIntValue(string theValue)
        {
            int returnValue = 0;
            try
            {
                returnValue = int.Parse(theValue);
            }
            catch (FormatException fe)
            {
                System.Console.WriteLine("Exception at TypeUtil: getUIDoubleValue():" + fe.Message);
            }
            return returnValue;
        }

        public static string ConvertToUSD(decimal Value)
        {
            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            return Value.ToString("C", cultureInfo);
        }

        public static string ConvertToUSD(int Value)
        {
            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            return Value.ToString("C", cultureInfo);
        }

        public static string ConvertToUSD(double Value)
        {
            var cultureInfo = new System.Globalization.CultureInfo("en-US");
            return Value.ToString("C", cultureInfo);
        }

        public static decimal ConvertUSDToDecimal(string currencyValue)
        {
            return decimal.Parse(currencyValue, NumberStyles.Currency);
            //var cultureInfo = new System.Globalization.CultureInfo("en-US");
            //return 0.0;
        }

        #endregion FromUtill

        //public static void setCombo(Joaqs.UI.XpComboBox combo, string keyValue)
        //{
        //    string valueText = combo.getKeyBasedValue(keyValue);
        //    combo.SelectedItem = valueText;
        //}

        public static bool NullDataCheck(string strValue)
        {
            if (string.IsNullOrEmpty(strValue))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public static bool IsRegularExpresionTrue(string strRegEx, string value)
        {
            Regex regStr;
            regStr = new Regex(strRegEx);
            if (!regStr.IsMatch(value))
                return false;
            return true;
        }

        public static string FindKey(Hashtable hashtable, object value)
        {
            string l_myKey = "";

            foreach (string l_aKey in hashtable.Keys)
            {
                if (hashtable[l_aKey].Equals(value) == true)
                {
                    l_myKey = l_aKey;
                    return l_myKey;
                }
            }
            return l_myKey;

        }

        public static ArrayList ConvertDataTableToArraylist(DataTable dtValue)
        {
            ArrayList slValue = new ArrayList();
            for (int i = 0; i < dtValue.Rows.Count; i++)
            {
                slValue.Add(dtValue.Rows[i][0].ToString());
            }
            return slValue;
        }

        public static bool IsEqualString(string strFirst, string strSecond)
        {
            if (string.Equals(strFirst, strSecond))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public static string getIPAddress()
        {
            string strHostName = "";

            // Getting Ip address of local machine...

            // First get the host name of local machine.

            strHostName = Dns.GetHostName();
            Console.WriteLine("Local Machine's Host Name: " + strHostName);


            //  Then using host name, get the IP address list..

            IPHostEntry ipEntry = Dns.GetHostByName(strHostName);

            Console.WriteLine(System.Net.Dns.GetHostEntry(strHostName).AddressList[0].ToString());

            string strIPAddress = Dns.GetHostEntry(strHostName).AddressList[0].ToString();


            IPAddress[] addr = ipEntry.AddressList;

            for (int i = 0; i < addr.Length; i++)
            {
                Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
            }
            //  hostnameTest(strIPAddress);
            return strIPAddress;

        }



        public static string getTime(int m_sec)
        {
            string l_timeInString = "";
            int l_sec = m_sec;
            int l_min = 0;
            int l_hour = 0;

            if (l_sec >= 60)
            {
                l_min = l_sec / 60;

                Math.DivRem(l_sec, 60, out l_sec);
            }
            if (l_min >= 60)
            {
                l_hour = l_min / 60;
                Math.DivRem(l_min, 60, out l_min);
            }

            l_timeInString = l_hour < 10 ? "0" + l_hour : l_hour.ToString();
            l_timeInString += ":" + ((l_min < 10) ? "0" + l_min : l_min.ToString());
            l_timeInString += ":" + ((l_sec < 10) ? "0" + l_sec : l_sec.ToString());

            return l_timeInString;
        }

        public static int getTime(string m_time)
        {
            int timeObj = (convertToInt(m_time.Substring(0, 2).ToString()) * 60 * 60) + (convertToInt(m_time.Substring(3, 2).ToString()) * 60) + (convertToInt(m_time.Substring(6, 2).ToString()));
            return timeObj;
            //string l_timeInString = "";

            //int l_sec = m_sec;
            //int l_min = 0;
            //int l_hour = 0;

            //if (l_sec == 60)
            //{
            //    l_min = l_min + 1;

            //    l_sec = 0;

            //}
            //if (l_min == 60)
            //{
            //    l_hour = l_hour + 1;
            //    l_min = 0;
            //}

            //l_timeInString = l_hour < 10 ? "0" + l_hour : l_hour.ToString();
            //l_timeInString += ":" + ((l_min < 10) ? "0" + l_min : l_min.ToString());
            //l_timeInString += ":" + ((l_sec < 10) ? "0" + l_sec : l_sec.ToString());

            //return l_timeInString;
            return 0;
        }

        #region "DigitFormat"
        public static string TwoDigitFormat(double objValue)
        {
            return String.Format("{0:0.00}", objValue);
        }

        public static string ThreeDigitFormat(double objValue)
        {
            return String.Format("{0:0.000}", objValue);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objLabel"></param>
        /// <param name="success"></param>
        //public static void SetFormStatusBarSettings(ToolStripLabel objLabel)
        //{
        //    if (objLabel != null)
        //    {
        //        objLabel.ForeColor = Color.DarkBlue;
        //        objLabel.Font = new Font("Tahoma", 8.25F, FontStyle.Bold);
        //    }
        //}


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddlMonthList"> </param>
        /// <param name="setCurruntMonth"> </param>
        //public static void GetMonthList(DropDownList ddlMonthList, bool setCurruntMonth)
        //{
        //    DateTime month = Convert.ToDateTime("1/1/2000");
        //    for (var i = 0; i < 12; i++)
        //    {

        //        DateTime nextMont = month.AddMonths(i);
        //        var list = new ListItem
        //        {
        //            Text = nextMont.ToString("MMMM"),
        //            Value = nextMont.Month.ToString()
        //        };
        //        ddlMonthList.Items.Add(list);
        //    }
        //    if (setCurruntMonth == true)
        //    {
        //        ddlMonthList.Items.FindByValue(DateTime.Now.Month.ToString()).Selected = true;
        //    }

        //}
        ///// <summary>
        /// Bind DorpDownList Control with Data
        /// </summary>
        /// <param name="ddlControl"> Name of DropDownList</param>
        /// <param name="strDataValueField">Value Databound Field Name</param>
        /// <param name="strDataTextField">Text/Display Databound Field Name</param>
        /// <param name="objValue">DropDownList Data source</param>
        //public static void DropDownListBind(DropDownList ddlControl, string strDataValueField, string strDataTextField, object objValue)
        //{
        //    ddlControl.DataValueField = strDataValueField;
        //    ddlControl.DataTextField = strDataTextField;
        //    try
        //    {
        //        ddlControl.DataSource = objValue;
        //        ddlControl.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
