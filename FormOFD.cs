using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.IO;

namespace test111
{

    public partial class FormOFD : Form
    {
        private static readonly HttpClient client = new HttpClient();
        string login, passw, api_url, ofd_api_key, inn, kkt, fn, default_email;

        class Link
        {
            public string Rel { get; set; }
            public string Href { get; set; }
        }

        class mydata
        {
            public Link Link { get; set; }
            public string EncryptedKey { get; set; }
        }

        class mydata2
        {
            public string Sid { get; set; }
        }

        class openShift
        {

        }

        class closeShift
        {

        }

        class Receipt
        {
            public string receiptCode { get; set; }
            public string user { get; set; }
            public string userInn { get; set; }
            public string requestNumber { get; set; }
            public string dateTime { get; set; }
            public string shiftNumber { get; set; }
            public string operationType { get; set; }
            public string taxationType { get; set; }
            public string _operator { get; set; }
            public string kktRegId { get; set; }
            public string fiscalDriveNumber { get; set; }
            public string retailPlaceAddress { get; set; }

            public string nds20 { get; set; }
            public string totalSum { get; set; }
            public string cashTotalSum { get; set; }

            /* "ecashTotalSum": 0,
             "prePaymentTotalSum": 0,
             "postPaymentTotalSum": 0,
             "considerationTotalSum": 0,
             "fiscalDocumentNumber": 9650,
             "fiscalSign": 831788621*/

            public string fiscalDocumentNumber { get; set; }
            public string fiscalSign { get; set; }
        }

        class check
        {
            public Receipt Receipt { get; set; }
        }

        class checksList
        {
            public List<check> check { get; set; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_tickets(textBox_d1.Text, textBox_d2.Text);

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        int days_delta = 0;


        public FormOFD()
        {
            InitializeComponent();
        }

        public void get_sid()
        {
            /*string result = "";

            HttpClient client = new HttpClient();
            String s = "https://api.kontur.ru/auth/authenticate-by-pass?login=" + login;
            var task = client.PostAsync(s, new StringContent(passw));
            task.Wait();
            task.ContinueWith((t) =>
            {
                var tresult = t.Result;
                result = tresult;
            });



            //var responseString = response.Content.ReadAsStringAsync();
            //  textBox1.Text = responseString;
            mydata2 parsed = JsonConvert.DeserializeObject<mydata2>(result.ToString());
             textBox2.Text = parsed.Sid;
             button3_Click(null, null);
             */


            String Url = "https://api.kontur.ru/auth/authenticate-by-pass?login=" + login;
            StringContent Data = new StringContent(passw);

               System.Net.WebRequest req = System.Net.WebRequest.Create(Url); // + "?" + Data

            req.Method = "POST";
            req.ContentType = "application/json";


            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {
                string json = "password=" + passw; //"{\"user\":\"test\"," +  //"\"password\":\"bla\"}";
                streamWriter.Write(json);
            }

            System.Net.WebResponse resp = req.GetResponse();
               System.IO.Stream stream = resp.GetResponseStream();
               System.IO.StreamReader sr = new System.IO.StreamReader(stream);
               string Out = sr.ReadToEnd();
               sr.Close();
               //return Out;
        }

        public void get_tickets(string d1, string d2)
        {
            listBox1.Items.Clear();

            string s = api_url + "/v1/integration/inns/" + inn + "/kkts/" + kkt + "/fss/" + fn + "/tickets?dateFrom=" + d1 + "&dateTo=" + d2;
            Uri uri = new Uri(s);

            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();

            handler.CookieContainer.Add(uri, new Cookie("ofd_api_key", ofd_api_key)); // Adding a Cookie
            handler.CookieContainer.Add(uri, new Cookie("auth.sid", textBox2.Text)); // Adding a Cookie

            HttpClient client1 = new HttpClient(handler);
            client1.GetStringAsync(s).Wait();


           // var responseString = await response.Content.ReadAsStringAsync();
           /*  textBox1.Text = responseString;

             if (responseString.IndexOf("error") > 0)
             {
                 MessageBox.Show(responseString);
             }
             else
             {
                 List<check> parsed = JsonConvert.DeserializeObject<List<check>>(responseString);

                 for (int i = 1; i < parsed.Count - 1; i++)
                 {
                     try
                     {
                         textBox_fd.Text = parsed[i].Receipt.fiscalDocumentNumber;
                         textBox_fp.Text = parsed[i].Receipt.fiscalSign;


                         // MessageBox.Show(parsed[i].Receipt.userInn);

                         string temp = parsed[i].Receipt.fiscalDocumentNumber + ":" + parsed[i].Receipt.fiscalSign + ":" + Convert.ToDouble(parsed[i].Receipt.totalSum) / 100 + "\r\n";
                         //textBox5.Text += temp;
                         listBox1.Items.Add(temp);
                     }
                     catch (Exception ex)
                     {

                     }
                 }

                 if (checkBox_autostart.Checked)
                 {
                     //timer1.Enabled = true;
                 }

                 //toolStripStatusLabel2.Text = "В ОФД: " + listBox1.Items.Count.ToString();
             }
             */

        }
        /*
        public async void get_ticket(string fd)
        {
            string s = api_url + "/v1/integration/inns/" + inn + "/kkts/" + kkt + "/fss/" + fn + "/tickets/" + fd;
            Uri uri = new Uri(s);
            MessageBox.Show(s);

            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new CookieContainer();

            handler.CookieContainer.Add(uri, new Cookie("ofd_api_key", ofd_api_key)); // Adding a Cookie
            handler.CookieContainer.Add(uri, new Cookie("auth.sid", textBox2.Text)); // Adding a Cookie

            HttpClient client1 = new HttpClient(handler);
            HttpResponseMessage response = await client1.GetAsync(uri);

            var responseString = await response.Content.ReadAsStringAsync();
            textBox1.Text = responseString;

            if (responseString.IndexOf("error") > 0)
            {
                MessageBox.Show(responseString);
            }
            else
            {
                check parsed = JsonConvert.DeserializeObject<check>(responseString);
                textBox_fd.Text = parsed.Receipt.fiscalDocumentNumber;
                textBox_fp.Text = parsed.Receipt.fiscalSign;
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            get_sid();
        }

        private void FormOFD_Load(object sender, EventArgs e)
        {
            login = ConfigurationManager.AppSettings["login"];
            passw = ConfigurationManager.AppSettings["passw"];
            api_url = ConfigurationManager.AppSettings["api_url"];
            ofd_api_key = ConfigurationManager.AppSettings["ofd_api_key"];
            inn = ConfigurationManager.AppSettings["inn"];
            kkt = ConfigurationManager.AppSettings["kkt"];
            fn = ConfigurationManager.AppSettings["fn"];
            default_email = ConfigurationManager.AppSettings["default_email"];
            textBox_email.Text = default_email;
            days_delta = Convert.ToInt32(ConfigurationManager.AppSettings["days_delta"]);
            checkBox_autostart.Checked = Convert.ToBoolean(ConfigurationManager.AppSettings["autostart"]);

        }
    }
}
