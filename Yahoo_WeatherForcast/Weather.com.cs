using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


//引用 HashTable 
using System.Collections; 

using System.Windows.Forms;
//引用 json.net 用于解释 json 
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


//http://www.weather.com.cn/adat/sk/101110101.html 


namespace Yahoo_WeatherForcast
{
    public partial class Weather : Form
    {
        public Weather()
        {
            InitializeComponent();
        }
        DataTable dtcityinfo;
        Hashtable htcityinfo;
        private void Weather_Load(object sender, EventArgs e)
        {
            dtcityinfo = InitWeatherInfo();
            InitCombox();
            cbBoxCityName.SelectedIndex = 0;
            cbBoxCityName.Sorted = true;
            
           // htcityinfo = InitHashtable();
            
           
        }

        /*
       private void Read(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] sli = line.Split('='); //分割字符串

                //Console.WriteLine(sli[1].ToString(),sli[0].ToString());
                Console.WriteLine("city={0},cityid={1}", sli[1].ToString(), sli[0].ToString());

            }
        }
        */

        private DataTable InitWeatherInfo() { //把城市信息全部读入内存当中

            DataTable city_cityid = new DataTable("city");
            city_cityid.Columns.Add("city", typeof(string));
            city_cityid.Columns.Add("cityid", typeof(string));

           

            //获取城市名称与城市的id号码从文件当中
            string path = @".\weatherinfo.txt";
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                string[] sli = line.Split('='); //分割字符串

                DataRow dr_cityinfo = city_cityid.NewRow();
                dr_cityinfo["city"] = sli[1].ToString();
                dr_cityinfo["cityid"] = sli[0].ToString();
                city_cityid.Rows.Add(dr_cityinfo);
                //Console.WriteLine("city={0},cityid={1}", sli[1].ToString(), sli[0].ToString());

            }
            return city_cityid;

          }


        private void InitCombox()
        {
            if (dtcityinfo.Rows.Count > 0)
            {
                foreach (DataRow dr in dtcityinfo.Rows)
                {
                    cbBoxCityName.Items.Add(dr["city"].ToString());
                }
            }
        }
        private void deledtinfo() //删除 dt中相同的元素
        {
            int size = dtcityinfo.Rows.Count;
            string _name;
            bool isdual = false;

            for (int i = 0; i < size; i++)
            {


                cbBoxCityName.SelectedIndex = i;
                _name = cbBoxCityName.SelectedItem.ToString();

                foreach (DataRow dr in dtcityinfo.Rows)
                {
                    if (_name == dr["city"].ToString())
                    {

                    }
                }

            }
        }

        private Hashtable InitHashtable()
        {

            Hashtable ht = new Hashtable();
            if (dtcityinfo.Rows.Count > 0)
            {
                foreach(DataRow dr in dtcityinfo.Rows)
                {
                    ht.Add(dr["cityid"].ToString(), dr["city"].ToString());
                }
            }

            return ht;
        }


        private string GetCityIDbyName(string cityName)
        {
            string cityid;
            htcityinfo = InitHashtable();

            foreach (DictionaryEntry de in htcityinfo)
            {
                if ((string)de.Value == cityName) 
                   
                {
                    cityid = (string)de.Key;
                   // MessageBox.Show(cityid);
                    return cityid;

                }
               
            }
            return "";
        }

        private void btiGetWeatherInfo_Click(object sender, EventArgs e)
        {
           
            string cityname = cbBoxCityName.SelectedItem.ToString();
            string cityid = GetCityIDbyName(cityname);//获取城市的id编号
            string url = "http://www.weather.com.cn/adat/sk/" + cityid + ".html";
            Stream   xmlstream = System.Net.WebRequest.Create(url).GetResponse().GetResponseStream();
            StreamReader json = new StreamReader(xmlstream, Encoding.UTF8);

            string jsonstr = @json.ReadToEnd();
            json.Close();

            //DataTable dtweatherinfo = JsonConvert.DeserializeObject<DataTable>(jsonstr);

            JObject jo = (JObject)JsonConvert.DeserializeObject(jsonstr);
           
            JToken   js = (JToken )jo["weatherinfo"];




            richTextBox1.Text = js["city"].ToString() + "\n" +
                js["cityid"].ToString() + "\n" +
                js["temp"].ToString() + "\n" +
                js["WD"].ToString() + "\n" +
                js["WS"].ToString() + "\n" +
                js["SD"].ToString() + "\n" +
                js["WSE"].ToString() + "\n" +
                js["time"].ToString() + "\n" +
                js["isRadar"].ToString() + "\n" +
                js["Radar"].ToString() + "\n" +
                js["njd"].ToString() + "\n" +
                js["qy"].ToString() + "\n";
            

              
        }

    }
    
}
