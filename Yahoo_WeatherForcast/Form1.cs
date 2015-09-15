using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.WebSockets;
using System.Net;
using System.IO;
using System.Xml;


namespace Yahoo_WeatherForcast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
           // string req = string.Format("{0}", "http://weather.yahooapis.com/forecastrss/?w=23424781&u=c");
           // txtRequest.Text = req;

        }

        /*
         public static string GetHtml(string url, Encoding encoding)
       {
        string html = string.Empty;
        try
        {
            WebRequest request;
            request = WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 20000;
            WebResponse response;
            response = request.GetResponse();
            html = new StreamReader(response.GetResponseStream(), encoding).ReadToEnd(); //此处返回的数据为 xml数据 

        }
        catch (System.UriFormatException uex)
        {
            Console.WriteLine(uex.Message);
        }
        catch (System.Net.WebException ex)
        {
            Console.WriteLine(ex.Message);
        }
        return html;
       }

        */

        //获取yahoo api数据,并用Listview显示出来
         private DataSet ReadXMl(string XMLFileStream)
         {

             try
             {
                 XmlDocument weather = new XmlDocument();

                 //weather.Load(XMLFileStream);
                 weather.Load(txtRequest.Text); //直接通过读取URL获取xml数据 
                 XmlNamespaceManager NSMamager = new XmlNamespaceManager(weather.NameTable); //NameSpaceManager -> NSManager
                 NSMamager.AddNamespace("yweather", "http://xml.weather.yahoo.com/ns/rss/1.0");
                 XmlNodeList Nodes = weather.SelectNodes("/rss/channel/item/yweather:forecast", NSMamager);
                 //XmlNodeList picNode = weather.SelectNodes("/res/channel/image", NSMamager);



                 DataSet dstWeather = new DataSet();
                 DataTable dtblWeather = new DataTable("Weather");
                 dstWeather.Tables.Add(dtblWeather);

                 dstWeather.Tables["Weather"].Columns.Add("Date", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Week", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Weather", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Tlow", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Thigh", typeof(string));

                 if (Nodes.Count > 0)
                 {
                     foreach (XmlNode node in Nodes)
                     {
                         DataRow drowWeather = dstWeather.Tables["Weather"].NewRow();

                         drowWeather["Date"] = node.SelectSingleNode
     ("@date").Value.ToString();
                         drowWeather["Week"] = node.SelectSingleNode
     ("@day").Value.ToString() + "(" + node.SelectSingleNode("@day").Value.ToString()
     + ")";
                         drowWeather["Weather"] = node.SelectSingleNode("@text").Value;

                         drowWeather["Tlow"] = int.Parse(node.SelectSingleNode
     ("@low").Value) + "℃";
                         drowWeather["Thigh"] = int.Parse(node.SelectSingleNode
     ("@high").Value) + "℃";
                         /*
                         drowWeather["Tlow"] =  FToC( int.Parse( node.SelectSingleNode
     ("@low").Value)) + "C";
                         drowWeather["Thigh"] = FToC(  int.Parse(node.SelectSingleNode
     ("@high").Value)) + "C";
                          */

                         dstWeather.Tables["Weather"].Rows.Add(drowWeather);
                     }

                     return dstWeather;
                 }
                 else
                 {
                     DataRow drowNone = dstWeather.Tables["Weather"].NewRow();
                     drowNone["Week"] = "None";
                     drowNone["Weather"] = "None";
                     drowNone["Tlow"] = "None";
                     drowNone["Thigh"] = "None";

                     dstWeather.Tables["Weather"].Rows.Add(drowNone);
                     return dstWeather;
                 }

             }
             catch (XmlException xmle)
             {
                 MessageBox.Show(xmle.Message);

                 DataSet dsWeather = new DataSet();
                 DataTable dtblWeather = new DataTable("Weather");
                 dsWeather.Tables.Add(dtblWeather);
                 DataRow drowNone = dsWeather.Tables["Weather"].NewRow();
                 dsWeather.Tables["Weather"].Columns.Add("Date", typeof(string));
                 dsWeather.Tables["Weather"].Columns.Add("Week", typeof(string));
                 dsWeather.Tables["Weather"].Columns.Add("Weather", typeof(string));
                 dsWeather.Tables["Weather"].Columns.Add("Tlow", typeof(string));
                 dsWeather.Tables["Weather"].Columns.Add("Thigh", typeof(string));

                 drowNone["Week"] = "None";
                 drowNone["Weather"] = "None";
                 drowNone["Tlow"] = "None";
                 drowNone["Thigh"] = "None";

                 dsWeather.Tables["Weather"].Rows.Add(drowNone);

                 return dsWeather;


                 
             }
         }

         /// <summary>
         /// 从华氏转换成摄氏
         /// </summary>
         /// <param name="f">华氏度</param>
         /// <returns></returns>
         private string FToC(int f)
         {
             return Math.Round((f - 32) / 1.8, 1).ToString();
         }


         private void btnSentRequest_Click(object sender, EventArgs e)
         {
             //WebRequest
             Encoding encoding = Encoding.UTF8;

             //string html = GetHtml(txtRequest.Text, encoding);


             DataSet WeatherDS = ReadXMl(txtRequest.Text);
             DataTable WeatherDt = WeatherDS.Tables["Weather"]; //取出天气表格

             //定义列表头
             ColumnHeader header1 = new ColumnHeader(); //定义列头1
             header1.Width = 100;
             header1.Text = "Date";

             ColumnHeader header2 = new ColumnHeader();
             header2.Width = 100;
             header2.Text = "Week";

             ColumnHeader header3 = new ColumnHeader();
             header3.Width = 100;
             header3.Text = "Weather";

             ColumnHeader header4 = new ColumnHeader();
             header4.Width = 100;
             header4.Text = "TLow";

             ColumnHeader header5 = new ColumnHeader();
             header5.Width = 100;
             header5.Text = "THight";

             this.listView1.Columns.Add(header1);
             this.listView1.Columns.Add(header2);
             this.listView1.Columns.Add(header3);
             this.listView1.Columns.Add(header4);
             this.listView1.Columns.Add(header5);

             this.listView1.View = View.Details;

             this.listView1.GridLines = true;

             
             foreach (DataRow weatherRow in WeatherDt.Rows)
             {
                 
               
                 string Date = weatherRow["Date"].ToString();
                 string Week = weatherRow["Week"].ToString();
                 string Weather = weatherRow["Weather"].ToString();
                 string Tlow = weatherRow["Tlow"].ToString();
                 string Thigh = weatherRow["Thigh"].ToString();
                 string[] sArry = { Date, Week, Weather, Tlow, Thigh };
                 ListViewItem list = new ListViewItem(sArry);
                 this.listView1.Items.Add(list);


             }      
         }

       }
}

