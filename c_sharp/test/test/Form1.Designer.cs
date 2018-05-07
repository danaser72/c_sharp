
/*namespace test
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.nowTime = new System.Windows.Forms.Label();
            this.nowTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.getPriceTimer = new System.Windows.Forms.Timer(this.components);
            this.upTime_name = new System.Windows.Forms.Label();
            this.upTime_val = new System.Windows.Forms.Label();
            this.BTC_name = new System.Windows.Forms.Label();
            this.openPrice_name = new System.Windows.Forms.Label();
            this.highPrice_name = new System.Windows.Forms.Label();
            this.lowPrice_name = new System.Windows.Forms.Label();
            this.tradePrice_name = new System.Windows.Forms.Label();
            this.accTradeVolume_name = new System.Windows.Forms.Label();
            this.accTradePrice_name = new System.Windows.Forms.Label();
            this.openPrice_val = new System.Windows.Forms.Label();
            this.accTradeVolume_val = new System.Windows.Forms.Label();
            this.accTradePrice_val = new System.Windows.Forms.Label();
            this.highPrice_val = new System.Windows.Forms.Label();
            this.tradePrice_val = new System.Windows.Forms.Label();
            this.lowPrice_val = new System.Windows.Forms.Label();
            this.upTimeKST_val = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.highPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lowPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tradePrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accTradeVolume_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accTradePrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upTime_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.getListTimer = new System.Windows.Forms.Timer(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.name_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.percent_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tradeVolume_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // nowTime
            // 
            this.nowTime.AutoSize = true;
            this.nowTime.Font = new System.Drawing.Font("굴림", 30F);
            this.nowTime.Location = new System.Drawing.Point(17, 14);
            this.nowTime.Name = "nowTime";
            this.nowTime.Size = new System.Drawing.Size(0, 40);
            this.nowTime.TabIndex = 1;
            // 
            // nowTimeTimer
            // 
            this.nowTimeTimer.Enabled = true;
            this.nowTimeTimer.Interval = 1000;
            this.nowTimeTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // getPriceTimer
            // 
            this.getPriceTimer.Enabled = true;
            this.getPriceTimer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // upTime_name
            // 
            this.upTime_name.AutoSize = true;
            this.upTime_name.Location = new System.Drawing.Point(370, 79);
            this.upTime_name.Name = "upTime_name";
            this.upTime_name.Size = new System.Drawing.Size(81, 12);
            this.upTime_name.TabIndex = 4;
            this.upTime_name.Text = "업데이트 시간";
            // 
            // upTime_val
            // 
            this.upTime_val.AutoSize = true;
            this.upTime_val.Font = new System.Drawing.Font("굴림", 20F);
            this.upTime_val.Location = new System.Drawing.Point(367, 91);
            this.upTime_val.Name = "upTime_val";
            this.upTime_val.Size = new System.Drawing.Size(0, 27);
            this.upTime_val.TabIndex = 3;
            // 
            // BTC_name
            // 
            this.BTC_name.AutoSize = true;
            this.BTC_name.Location = new System.Drawing.Point(22, 79);
            this.BTC_name.Name = "BTC_name";
            this.BTC_name.Size = new System.Drawing.Size(0, 12);
            this.BTC_name.TabIndex = 5;
            // 
            // openPrice_name
            // 
            this.openPrice_name.AutoSize = true;
            this.openPrice_name.Location = new System.Drawing.Point(22, 104);
            this.openPrice_name.Name = "openPrice_name";
            this.openPrice_name.Size = new System.Drawing.Size(29, 12);
            this.openPrice_name.TabIndex = 6;
            this.openPrice_name.Text = "시가";
            // 
            // highPrice_name
            // 
            this.highPrice_name.AutoSize = true;
            this.highPrice_name.Location = new System.Drawing.Point(22, 128);
            this.highPrice_name.Name = "highPrice_name";
            this.highPrice_name.Size = new System.Drawing.Size(29, 12);
            this.highPrice_name.TabIndex = 6;
            this.highPrice_name.Text = "고가";
            // 
            // lowPrice_name
            // 
            this.lowPrice_name.AutoSize = true;
            this.lowPrice_name.Location = new System.Drawing.Point(22, 152);
            this.lowPrice_name.Name = "lowPrice_name";
            this.lowPrice_name.Size = new System.Drawing.Size(29, 12);
            this.lowPrice_name.TabIndex = 6;
            this.lowPrice_name.Text = "저가";
            // 
            // tradePrice_name
            // 
            this.tradePrice_name.AutoSize = true;
            this.tradePrice_name.Location = new System.Drawing.Point(22, 176);
            this.tradePrice_name.Name = "tradePrice_name";
            this.tradePrice_name.Size = new System.Drawing.Size(29, 12);
            this.tradePrice_name.TabIndex = 6;
            this.tradePrice_name.Text = "종가";
            // 
            // accTradeVolume_name
            // 
            this.accTradeVolume_name.AutoSize = true;
            this.accTradeVolume_name.Location = new System.Drawing.Point(22, 200);
            this.accTradeVolume_name.Name = "accTradeVolume_name";
            this.accTradeVolume_name.Size = new System.Drawing.Size(41, 12);
            this.accTradeVolume_name.TabIndex = 6;
            this.accTradeVolume_name.Text = "거래량";
            // 
            // accTradePrice_name
            // 
            this.accTradePrice_name.AutoSize = true;
            this.accTradePrice_name.Location = new System.Drawing.Point(22, 224);
            this.accTradePrice_name.Name = "accTradePrice_name";
            this.accTradePrice_name.Size = new System.Drawing.Size(41, 12);
            this.accTradePrice_name.TabIndex = 6;
            this.accTradePrice_name.Text = "거래가";
            // 
            // openPrice_val
            // 
            this.openPrice_val.AutoSize = true;
            this.openPrice_val.Location = new System.Drawing.Point(163, 104);
            this.openPrice_val.Name = "openPrice_val";
            this.openPrice_val.Size = new System.Drawing.Size(0, 12);
            this.openPrice_val.TabIndex = 6;
            // 
            // accTradeVolume_val
            // 
            this.accTradeVolume_val.AutoSize = true;
            this.accTradeVolume_val.Location = new System.Drawing.Point(163, 200);
            this.accTradeVolume_val.Name = "accTradeVolume_val";
            this.accTradeVolume_val.Size = new System.Drawing.Size(0, 12);
            this.accTradeVolume_val.TabIndex = 6;
            // 
            // accTradePrice_val
            // 
            this.accTradePrice_val.AutoSize = true;
            this.accTradePrice_val.Location = new System.Drawing.Point(163, 224);
            this.accTradePrice_val.Name = "accTradePrice_val";
            this.accTradePrice_val.Size = new System.Drawing.Size(0, 12);
            this.accTradePrice_val.TabIndex = 6;
            // 
            // highPrice_val
            // 
            this.highPrice_val.AutoSize = true;
            this.highPrice_val.Location = new System.Drawing.Point(163, 128);
            this.highPrice_val.Name = "highPrice_val";
            this.highPrice_val.Size = new System.Drawing.Size(0, 12);
            this.highPrice_val.TabIndex = 6;
            // 
            // tradePrice_val
            // 
            this.tradePrice_val.AutoSize = true;
            this.tradePrice_val.Location = new System.Drawing.Point(163, 176);
            this.tradePrice_val.Name = "tradePrice_val";
            this.tradePrice_val.Size = new System.Drawing.Size(0, 12);
            this.tradePrice_val.TabIndex = 6;
            // 
            // lowPrice_val
            // 
            this.lowPrice_val.AutoSize = true;
            this.lowPrice_val.Location = new System.Drawing.Point(163, 152);
            this.lowPrice_val.Name = "lowPrice_val";
            this.lowPrice_val.Size = new System.Drawing.Size(0, 12);
            this.lowPrice_val.TabIndex = 6;
            // 
            // upTimeKST_val
            // 
            this.upTimeKST_val.AutoSize = true;
            this.upTimeKST_val.Font = new System.Drawing.Font("굴림", 20F);
            this.upTimeKST_val.Location = new System.Drawing.Point(367, 128);
            this.upTimeKST_val.Name = "upTimeKST_val";
            this.upTimeKST_val.Size = new System.Drawing.Size(0, 27);
            this.upTimeKST_val.TabIndex = 3;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name_List,
            this.openPrice_List,
            this.highPrice_List,
            this.lowPrice_List,
            this.tradePrice_List,
            this.accTradeVolume_List,
            this.accTradePrice_List,
            this.upTime_List});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(468, 253);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(839, 605);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Name_List
            // 
            this.Name_List.Text = "이름";
            // 
            // openPrice_List
            // 
            this.openPrice_List.Text = "시가";
            this.openPrice_List.Width = 90;
            // 
            // highPrice_List
            // 
            this.highPrice_List.Text = "고가";
            this.highPrice_List.Width = 90;
            // 
            // lowPrice_List
            // 
            this.lowPrice_List.Text = "저가";
            this.lowPrice_List.Width = 90;
            // 
            // tradePrice_List
            // 
            this.tradePrice_List.Text = "종가";
            this.tradePrice_List.Width = 90;
            // 
            // accTradeVolume_List
            // 
            this.accTradeVolume_List.Text = "거래량";
            // 
            // accTradePrice_List
            // 
            this.accTradePrice_List.Text = "거래가";
            this.accTradePrice_List.Width = 120;
            // 
            // upTime_List
            // 
            this.upTime_List.Text = "업데이트 시간";
            this.upTime_List.Width = 235;
            // 
            // getListTimer
            // 
            this.getListTimer.Enabled = true;
            this.getListTimer.Interval = 1000;
            this.getListTimer.Tick += new System.EventHandler(this.timer1_Tick_2);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name_List1,
            this.price_List1,
            this.percent_List1,
            this.tradeVolume_List});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(24, 253);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Scrollable = false;
            this.listView2.Size = new System.Drawing.Size(427, 605);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // name_List1
            // 
            this.name_List1.Text = "이름";
            // 
            // price_List1
            // 
            this.price_List1.Text = "가격";
            this.price_List1.Width = 120;
            // 
            // percent_List1
            // 
            this.percent_List1.Text = "%(24H)";
            this.percent_List1.Width = 70;
            // 
            // tradeVolume_List
            // 
            this.tradeVolume_List.Text = "거래량";
            this.tradeVolume_List.Width = 173;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(23, 14);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(460, 222);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1315, 882);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lowPrice_val);
            this.Controls.Add(this.lowPrice_name);
            this.Controls.Add(this.tradePrice_val);
            this.Controls.Add(this.tradePrice_name);
            this.Controls.Add(this.highPrice_val);
            this.Controls.Add(this.highPrice_name);
            this.Controls.Add(this.accTradePrice_val);
            this.Controls.Add(this.accTradePrice_name);
            this.Controls.Add(this.accTradeVolume_val);
            this.Controls.Add(this.accTradeVolume_name);
            this.Controls.Add(this.openPrice_val);
            this.Controls.Add(this.openPrice_name);
            this.Controls.Add(this.BTC_name);
            this.Controls.Add(this.upTime_name);
            this.Controls.Add(this.upTimeKST_val);
            this.Controls.Add(this.upTime_val);
            this.Controls.Add(this.nowTime);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "상민상민상";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nowTime;
        private System.Windows.Forms.Timer nowTimeTimer;
        private System.Windows.Forms.Timer getPriceTimer;
        private System.Windows.Forms.Label upTime_name;
        private System.Windows.Forms.Label upTime_val;
        private System.Windows.Forms.Label BTC_name;
        private System.Windows.Forms.Label openPrice_name;
        private System.Windows.Forms.Label highPrice_name;
        private System.Windows.Forms.Label lowPrice_name;
        private System.Windows.Forms.Label tradePrice_name;
        private System.Windows.Forms.Label accTradeVolume_name;
        private System.Windows.Forms.Label accTradePrice_name;
        private System.Windows.Forms.Label openPrice_val;
        private System.Windows.Forms.Label accTradeVolume_val;
        private System.Windows.Forms.Label accTradePrice_val;
        private System.Windows.Forms.Label highPrice_val;
        private System.Windows.Forms.Label tradePrice_val;
        private System.Windows.Forms.Label lowPrice_val;
        private System.Windows.Forms.Label upTimeKST_val;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name_List;
        private System.Windows.Forms.ColumnHeader openPrice_List;
        private System.Windows.Forms.ColumnHeader highPrice_List;
        private System.Windows.Forms.ColumnHeader lowPrice_List;
        private System.Windows.Forms.ColumnHeader tradePrice_List;
        private System.Windows.Forms.ColumnHeader accTradeVolume_List;
        private System.Windows.Forms.ColumnHeader accTradePrice_List;
        private System.Windows.Forms.ColumnHeader upTime_List;
        private System.Windows.Forms.Timer getListTimer;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader name_List1;
        private System.Windows.Forms.ColumnHeader price_List1;
        private System.Windows.Forms.ColumnHeader percent_List1;
        private System.Windows.Forms.ColumnHeader tradeVolume_List;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

*/



namespace test
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.nowTime = new System.Windows.Forms.Label();
            this.nowTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.getPriceTimer = new System.Windows.Forms.Timer(this.components);
            this.upTime_name = new System.Windows.Forms.Label();
            this.upTime_val = new System.Windows.Forms.Label();
            this.BTC_name = new System.Windows.Forms.Label();
            this.openPrice_name = new System.Windows.Forms.Label();
            this.highPrice_name = new System.Windows.Forms.Label();
            this.lowPrice_name = new System.Windows.Forms.Label();
            this.tradePrice_name = new System.Windows.Forms.Label();
            this.accTradeVolume_name = new System.Windows.Forms.Label();
            this.accTradePrice_name = new System.Windows.Forms.Label();
            this.openPrice_val = new System.Windows.Forms.Label();
            this.accTradeVolume_val = new System.Windows.Forms.Label();
            this.accTradePrice_val = new System.Windows.Forms.Label();
            this.highPrice_val = new System.Windows.Forms.Label();
            this.tradePrice_val = new System.Windows.Forms.Label();
            this.lowPrice_val = new System.Windows.Forms.Label();
            this.upTimeKST_val = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Name_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.highPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lowPrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tradePrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accTradeVolume_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.accTradePrice_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.upTime_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.getListTimer = new System.Windows.Forms.Timer(this.components);
            this.listView2 = new System.Windows.Forms.ListView();
            this.name_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.percent_List1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tradeVolume_List = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // nowTime
            // 
            this.nowTime.AutoSize = true;
            this.nowTime.Font = new System.Drawing.Font("굴림", 30F);
            this.nowTime.Location = new System.Drawing.Point(17, 14);
            this.nowTime.Name = "nowTime";
            this.nowTime.Size = new System.Drawing.Size(0, 40);
            this.nowTime.TabIndex = 1;
            this.nowTime.Visible = false;
            // 
            // nowTimeTimer
            // 
            this.nowTimeTimer.Enabled = true;
            this.nowTimeTimer.Interval = 1000;
            this.nowTimeTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // getPriceTimer
            // 
            this.getPriceTimer.Enabled = true;
            this.getPriceTimer.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // upTime_name
            // 
            this.upTime_name.AutoSize = true;
            this.upTime_name.Location = new System.Drawing.Point(370, 79);
            this.upTime_name.Name = "upTime_name";
            this.upTime_name.Size = new System.Drawing.Size(81, 12);
            this.upTime_name.TabIndex = 4;
            this.upTime_name.Text = "업데이트 시간";
            this.upTime_name.Visible = false;
            // 
            // upTime_val
            // 
            this.upTime_val.AutoSize = true;
            this.upTime_val.Font = new System.Drawing.Font("굴림", 20F);
            this.upTime_val.Location = new System.Drawing.Point(367, 91);
            this.upTime_val.Name = "upTime_val";
            this.upTime_val.Size = new System.Drawing.Size(0, 27);
            this.upTime_val.TabIndex = 3;
            this.upTime_val.Visible = false;
            // 
            // BTC_name
            // 
            this.BTC_name.AutoSize = true;
            this.BTC_name.Location = new System.Drawing.Point(22, 79);
            this.BTC_name.Name = "BTC_name";
            this.BTC_name.Size = new System.Drawing.Size(30, 12);
            this.BTC_name.TabIndex = 5;
            this.BTC_name.Text = "BTC";
            this.BTC_name.Visible = false;
            // 
            // openPrice_name
            // 
            this.openPrice_name.AutoSize = true;
            this.openPrice_name.Location = new System.Drawing.Point(22, 104);
            this.openPrice_name.Name = "openPrice_name";
            this.openPrice_name.Size = new System.Drawing.Size(29, 12);
            this.openPrice_name.TabIndex = 6;
            this.openPrice_name.Text = "시가";
            this.openPrice_name.Visible = false;
            // 
            // highPrice_name
            // 
            this.highPrice_name.AutoSize = true;
            this.highPrice_name.Location = new System.Drawing.Point(22, 128);
            this.highPrice_name.Name = "highPrice_name";
            this.highPrice_name.Size = new System.Drawing.Size(29, 12);
            this.highPrice_name.TabIndex = 6;
            this.highPrice_name.Text = "고가";
            this.highPrice_name.Visible = false;
            // 
            // lowPrice_name
            // 
            this.lowPrice_name.AutoSize = true;
            this.lowPrice_name.Location = new System.Drawing.Point(22, 152);
            this.lowPrice_name.Name = "lowPrice_name";
            this.lowPrice_name.Size = new System.Drawing.Size(29, 12);
            this.lowPrice_name.TabIndex = 6;
            this.lowPrice_name.Text = "저가";
            this.lowPrice_name.Visible = false;
            // 
            // tradePrice_name
            // 
            this.tradePrice_name.AutoSize = true;
            this.tradePrice_name.Location = new System.Drawing.Point(22, 176);
            this.tradePrice_name.Name = "tradePrice_name";
            this.tradePrice_name.Size = new System.Drawing.Size(29, 12);
            this.tradePrice_name.TabIndex = 6;
            this.tradePrice_name.Text = "종가";
            this.tradePrice_name.Visible = false;
            // 
            // accTradeVolume_name
            // 
            this.accTradeVolume_name.AutoSize = true;
            this.accTradeVolume_name.Location = new System.Drawing.Point(22, 200);
            this.accTradeVolume_name.Name = "accTradeVolume_name";
            this.accTradeVolume_name.Size = new System.Drawing.Size(41, 12);
            this.accTradeVolume_name.TabIndex = 6;
            this.accTradeVolume_name.Text = "거래량";
            this.accTradeVolume_name.Visible = false;
            // 
            // accTradePrice_name
            // 
            this.accTradePrice_name.AutoSize = true;
            this.accTradePrice_name.Location = new System.Drawing.Point(22, 224);
            this.accTradePrice_name.Name = "accTradePrice_name";
            this.accTradePrice_name.Size = new System.Drawing.Size(41, 12);
            this.accTradePrice_name.TabIndex = 6;
            this.accTradePrice_name.Text = "거래가";
            this.accTradePrice_name.Visible = false;
            // 
            // openPrice_val
            // 
            this.openPrice_val.AutoSize = true;
            this.openPrice_val.Location = new System.Drawing.Point(163, 104);
            this.openPrice_val.Name = "openPrice_val";
            this.openPrice_val.Size = new System.Drawing.Size(0, 12);
            this.openPrice_val.TabIndex = 6;
            this.openPrice_val.Visible = false;
            // 
            // accTradeVolume_val
            // 
            this.accTradeVolume_val.AutoSize = true;
            this.accTradeVolume_val.Location = new System.Drawing.Point(163, 200);
            this.accTradeVolume_val.Name = "accTradeVolume_val";
            this.accTradeVolume_val.Size = new System.Drawing.Size(0, 12);
            this.accTradeVolume_val.TabIndex = 6;
            this.accTradeVolume_val.Visible = false;
            // 
            // accTradePrice_val
            // 
            this.accTradePrice_val.AutoSize = true;
            this.accTradePrice_val.Location = new System.Drawing.Point(163, 224);
            this.accTradePrice_val.Name = "accTradePrice_val";
            this.accTradePrice_val.Size = new System.Drawing.Size(0, 12);
            this.accTradePrice_val.TabIndex = 6;
            this.accTradePrice_val.Visible = false;
            // 
            // highPrice_val
            // 
            this.highPrice_val.AutoSize = true;
            this.highPrice_val.Location = new System.Drawing.Point(163, 128);
            this.highPrice_val.Name = "highPrice_val";
            this.highPrice_val.Size = new System.Drawing.Size(0, 12);
            this.highPrice_val.TabIndex = 6;
            this.highPrice_val.Visible = false;
            // 
            // tradePrice_val
            // 
            this.tradePrice_val.AutoSize = true;
            this.tradePrice_val.Location = new System.Drawing.Point(163, 176);
            this.tradePrice_val.Name = "tradePrice_val";
            this.tradePrice_val.Size = new System.Drawing.Size(0, 12);
            this.tradePrice_val.TabIndex = 6;
            this.tradePrice_val.Visible = false;
            // 
            // lowPrice_val
            // 
            this.lowPrice_val.AutoSize = true;
            this.lowPrice_val.Location = new System.Drawing.Point(163, 152);
            this.lowPrice_val.Name = "lowPrice_val";
            this.lowPrice_val.Size = new System.Drawing.Size(0, 12);
            this.lowPrice_val.TabIndex = 6;
            this.lowPrice_val.Visible = false;
            // 
            // upTimeKST_val
            // 
            this.upTimeKST_val.AutoSize = true;
            this.upTimeKST_val.Font = new System.Drawing.Font("굴림", 20F);
            this.upTimeKST_val.Location = new System.Drawing.Point(367, 128);
            this.upTimeKST_val.Name = "upTimeKST_val";
            this.upTimeKST_val.Size = new System.Drawing.Size(0, 27);
            this.upTimeKST_val.TabIndex = 3;
            this.upTimeKST_val.Visible = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name_List,
            this.openPrice_List,
            this.highPrice_List,
            this.lowPrice_List,
            this.tradePrice_List,
            this.accTradeVolume_List,
            this.accTradePrice_List,
            this.upTime_List});
            this.listView1.Font = new System.Drawing.Font("굴림", 10F);
            this.listView1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(373, 8);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(841, 200);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Name_List
            // 
            this.Name_List.Text = "이름";
            // 
            // openPrice_List
            // 
            this.openPrice_List.Text = "시가";
            this.openPrice_List.Width = 90;
            // 
            // highPrice_List
            // 
            this.highPrice_List.Text = "고가";
            this.highPrice_List.Width = 90;
            // 
            // lowPrice_List
            // 
            this.lowPrice_List.Text = "저가";
            this.lowPrice_List.Width = 90;
            // 
            // tradePrice_List
            // 
            this.tradePrice_List.Text = "종가";
            this.tradePrice_List.Width = 90;
            // 
            // accTradeVolume_List
            // 
            this.accTradeVolume_List.Text = "거래량";
            // 
            // accTradePrice_List
            // 
            this.accTradePrice_List.Text = "거래가";
            this.accTradePrice_List.Width = 120;
            // 
            // upTime_List
            // 
            this.upTime_List.Text = "업데이트 시간";
            this.upTime_List.Width = 235;
            // 
            // getListTimer
            // 
            this.getListTimer.Enabled = true;
            this.getListTimer.Interval = 1000;
            this.getListTimer.Tick += new System.EventHandler(this.timer1_Tick_2);
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.WindowText;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name_List1,
            this.price_List1,
            this.percent_List1,
            this.tradeVolume_List});
            this.listView2.Font = new System.Drawing.Font("굴림", 10F);
            this.listView2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(8, 8);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Scrollable = false;
            this.listView2.Size = new System.Drawing.Size(359, 624);
            this.listView2.TabIndex = 7;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // name_List1
            // 
            this.name_List1.Text = "이름";
            this.name_List1.Width = 65;
            // 
            // price_List1
            // 
            this.price_List1.Text = "가격";
            this.price_List1.Width = 120;
            // 
            // percent_List1
            // 
            this.percent_List1.Text = "%(24H)";
            this.percent_List1.Width = 70;
            // 
            // tradeVolume_List
            // 
            this.tradeVolume_List.Text = "거래량";
            this.tradeVolume_List.Width = 173;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(373, 214);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 6;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(841, 262);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1226, 611);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lowPrice_val);
            this.Controls.Add(this.lowPrice_name);
            this.Controls.Add(this.tradePrice_val);
            this.Controls.Add(this.tradePrice_name);
            this.Controls.Add(this.highPrice_val);
            this.Controls.Add(this.highPrice_name);
            this.Controls.Add(this.accTradePrice_val);
            this.Controls.Add(this.accTradePrice_name);
            this.Controls.Add(this.accTradeVolume_val);
            this.Controls.Add(this.accTradeVolume_name);
            this.Controls.Add(this.openPrice_val);
            this.Controls.Add(this.openPrice_name);
            this.Controls.Add(this.BTC_name);
            this.Controls.Add(this.upTime_name);
            this.Controls.Add(this.upTimeKST_val);
            this.Controls.Add(this.upTime_val);
            this.Controls.Add(this.nowTime);
            this.ForeColor = System.Drawing.Color.Snow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "상민상민상";
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label nowTime;
        private System.Windows.Forms.Timer nowTimeTimer;
        private System.Windows.Forms.Timer getPriceTimer;
        private System.Windows.Forms.Label upTime_name;
        private System.Windows.Forms.Label upTime_val;
        private System.Windows.Forms.Label BTC_name;
        private System.Windows.Forms.Label openPrice_name;
        private System.Windows.Forms.Label highPrice_name;
        private System.Windows.Forms.Label lowPrice_name;
        private System.Windows.Forms.Label tradePrice_name;
        private System.Windows.Forms.Label accTradeVolume_name;
        private System.Windows.Forms.Label accTradePrice_name;
        private System.Windows.Forms.Label openPrice_val;
        private System.Windows.Forms.Label accTradeVolume_val;
        private System.Windows.Forms.Label accTradePrice_val;
        private System.Windows.Forms.Label highPrice_val;
        private System.Windows.Forms.Label tradePrice_val;
        private System.Windows.Forms.Label lowPrice_val;
        private System.Windows.Forms.Label upTimeKST_val;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Name_List;
        private System.Windows.Forms.ColumnHeader openPrice_List;
        private System.Windows.Forms.ColumnHeader highPrice_List;
        private System.Windows.Forms.ColumnHeader lowPrice_List;
        private System.Windows.Forms.ColumnHeader tradePrice_List;
        private System.Windows.Forms.ColumnHeader accTradeVolume_List;
        private System.Windows.Forms.ColumnHeader accTradePrice_List;
        private System.Windows.Forms.ColumnHeader upTime_List;
        private System.Windows.Forms.Timer getListTimer;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader name_List1;
        private System.Windows.Forms.ColumnHeader price_List1;
        private System.Windows.Forms.ColumnHeader percent_List1;
        private System.Windows.Forms.ColumnHeader tradeVolume_List;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
