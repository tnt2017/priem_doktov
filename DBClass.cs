using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using Newtonsoft.Json.Linq;

namespace test111
{
    class DBClass
    {
        public static string api_url = "https://svc.trianon-nsk.ru/clients/main/pages/jrn_kk_svc.php";

        public static string mobile_api_url = "https://svc.trianon-nsk.ru/clients/code_reader/index.php";


        public static string GET(string Url, string Data)
        {
            string myurl = Url + "?" + Data;
            System.Net.WebRequest req = System.Net.WebRequest.Create(myurl);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        public static void OracleRequest(string sel_item, DataGridView dgv, TextBox debugtb)
        {
            string s = DBClass.GET(api_url, "svc_id=" + sel_item);
            debugtb.Text = s;
            var data1 = s;
            
            if (data1.IndexOf("exec fails") > 0 && data1.IndexOf("RASHOD") < 0)
                MessageBox.Show(data1);

            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                dynamic response;

                if (sel_item == "jrn_kk")
                    response = parsed.data.jrn;
                else
                    response = parsed.data;

                dgv.DataSource = response;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void OracleRequest(string sel_item, DataGridView dgv, bool debug)
        {
            string s = DBClass.GET(api_url, "svc_id=" + sel_item);

            if(debug)
            MessageBox.Show(s);

            var data1 = s;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);
             
            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                dynamic response;

                if (sel_item.IndexOf("jrn_kk") > -1)
                    response = parsed.data.jrn;
                else
                    response = parsed.data;


                dgv.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }




        public static void OracleRequestCodeReader(string sel_item, DataGridView dgv, bool debug)
        {
            string s = DBClass.GET(mobile_api_url, "p=" + sel_item);

            if (debug)
                MessageBox.Show(s);

            var data1 = s;

            if (data1.IndexOf("exec fails") > 0)
                MessageBox.Show(data1);




            try
            {
                dynamic parsed = JsonConvert.DeserializeObject<dynamic>(data1);
                dynamic response;


                if (sel_item.IndexOf("jrn_kk") > -1)
                    response = parsed.data.jrn;
                else
                    response = parsed.data;


                dgv.DataSource = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }




    }
}
