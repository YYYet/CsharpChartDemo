using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Timer = System.Timers.Timer;

namespace WindowsFormsApp1
{
    
    public partial class Form1 : Form
    {
        /**
         * 纵坐标list
         */
        static List<double> yList = new List<double>();
        
        /**
         * 横坐标list
         */
        static List<String> xList = new List<String>();
        static Random rnd = new Random();
        static Timer timer = new Timer();
        
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化图表
            initChart();
            initComboBoxData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //启动定时器
            timer = new Timer(1000);  
            timer.Elapsed += timer_Task;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Start();
        }
        
        /**
         * 定时器任务
         */
        private void timer_Task(object sender, EventArgs e)
        {
            //移除第一个横坐标
            xList.RemoveAt(0);
            //获取最新时间并添加列表尾
            xList.Add(System.DateTime.Now.ToString("T"));
            //移除第一个纵坐标
            yList.RemoveAt(0);
            //构造新的纵坐标值
            yList.Add(getDataByBaseline(10));
            //数据与坐标轴绑定
            chart1.Series[0].Points.DataBindXY(xList, yList);
        }
        
        /**
         * 平滑数据构造
         */
        private double getDataByBaseline(int baseLine)
        {
            return rnd.NextDouble()*2.0 + baseLine - rnd.NextDouble()*4.0;
        }

        /**
         * chart初始化
         */
        private void initChart()
        {
            // 构造初始值
            for (int i = 0; i < 5; i++)
            {
                yList.Add(getDataByBaseline(10));
                xList.Add(DateTime.Now.ToString("T"));
            }
            //修改横纵坐标类型
            chart1.Series[0].XValueType = ChartValueType.Time;
            chart1.Series[0].YValueType = ChartValueType.Double;   
        }

        private void initComboBoxData()
        {
            Object[] itmes = new object[12];
            itmes[0] = "柱状图";
            itmes[1] = "折线图";
            itmes[2] = "饼图";
            itmes[3] = "面积图";
            itmes[4] = "气泡图";
            itmes[5] = "K 线图";
            itmes[6] = "条形图";
            itmes[7] = "圆环图";
            itmes[8] = "漏斗图";
            itmes[9] = "卡吉图";
            itmes[10] = "点图";
            itmes[11] = "快速扫描线图";
            comboBox1.Items.AddRange(itmes);
            comboBox1.SelectedIndex = 10;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    break;
                case 1:
                    chart1.Series[0].ChartType = SeriesChartType.Line;
                    break;
                case 2:
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                    break;
                case 3:
                    chart1.Series[0].ChartType = SeriesChartType.Area;
                    break;
                case 4:
                    chart1.Series[0].ChartType = SeriesChartType.Bubble;
                    break;
                case 5:
                    chart1.Series[0].ChartType = SeriesChartType.Candlestick;
                    break;
                case 6:
                    chart1.Series[0].ChartType = SeriesChartType.Bar;
                    break;
                case 7:
                    chart1.Series[0].ChartType = SeriesChartType.Doughnut;
                    break;
                case 8:
                    chart1.Series[0].ChartType = SeriesChartType.Funnel;
                    break;
                case 9:
                    chart1.Series[0].ChartType = SeriesChartType.Kagi;
                    break;              
                case 10:
                    chart1.Series[0].ChartType = SeriesChartType.Point;
                    break;
                case 11:
                    chart1.Series[0].ChartType = SeriesChartType.FastLine;
                    break;
            }
        }
    }
}