using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;


namespace Yahoo_WeatherForcast
{
    public partial class Etouch : Form
    {
        public Etouch()
        {
            InitializeComponent();
        }

        private void btnSendReq_Click(object sender, EventArgs e)
        {
            DataSet2Listview();
        }

          //获取etouch api数据,并用Listview显示出来
        //  请求例子 http://wthrcdn.etouch.cn/WeatherApi?city=江门
        private DataSet ReadXMl(string XMLFileStream)
        {
            try
            {
               
               
                XmlDocument doc = new XmlDocument();
                doc.Normalize();
               // doc.Load(XMLFileStream);
               //doc.Load()
                string url = string.Format("{0}","http://wthrcdn.etouch.cn/WeatherApi?city=江门");
               System.IO.Stream xmlstream =
                   System.Net.WebRequest.Create(url).GetResponse().GetResponseStream();

              // doc.Load(xmlstream);

               StreamReader newxmlstream = new StreamReader(xmlstream, Encoding.UTF8);
               doc.Load(newxmlstream);
               
                
                XmlNode xn = doc.SelectSingleNode("resp");

                DataSet dstWeather = new DataSet();
                DataTable dtNormal = new DataTable("normal");

                dstWeather.Tables.Add(dtNormal);

                dstWeather.Tables["normal"].Columns.Add("city", typeof(string));
                dstWeather.Tables["normal"].Columns.Add("wendu", typeof(string));
                dstWeather.Tables["normal"].Columns.Add("shidu", typeof(string));

                if (xn.HasChildNodes == true) //判断是否有子节点
                {

                    DataRow drowNormal = dstWeather.Tables["normal"].NewRow();
                    drowNormal["city"] = xn.SelectSingleNode("city").InnerText;
                    drowNormal["wendu"] = xn.SelectSingleNode("wendu").InnerText;
                    drowNormal["shidu"] = xn.SelectSingleNode("shidu").InnerText;
                    dstWeather.Tables["normal"].Rows.Add(drowNormal);

                }

                return dstWeather;


            }
            catch (Exception exc)
            {
                DataSet dstWeather = new DataSet();
                DataTable dtNormal = new DataTable("normal");
                dstWeather.Tables.Add(dtNormal);
                dstWeather.Tables["normal"].Columns.Add("city", typeof(string));
                dstWeather.Tables["normal"].Columns.Add("wendu", typeof(string));
                dstWeather.Tables["normal"].Columns.Add("shidu", typeof(string));

                DataRow drowNormal = dstWeather.Tables["normal"].NewRow();
                drowNormal["city"] = "none";
                drowNormal["wendu"] = "none";
                drowNormal["shidu"] = "none";
                dstWeather.Tables["normal"].Rows.Add(drowNormal);
                MessageBox.Show(exc.Message);
                return dstWeather;
            }
        }


        private void DataSet2Listview()
        {
           // DataSet WeatherDS = ReadXMl(@txtReqInput.Text.ToString());
            DataSet WeatherDS = ReadXMl(@"H:\etouch.xml");
            DataTable EtouchWeather = WeatherDS.Tables["normal"]; //取出天气表格

            //定义列表头
            ColumnHeader header1 = new ColumnHeader(); //定义列头1
            header1.Width = 100;
            header1.Text = "City";

            ColumnHeader header2 = new ColumnHeader();
            header2.Width = 100;
            header2.Text = "wendu";

            ColumnHeader header3 = new ColumnHeader();
            header3.Width = 100;
            header3.Text = "shidu";

            this.listView1.Columns.Add(header1);
            this.listView1.Columns.Add(header2);
            this.listView1.Columns.Add(header3);

            this.listView1.View = View.Details;
            this.listView1.GridLines = true;


            foreach (DataRow dr in EtouchWeather.Rows)
            {
                string city = dr["city"].ToString();
                string wendu = dr["wendu"].ToString();
                string shidu = dr["shidu"].ToString();
                string[] sarry = { city, wendu, shidu };
                ListViewItem list = new ListViewItem(sarry);
                this.listView1.Items.Add(list);
            }
                

        }
    }
}
