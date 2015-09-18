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

        //http://weather.yahooapis.com/forecastrss?w=23424781&u=c
        

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
                 XmlNodeList Nodes = weather.SelectNodes("/rss/channel/item/yweather:forecast", NSMamager); //获取单个节点内的所有内容
                 //XmlNodeList picNode = weather.SelectNodes("/res/channel/image", NSMamager);
                 
                 //用于获取xml表中的元素
                 XmlElement root = weather.DocumentElement;
                 XmlNode WeatherT = root.SelectSingleNode("descendant::yweather:units", NSMamager);

                 XmlNode description = root.SelectSingleNode("descendant::description", NSMamager);

                 XmlNode Image = root.SelectSingleNode("descendant::image", NSMamager); //获取yahoo 图标的参数



                 DataSet dstWeather = new DataSet();
                 DataTable dtblWeather = new DataTable("Weather");

                 DataTable dtbWeatherUnits = new DataTable("WeatherUnits");
                 DataTable dtbdescription = new DataTable("Description");

                 DataTable dtbImage = new DataTable("Image");


                 dstWeather.Tables.Add(dtblWeather);
                 dstWeather.Tables.Add(dtbWeatherUnits);
                 dstWeather.Tables.Add(dtbdescription);
                 dstWeather.Tables.Add(dtbImage);


                 dstWeather.Tables["Weather"].Columns.Add("Date", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Week", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Weather", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Tlow", typeof(string));
                 dstWeather.Tables["Weather"].Columns.Add("Thigh", typeof(string));


                 dstWeather.Tables["WeatherUnits"].Columns.Add("temperature", typeof(string));
                 dstWeather.Tables["WeatherUnits"].Columns.Add("speed", typeof(string));


                 dstWeather.Tables["Description"].Columns.Add("description", typeof(string));


                 dstWeather.Tables["Image"].Columns.Add("width", typeof(string));
                 dstWeather.Tables["Image"].Columns.Add("height", typeof(string));
                 dstWeather.Tables["Image"].Columns.Add("url", typeof(string));

                     



   
                         //yweather:units
                         DataRow drowWeatherUnit = dstWeather.Tables["WeatherUnits"].NewRow();
                         string speed = WeatherT.Attributes["speed"].Value.ToString();
                         string temperature = WeatherT.Attributes["temperature"].Value.ToString();

                         drowWeatherUnit["temperature"] = temperature;
                         drowWeatherUnit["speed"] = speed;
                         dstWeather.Tables["WeatherUnits"].Rows.Add(drowWeatherUnit);

                          //Description
                         DataRow drowDescription = dstWeather.Tables["Description"].NewRow();
                         string descri = description.InnerText;
                         drowDescription["description"] = descri;
                         dstWeather.Tables["Description"].Rows.Add(drowDescription);


                         if (Image.HasChildNodes == true) //判断是否有子节点
                         {
                             //XmlNodeList ImageNodes = Image.ChildNodes;
                            
                                 DataRow drowImage = dstWeather.Tables["Image"].NewRow();
                                 drowImage["height"] = Image.SelectSingleNode("height").InnerText;
                                 drowImage["width"] = Image.SelectSingleNode("width").InnerText;
                                 drowImage["url"] = Image.SelectSingleNode("url").InnerText;
                                 dstWeather.Tables["Image"].Rows.Add(drowImage);
                             
                         }
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
             DataTable weatherT = WeatherDS.Tables["WeatherUnits"]; //数据数据用于测试
             DataTable description = WeatherDS.Tables["Description"];
             DataTable Image = WeatherDS.Tables["Image"]; //获取yahoo logo的参数 

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

             ColumnHeader HeaderTest = new ColumnHeader();
             HeaderTest.Width = 100;
             HeaderTest.Text = "Temperature";

             ColumnHeader HeaderTest1 = new ColumnHeader();
             HeaderTest1.Width = 100;
             HeaderTest1.Text = "Speed";


             this.listView1.Columns.Add(header1);
             this.listView1.Columns.Add(header2);
             this.listView1.Columns.Add(header3);
             this.listView1.Columns.Add(header4);
             this.listView1.Columns.Add(header5);

             this.listView2.Columns.Add(HeaderTest);
             this.listView2.Columns.Add(HeaderTest1);


             this.listView1.View = View.Details;
             this.listView2.View = View.Details;

             this.listView1.GridLines = true;
             this.listView2.GridLines = true;



             foreach (DataRow descriptionRow in description.Rows)
             {
                 string descp = descriptionRow["description"].ToString();
                 this.Text = descp;
             }

             foreach (DataRow imageinfo in Image.Rows)
             {
                 //string width = imageinfo["width"].ToString(); //获取图片的大小
                 //string height = imageinfo["height"].ToString(); //获取图片的大小
                 string url = imageinfo["url"].ToString();
                
                 //pictureBox1.Width = Convert.ToInt32(width);
                 //pictureBox1.Height = Convert.ToInt32(height);
                 pictureBox1.Image = System.Drawing.Image.FromStream(System.Net.WebRequest.Create(url).GetResponse().GetResponseStream());
             }
                 

             foreach (DataRow weatherRowT in weatherT.Rows)
             {
                 string weather = weatherRowT["temperature"].ToString();
                 string speed = weatherRowT["speed"].ToString();
                 string[] strarry = { weather,speed };
                 ListViewItem listv = new ListViewItem(strarry);
               //  MessageBox.Show(test);
                 this.listView2.Items.Add(listv);
             }

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

         private void btnEtouch_Click(object sender, EventArgs e)
         {
             Etouch etouch = new Etouch();
             etouch.Show();
         }

       }
}

