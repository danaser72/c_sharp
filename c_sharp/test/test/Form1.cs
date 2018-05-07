/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace test
{
    public partial class Main : Form
    {
        string strUri = "https://crix-api-endpoint.upbit.com/v1/crix/candles/";
        // https://crix-api-endpoint.upbit.com/v1/crix/candles/기간타입/기간?code=CRIX.UPBIT.마켓-암호화폐기호&count=시세데이터수&to=최종시세데이터일시
        // 
        string date_types;      // 기간타입             - minutes, days, weeks, months (hours는 없으며, minutes로 대체)
        string dates;           // 기간                 - 1,3,5,10,15,30,60,240 (minutes가 아닌 경우, 필요없음)
        string markets;         // 마켓                 - KRW, BTC, ETH, USDT
        string symbols;         // 암호화폐기호         - BTC, ETH, XRP, STEEM, SBC 등 각 마켓의 지원 암호화폐
        string counts;          // 시세데이터수         - 1(기본값), 2, 3, 4 ...
        string last_date;       // 최종시세데이터일시   - 생략시 가장 최근 시세 데이터 일시, UTC기준

        string candleDateTime;          // 일시 (UTC)
        string candleDateTimeKst;       // 일시 (KST)
        string openPrice;               // 시가
        string highPrice;               // 고가
        string lowPrice;                // 저가
        string tradePrice;              // 종가
        string candleAccTradeVolume;    // 거래량
        string candleAccTradePrice;     // 거래가

        public Main()
        {
            InitializeComponent();

            date_types = "minutes";
            dates = "1";
            markets = "KRW";
            symbols = "BTC";
            this.BTC_name.Text = symbols;
            counts = "1";
            last_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            getTime();
            getPrice();
            getList();
            getPrice_List();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getTime();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            getPrice();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            getList();
            getPrice_List();
        }

        private void getTime()
        {
            this.nowTime.Text = System.DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm:ss");
        }

        private void getPrice()
        {
            string Uri = strUri + date_types + "/" + dates + "?" + "code=CRIX.UPBIT." + markets + "-" + symbols;
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            string strResult = srReadData.ReadToEnd();

            parsingPrice(strResult);
        }

        private void getPrice_List()
        {
            // https://crix-api-endpoint.upbit.com/v1/crix/candles/기간타입/기간?code=CRIX.UPBIT.마켓-암호화폐기호&count=시세데이터수&to=최종시세데이터일시
            date_types = "minutes";
            dates = "1";
            markets = "KRW";
            this.BTC_name.Text = symbols;
            counts = "10";
            string Uri = strUri + date_types + "/" + dates + "?" + "code=CRIX.UPBIT." + markets + "-" + symbols + "&count=" + counts;
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            string strResult = srReadData.ReadToEnd();

            parsingPrice2(strResult, symbols);
        }

        private void getList()
        {
            try
            {
                string Uri = "https://coinbine.com/api/exchange/upbit";
                byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream stReadData = response.GetResponseStream();
                StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

                string strResult = srReadData.ReadToEnd();

                parsingList(strResult);
            }
            catch(WebException e)
            {
               // MessageBox.Show("게이트웨이 에러");
            }
        }

        private void parsingPrice(string data)
        {
            string[] parses = data.Split(',');
            string temp;

            candleDateTime = parses[1].Substring(("\"candleDateTime\":\"").Length, (parses[1].Length - 1 - ("\"candleDateTime\":\"").Length));
            candleDateTimeKst = parses[2].Substring(("\"candleDateTimeKst\":\"").Length, (parses[2].Length - 1 - ("\"candleDateTimeKst\":\"").Length));

            temp = parses[3].Substring(("\"openingPrice\":").Length, (parses[3].Length - ("\"openingPrice\":").Length));
            openPrice = string.Format("{0}", setPeriod(temp).ToString("#,##0"));

            temp = parses[4].Substring(("\"highPrice\":").Length, (parses[4].Length - ("\"highPrice\":").Length));
            highPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[5].Substring(("\"lowPrice\":").Length, (parses[5].Length - ("\"lowPrice\":").Length));
            lowPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[6].Substring(("\"tradePrice\":").Length, (parses[6].Length - ("\"tradePrice\":").Length));
            tradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[7].Substring(("\"candleAccTradeVolume\":").Length, (parses[7].Length - 1 - ("\"candleAccTradeVolume\":").Length));
            candleAccTradeVolume = setPeriod(temp).ToString();

            temp = parses[8].Substring(("\"candleAccTradePrice\":").Length, (parses[8].Length - ("\"candleAccTradePrice:\"").Length));
            candleAccTradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            candleDateTime = getClock(candleDateTime);
            candleDateTimeKst = getClock(candleDateTimeKst);

            upTime_val.Text = candleDateTime;
            upTimeKST_val.Text = candleDateTimeKst;
            openPrice_val.Text = openPrice;
            highPrice_val.Text = highPrice;
            lowPrice_val.Text = lowPrice;
            tradePrice_val.Text = tradePrice;
            accTradeVolume_val.Text = candleAccTradeVolume;
            accTradePrice_val.Text = candleAccTradePrice;
        }

        private void parsingPrice2(string data, string symbolss)
        {
            this.listView1.Items.Clear();
            string[] parses1 = data.Split('}');

            for (int i = 0; i < parses1.Length - 1; i++)
            {
                if (i != 0) parses1[i] = parses1[i].Substring(1);
                string[] parses = parses1[i].Split(',');
                string temp;

                candleDateTime = parses[1].Substring(("\"candleDateTime\":\"").Length, (parses[1].Length - 1 - ("\"candleDateTime\":\"").Length));
                candleDateTimeKst = parses[2].Substring(("\"candleDateTimeKst\":\"").Length, (parses[2].Length - 1 - ("\"candleDateTimeKst\":\"").Length));

                temp = parses[3].Substring(("\"openingPrice\":").Length, (parses[3].Length - ("\"openingPrice\":").Length));
                openPrice = string.Format("{0}", setPeriod(temp).ToString("#,##0"));

                temp = parses[4].Substring(("\"highPrice\":").Length, (parses[4].Length - ("\"highPrice\":").Length));
                highPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[5].Substring(("\"lowPrice\":").Length, (parses[5].Length - ("\"lowPrice\":").Length));
                lowPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[6].Substring(("\"tradePrice\":").Length, (parses[6].Length - ("\"tradePrice\":").Length));
                tradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[7].Substring(("\"candleAccTradeVolume\":").Length, (parses[7].Length - 1 - ("\"candleAccTradeVolume\":").Length));
                candleAccTradeVolume = setPeriod(temp).ToString();

                temp = parses[8].Substring(("\"candleAccTradePrice\":").Length, (parses[8].Length - ("\"candleAccTradePrice:\"").Length));
                candleAccTradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                candleDateTime = getClock(candleDateTime);
                candleDateTimeKst = getClock(candleDateTimeKst);

                ListViewItem newItem = new ListViewItem(new String[] { symbolss, openPrice, highPrice, lowPrice, tradePrice, candleAccTradeVolume, candleAccTradePrice, candleDateTimeKst });

                this.listView1.Items.Add(newItem);
            }
        }

        private void parsingList(string data)
        {
            string[] parses = data.Split('}');

            this.listView2.Items.Clear();

            for (int i = 0; i < parses.Length - 3; i++)
            {
                string[] secondParses;
                string[] thirdParses;
                
                string name_List1;
                string price_List1;
                string percent_List1;
                string volume_List1;

                ListViewItem newItem;
                
                string percentChange_List1 = "percentChange";
                bool check = parses[i].Contains(percentChange_List1);

                secondParses = parses[i].Split(',');

                int token = i == 0 ? 0 : 1;

                if (token == 0)
                {
                    secondParses[i] = secondParses[i].Substring(8);
                }

                thirdParses = secondParses[token].Split('"');
                name_List1 = thirdParses[1].ToUpper();
                price_List1 = string.Format("{0}", setPeriod(thirdParses[5]).ToString("n0")); ;
                
                if (check)
                {
                    thirdParses = secondParses[token + 1].Split('"');
                    percent_List1 = setPeriod((Double.Parse(thirdParses[3]) * 100).ToString()).ToString();

                    thirdParses = secondParses[token + 2].Split(':');
                    volume_List1 = string.Format("{0}", setPeriod(thirdParses[1]).ToString("n0"));

                    newItem = new ListViewItem(new String[] { name_List1, price_List1, percent_List1, volume_List1 });
                }
                else
                {
                    percent_List1 = "0";

                    thirdParses = secondParses[token + 1].Split(':');
                    volume_List1 = string.Format("{0}", setPeriod(thirdParses[1]).ToString("n0"));

                    newItem = new ListViewItem(new String[] { name_List1, price_List1, percent_List1, volume_List1 });
                }
                
                this.listView2.Items.Add(newItem);
                
                this.listView2.Items[i].UseItemStyleForSubItems = false;

                if (Double.Parse(percent_List1) < 0)
                {
                    this.listView2.Items[i].SubItems[2].ForeColor = Color.Blue;
                }else
                {
                    this.listView2.Items[i].SubItems[2].ForeColor = Color.Red;
                }
            }
        }

        //https://coinbine.com/api/exchange/upbit

            // ex) 2018-01-20T11:46:00+00:00 -> 2018-01-20 11:46:00
        private string getClock(string str)
        {
            string retClock = str.Substring(0, 19);
            retClock = retClock.Replace('T', ' ');

            return retClock;
        }

        private double setPeriod(string price)
        {
            double retVal;

            if (price.Contains("."))
            {
                if (price.IndexOf('.') < 3)
                {
                    retVal = Math.Round(Double.Parse(price), 2);
                }
                else
                {
                    retVal = Math.Round(Double.Parse(price), 0);
                }
            }
            else
            {
                retVal = Double.Parse(price);
            }

            return retVal;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexnum = listView2.FocusedItem.Index;
            symbols = listView2.Items[indexnum].SubItems[0].Text;
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace test
{
    public partial class Main : Form
    {
        string strUri = "https://crix-api-endpoint.upbit.com/v1/crix/candles/";
        // https://crix-api-endpoint.upbit.com/v1/crix/candles/기간타입/기간?code=CRIX.UPBIT.마켓-암호화폐기호&count=시세데이터수&to=최종시세데이터일시
        // 
        string date_types;      // 기간타입             - minutes, days, weeks, months (hours는 없으며, minutes로 대체)
        string dates;           // 기간                 - 1,3,5,10,15,30,60,240 (minutes가 아닌 경우, 필요없음)
        string markets;         // 마켓                 - KRW, BTC, ETH, USDT
        string symbols;         // 암호화폐기호         - BTC, ETH, XRP, STEEM, SBC 등 각 마켓의 지원 암호화폐
        string counts;          // 시세데이터수         - 1(기본값), 2, 3, 4 ...
        string last_date;       // 최종시세데이터일시   - 생략시 가장 최근 시세 데이터 일시, UTC기준

        string candleDateTime;          // 일시 (UTC)
        string candleDateTimeKst;       // 일시 (KST)
        string openPrice;               // 시가
        string highPrice;               // 고가
        string lowPrice;                // 저가
        string tradePrice;              // 종가
        string candleAccTradeVolume;    // 거래량
        string candleAccTradePrice;     // 거래가

        public Main()
        {
            InitializeComponent();

            date_types = "minutes";
            dates = "1";
            markets = "KRW";
            symbols = "BTC";
            this.BTC_name.Text = symbols;
            counts = "1";
            last_date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            getTime();
            getPrice();
            getList();
            getPrice_List();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getTime();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            getPrice();
        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {
            getList();
            getPrice_List();
        }

        private void getTime()
        {
            this.nowTime.Text = System.DateTime.Now.ToString("yyyy년 MM월 dd일 HH:mm:ss");
        }

        private void getPrice()
        {
            string Uri = strUri + date_types + "/" + dates + "?" + "code=CRIX.UPBIT." + markets + "-" + symbols;
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            string strResult = srReadData.ReadToEnd();

            parsingPrice(strResult);
        }

        private void getPrice_List()
        {
            // https://crix-api-endpoint.upbit.com/v1/crix/candles/기간타입/기간?code=CRIX.UPBIT.마켓-암호화폐기호&count=시세데이터수&to=최종시세데이터일시
            date_types = "minutes";
            dates = "1";
            markets = "KRW";
            this.BTC_name.Text = symbols;
            counts = "10";
            string Uri = strUri + date_types + "/" + dates + "?" + "code=CRIX.UPBIT." + markets + "-" + symbols + "&count=" + counts;
            byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
            request.Method = "GET";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Stream stReadData = response.GetResponseStream();
            StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

            string strResult = srReadData.ReadToEnd();

            parsingPrice2(strResult, symbols);
        }

        private void getList()
        {
            try
            {
                string Uri = "https://coinbine.com/api/exchange/upbit";
                byte[] byteDataParams = UTF8Encoding.UTF8.GetBytes(Uri);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Uri);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream stReadData = response.GetResponseStream();
                StreamReader srReadData = new StreamReader(stReadData, Encoding.Default);

                string strResult = srReadData.ReadToEnd();

                parsingList(strResult);
            }
            catch (WebException e)
            {
                // MessageBox.Show("게이트웨이 에러");
            }
        }

        private void parsingPrice(string data)
        {
            string[] parses = data.Split(',');
            string temp;

            candleDateTime = parses[1].Substring(("\"candleDateTime\":\"").Length, (parses[1].Length - 1 - ("\"candleDateTime\":\"").Length));
            candleDateTimeKst = parses[2].Substring(("\"candleDateTimeKst\":\"").Length, (parses[2].Length - 1 - ("\"candleDateTimeKst\":\"").Length));

            temp = parses[3].Substring(("\"openingPrice\":").Length, (parses[3].Length - ("\"openingPrice\":").Length));
            openPrice = string.Format("{0}", setPeriod(temp).ToString("#,##0"));

            temp = parses[4].Substring(("\"highPrice\":").Length, (parses[4].Length - ("\"highPrice\":").Length));
            highPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[5].Substring(("\"lowPrice\":").Length, (parses[5].Length - ("\"lowPrice\":").Length));
            lowPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[6].Substring(("\"tradePrice\":").Length, (parses[6].Length - ("\"tradePrice\":").Length));
            tradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            temp = parses[7].Substring(("\"candleAccTradeVolume\":").Length, (parses[7].Length - 1 - ("\"candleAccTradeVolume\":").Length));
            candleAccTradeVolume = setPeriod(temp).ToString();

            temp = parses[8].Substring(("\"candleAccTradePrice\":").Length, (parses[8].Length - ("\"candleAccTradePrice:\"").Length));
            candleAccTradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

            candleDateTime = getClock(candleDateTime);
            candleDateTimeKst = getClock(candleDateTimeKst);

            upTime_val.Text = candleDateTime;
            upTimeKST_val.Text = candleDateTimeKst;
            openPrice_val.Text = openPrice;
            highPrice_val.Text = highPrice;
            lowPrice_val.Text = lowPrice;
            tradePrice_val.Text = tradePrice;
            accTradeVolume_val.Text = candleAccTradeVolume;
            accTradePrice_val.Text = candleAccTradePrice;
        }

        private void parsingPrice2(string data, string symbolss)
        {
            DataTable CoinDT = new DataTable();

            DataRow CoinRw;
            CoinDT.Clear();

            chart1.Update();
            DataView Dataview;


            CoinDT.Columns.Add("TradePrice", typeof(String));
            CoinDT.Columns.Add("Time", typeof(String));

            this.listView1.Items.Clear();
            string[] parses1 = data.Split('}');

            for (int i = 0; i < parses1.Length - 1; i++)
            {
                if (i != 0) parses1[i] = parses1[i].Substring(1);
                string[] parses = parses1[i].Split(',');
                string temp;

                candleDateTime = parses[1].Substring(("\"candleDateTime\":\"").Length, (parses[1].Length - 1 - ("\"candleDateTime\":\"").Length));
                candleDateTimeKst = parses[2].Substring(("\"candleDateTimeKst\":\"").Length, (parses[2].Length - 1 - ("\"candleDateTimeKst\":\"").Length));

                temp = parses[3].Substring(("\"openingPrice\":").Length, (parses[3].Length - ("\"openingPrice\":").Length));
                openPrice = string.Format("{0}", setPeriod(temp).ToString("#,##0"));

                temp = parses[4].Substring(("\"highPrice\":").Length, (parses[4].Length - ("\"highPrice\":").Length));
                highPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[5].Substring(("\"lowPrice\":").Length, (parses[5].Length - ("\"lowPrice\":").Length));
                lowPrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[6].Substring(("\"tradePrice\":").Length, (parses[6].Length - ("\"tradePrice\":").Length));
                tradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                temp = parses[7].Substring(("\"candleAccTradeVolume\":").Length, (parses[7].Length - 1 - ("\"candleAccTradeVolume\":").Length));
                candleAccTradeVolume = setPeriod(temp).ToString();

                temp = parses[8].Substring(("\"candleAccTradePrice\":").Length, (parses[8].Length - ("\"candleAccTradePrice:\"").Length));
                candleAccTradePrice = string.Format("{0}", setPeriod(temp).ToString("n0"));

                candleDateTime = getClock(candleDateTime);
                candleDateTimeKst = getClock(candleDateTimeKst);

                ListViewItem newItem = new ListViewItem(new String[] { symbolss, openPrice, highPrice, lowPrice, tradePrice, candleAccTradeVolume, candleAccTradePrice, candleDateTimeKst });

                this.listView1.Items.Add(newItem);

                CoinRw = CoinDT.NewRow();
                //MessageBox.Show(int.Parse(tradePrice).ToString());
                CoinRw["TradePrice"] = tradePrice;
                CoinRw["Time"] = TextRight(candleDateTimeKst, 8);
                CoinDT.Rows.Add(CoinRw);
            }
            Dataview = new DataView(CoinDT);
            //dataGridView1.DataSource = Dataview;

            //chart1.ChartAreas[0].AxisY.Minimum = 166250;
            chart1.Series["Series1"].XValueMember = "Time";
            chart1.Series["Series1"].YValueMembers = "TradePrice";
            chart1.ChartAreas[0].AxisY.Minimum = Double.Parse(lowPrice) * 9 / 10;
            chart1.DataSource = CoinDT;
            chart1.DataBind();
        }

        private DataTable GetStackColumnData()
        {
            DataTable mydata = new DataTable();
            // Define the columns and their names
            mydata.Columns.Add("Series Label", typeof(string));
            mydata.Columns.Add("Segment A", typeof(int));
            mydata.Columns.Add("Segment B", typeof(int));
            mydata.Columns.Add("Segment C", typeof(int));
            mydata.Columns.Add("Segment D", typeof(int));
            // Add the rows of data
            mydata.Rows.Add(new Object[] { "Stack A", 1, 4, 10, 4 });
            mydata.Rows.Add(new Object[] { "Stack B", 3, 6, 4, 5 });
            mydata.Rows.Add(new Object[] { "Stack C", 5, 8, 6, 7 });
            mydata.Rows.Add(new Object[] { "Stack D", 7, 10, 7, 7 });
            return mydata;
        }

        public string TextRight(string Text, int TextLenth)
        {
            string ConvertText;
            if (Text.Length < Text.Length)
            {
                TextLenth = Text.Length;
            }

            ConvertText = Text.Substring(Text.Length - TextLenth, TextLenth);
            return ConvertText;
        }


        private void parsingList(string data)
        {
            string[] parses = data.Split('}');

            this.listView2.Items.Clear();

            for (int i = 0; i < parses.Length - 3; i++)
            {
                string[] secondParses;
                string[] thirdParses;

                string name_List1;
                string price_List1;
                string percent_List1;
                string volume_List1;

                ListViewItem newItem;

                string percentChange_List1 = "percentChange";
                bool check = parses[i].Contains(percentChange_List1);

                secondParses = parses[i].Split(',');

                int token = i == 0 ? 0 : 1;

                if (token == 0)
                {
                    secondParses[i] = secondParses[i].Substring(8);
                }

                thirdParses = secondParses[token].Split('"');
                name_List1 = thirdParses[1].ToUpper();
                price_List1 = string.Format("{0}", setPeriod(thirdParses[5]).ToString("n0")); ;

                if (check)
                {
                    thirdParses = secondParses[token + 1].Split('"');
                    percent_List1 = setPeriod((Double.Parse(thirdParses[3]) * 100).ToString()).ToString();

                    thirdParses = secondParses[token + 2].Split(':');
                    volume_List1 = string.Format("{0}", setPeriod(thirdParses[1]).ToString("n0"));

                    newItem = new ListViewItem(new String[] { name_List1, price_List1, percent_List1, volume_List1 });
                }
                else
                {
                    percent_List1 = "0";

                    thirdParses = secondParses[token + 1].Split(':');
                    volume_List1 = string.Format("{0}", setPeriod(thirdParses[1]).ToString("n0"));

                    newItem = new ListViewItem(new String[] { name_List1, price_List1, percent_List1, volume_List1 });
                }



                this.listView2.Items.Add(newItem);

                if (Double.Parse(percent_List1) < 0)
                {
                    this.listView2.Items[i].UseItemStyleForSubItems = false;
                    this.listView2.Items[i].SubItems[2].ForeColor = Color.Aqua;
                }
                else
                {
                    this.listView2.Items[i].UseItemStyleForSubItems = false;
                    this.listView2.Items[i].SubItems[2].ForeColor = Color.Red;
                }
            }

            //dataGridView1.DataSource = Dataview;
        }

        //https://coinbine.com/api/exchange/upbit

        // ex) 2018-01-20T11:46:00+00:00 -> 2018-01-20 11:46:00
        private string getClock(string str)
        {
            string retClock = str.Substring(0, 19);
            retClock = retClock.Replace('T', ' ');

            return retClock;
        }

        private double setPeriod(string price)
        {
            double retVal;

            if (price.Contains("."))
            {
                if (price.IndexOf('.') < 3)
                {
                    retVal = Math.Round(Double.Parse(price), 2);
                }
                else
                {
                    retVal = Math.Round(Double.Parse(price), 0);
                }
            }
            else
            {
                retVal = Double.Parse(price);
            }

            return retVal;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexnum = listView2.FocusedItem.Index;
            symbols = listView2.Items[indexnum].SubItems[0].Text;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }
    }
}
