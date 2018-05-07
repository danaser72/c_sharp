using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TweetSharp;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.IO;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;


namespace Commuter
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private static string access_token = "";
        private static string access_token_secret = "";
        private static string customer_key = "";
        private static string customer_key_secret = "";
        private static string Type = "2";

        private static TwitterService service = new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);
        string connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ack\test.accdb";



        public MainWindow()
        {
            InitializeComponent();

            cal1.Visibility = System.Windows.Visibility.Hidden;

            GetUserInfo();
            GetAllTweets();
        }

        private void ExcelImport(string Dt)
        {
            string CC = Dt;

            System.Data.DataTable Gdt = new System.Data.DataTable();

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                string sql = "";
                sql = @"select * from CommuteMngm ";
                sql = sql + "where UserDate = '" + CC + "' ";
                sql = sql + " and Type = '" + Type + "' ";

                OleDbCommand cmd = new OleDbCommand(sql, conn);

                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(Gdt);

                if (Gdt.Rows.Count > 0) //값이 있을 때
                {
                    Excel.Application excelApp = null;
                    Excel.Workbook wb = null;
                    Excel.Worksheet ws = null;
                    String ExcelPath = @"C:\ack\sample.xls";        // 양식 파일 위치 넣기
                    String path = @"C:\ack\emrinf_" + Dt;           // 저장할 파일 위치 및 날짜

                    try
                    {
                        excelApp = new Excel.Application();

                        wb = excelApp.Workbooks.Open(ExcelPath);
                        ws = wb.Worksheets.Item[1];
                        Range range = ws.Cells[4, 2];

                        int cnt = 0;

                        while (true)
                        {
                            Range temp = ws.Cells[4 + cnt, 2];

                            if (temp.Text == "")
                            {
                                break;
                            }
                            cnt++;
                        }

                        Range nowDt = ws.Cells[2, 4];
                        nowDt.Value = Dt[0].ToString() + Dt[1].ToString() + "-"
                            + Dt[2].ToString() + Dt[3].ToString() + "-"
                            + Dt[4].ToString() + Dt[5].ToString();


                        for (int i = 0; i < Gdt.Rows.Count; i++)
                        {
                            DataRow row = Gdt.Rows[i];
                            string Commute = row["Commute"].ToString();
                            string UserDate = row["UserDate"].ToString();
                            string UserTime = row["UserTime"].ToString();
                            string Type = row["Type"].ToString();
                            string Name = row["Name"].ToString();

                            //수정 modifyData(_name, _time, _type, cnt, ws);
                            modifyData(Name, UserTime, Type, cnt, ws);
                        }



                        wb.SaveAs(path);
                        wb.Close();
                        excelApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        ReleaseExcelObject(ws);
                        ReleaseExcelObject(wb);
                        ReleaseExcelObject(excelApp);
                    }



                    //닫기
                    //저장

                }

                conn.Close();
            }
        }


        private void InsertInfo(string Commute, string msg, string UserDate, string UserTime, string Type, string UserName)
        {
            string sql = "";


            System.Data.DataTable Gdt = new System.Data.DataTable();

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                string UserTime1 = UserTime;
                string UserTime2 = UserTime;
                string UserTime3 = UserTime;

                int UserTime2_1_1 = 0;
                string AllUserTime = "";

                UserTime1 = (Int32.Parse(UserTime1.Substring(0, 2)) + 9).ToString();
                UserTime2 = UserTime2.Substring(2, 2);
                UserTime3 = UserTime.Substring(4, 2);
                UserTime2_1_1 = (Int32.Parse(UserTime1)) / 24;


                if (UserTime2_1_1 <= 0)
                {
                    AllUserTime = UserTime1 + ":" + UserTime2 + ":" + UserTime3;
                }
                else if (UserTime2_1_1 > 0)
                {
                    //날짜 1일추가
                    DateTime parsedDate = DateTime.Parse(UserDate);
                    parsedDate = parsedDate.AddDays(+1);
                    UserDate = parsedDate.ToString();


                    AllUserTime = (Int32.Parse(UserTime1) - 24).ToString() + ":" + UserTime2 + ":" + UserTime3;
                    AllUserTime = "0" + AllUserTime;
                }



                sql = @"select * from CommuteMngm ";
                sql = sql + "where Commute = '" + Commute + "' ";
                sql = sql + " and msg = '" + msg + "' ";
                sql = sql + " and Name = '" + UserName + "' ";
                sql = sql + " and Type = '" + Type + "' ";
                sql = sql + " and UserTime = '" + AllUserTime + "' ";
                sql = sql + " and UserDate = '" + UserDate + "' ";

                OleDbCommand cmd = new OleDbCommand(sql, conn);

                conn.Open();

                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(Gdt);

                if (Gdt.Rows.Count == 0) //값이 없을 때
                {


                    sql = @"insert into CommuteMngm";
                    sql = sql + "( Commute, msg, UserDate, UserTime, Type, Name )";
                    sql = sql + " values ";
                    sql = sql + "( '" + Commute + "','" + msg + "', '" + UserDate + "' , '" + AllUserTime + "', '" + Type + "' , '" + UserName + "' )";

                    OleDbCommand cmd2 = new OleDbCommand(sql, conn);

                    OleDbDataAdapter adapter2 = new OleDbDataAdapter(cmd2);

                    cmd2.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        private void GetUserInfo()
        {
            string sql = @"select  * from USERINFO where Type = '" + Type + "'";

            System.Data.DataTable dt = new System.Data.DataTable();

            using (OleDbConnection conn = new OleDbConnection(connStr))
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                try
                {
                    conn.Open();
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);

                adapter.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    string Name = row["Name"].ToString();
                    string Path = row["Type"].ToString();

                    userList.Items.Add(Name);
                }

                conn.Close();
            }

        }

        private void GetAllTweets()
        {
            try
            {
                var currentTweets = service.ListTweetsOnHomeTimeline(new ListTweetsOnHomeTimelineOptions
                {
                    Count = 100,
                });

                string prefix2 = "";

                if (currentTweets != null)
                {
                    foreach (var tweet in currentTweets)
                    {
                        string prefix = $"[{tweet.CreatedDate}] ";
                        if (pastTweetsList.Items.Contains(prefix + tweet.Text) == false)
                        {
                            String TweeterText = tweet.Text.Replace("@aaa", "").Replace("@bbb", "").Trim();
                            String TweeterDate = prefix.Replace("[", "").Substring(0, 10);

                            string TweeterTime2 = prefix.Replace("[", "");
                            TweeterTime2 = TweeterTime2.Replace("]", "");
                            TweeterTime2 = TweeterTime2.Trim();
                            TweeterTime2 = TweeterTime2.Replace(" ", "");


                            if (TweeterTime2.IndexOf("오전") >= 0)
                            {

                                TweeterTime2 = TweeterTime2.Replace("-", "");

                                string a1 = TweeterTime2.Substring(TweeterTime2.IndexOf("오전"), 4);
                                string a2 = a1.Substring(3, 1);

                                if (a2 == ":")
                                    TweeterTime2 = TweeterTime2.Replace("오전", "0");
                                else
                                    TweeterTime2 = TweeterTime2.Replace("오전", "");

                                TweeterTime2 = TweeterTime2.Replace(":", "");

                                TweeterTime2 = TweeterTime2.Substring(8, 6);
                            }
                            else if (TweeterTime2.IndexOf("오후") >= 0)
                            {

                                TweeterTime2 = TweeterTime2.Replace("-", "");

                                string a1 = TweeterTime2.Substring(TweeterTime2.IndexOf("오후"), 4);
                                string a2 = a1.Substring(3, 1);

                                if (a2 == ":")
                                    TweeterTime2 = TweeterTime2.Replace("오후", "0");
                                else
                                    TweeterTime2 = TweeterTime2.Replace("오후", "");

                                TweeterTime2 = TweeterTime2.Replace(":", "");

                                int a12 = Int32.Parse(TweeterTime2.Substring(8, 2)) + 12;
                                string a = TweeterTime2.Substring(0, 8);
                                string b = a12.ToString();

                                //   MessageBox.Show(prefix + "/" + a1 + "/" + a2 + "/" + TweeterTime2);
                                string c = TweeterTime2.Substring(10, 4);


                                TweeterTime2 = b + c;
                            }
                            else
                            {
                                return;
                            }

                            string TweeterTime = TweeterTime2;
                            string TweeterName = prefix;

                            if (TweeterText.IndexOf("출근") >= 0) //출근일때
                            {
                                for (int j = 0; j < userList.Items.Count; j++)
                                {
                                    string getName = userList.Items[j].ToString();


                                    if (TweeterText.IndexOf(getName) >= 0)
                                    {

                                        // MessageBox.Show(TweeterText + "/" + TweeterDate + "/" + TweeterTime + "/" + TweeterName + "/");
                                        // MessageBox.Show(prefix + "/" + "마무리 Insert");


                                        InsertInfo("출근", TweeterText, TweeterDate, TweeterTime, Type, getName);
                                    }
                                }
                                pastTweetsList.Items.Add(prefix + " - " + TweeterText);
                            }
                            else if (TweeterText.IndexOf("퇴근") >= 0) //퇴근일때
                            {
                                pastTweetsList.Items.Add(prefix + " - " + TweeterText);
                            }
                        }
                        else
                        {
                            return;
                        }
                        prefix2 = prefix;
                    }
                }
                else
                {
                    MessageBox.Show("트위터의 API연결상태가 좋지않습니다.\r\n잠시후에 이용해주세요.");
                    Close();
                }
            }
            catch (InvalidCastException e)
            {
                MessageBox.Show("Error! : \r\n" + e.Message);
            }

        }

        public void WriteExcelData(String Dt)
        {
            // 달력에서 원하는 날짜를 여기다가 넣어주세요
            string dates = Dt;



        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private static void modifyData(String _name, String _time, String _type, int cnt, Excel.Worksheet ws)
        {
            for (int j = 0; j < cnt; j++)
            {
                Range name = ws.Cells[1 + j, 3];

                if (_name.Equals(name.Text))
                {
                    // 출근
                    if (_type.Equals("출근"))
                    {
                        Range setTime = ws.Cells[1 + j, 5];
                        setTime.Value = _time;
                    }
                    // 퇴근
                    else if (_type.Equals("퇴근"))
                    {
                        Range setTime = ws.Cells[1 + j, 8];
                        setTime.Value = _time;
                    }
                }
            }
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {
            cal1.Visibility = System.Windows.Visibility.Visible;
            Type = "1";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            cal1.Visibility = System.Windows.Visibility.Visible;
            Type = "2";
        }

        private void cal1_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            cal1.Visibility = System.Windows.Visibility.Hidden;
            String temp = e.AddedItems[0].ToString();
            String _date = temp[2].ToString() + temp[3].ToString() + temp[5].ToString() + temp[6].ToString() + temp[8].ToString() + temp[9].ToString();

            if (Type == "1")
            {
                ExcelImport(_date);
            }
            else if (Type == "2")
            {
                ExcelImport(_date);
            }
        }

        private void cal1_MouseLeave(object sender, MouseEventArgs e)
        {
            cal1.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}

