﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotControl
{
    public partial class Form1 : Form
    {
        private const string V = "T100\r";
        private int value_temp; //避免重复调用
        private DateTime current_time = new DateTime();     //避免重复调用
        private int Num = 0;   //避免重复调用
        private int cnt = 0;       //发送计数变量
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int i;
            //单个添加
            for (i = 300; i <= 38400; i = i * 2)
            {
                comboBox2.Items.Add(i.ToString());  //添加波特率列表
            }

            //批量添加波特率列表
            string[] baud = { "43000", "56000", "57600", "115200", "128000", "230400", "256000", "460800" };
            comboBox2.Items.AddRange(baud);

            //获取电脑当前可用串口并添加到选项列表中
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());

            //设置选项默认值
            comboBox2.Text = "115200";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           try
            {
                //将可能产生异常的代码放置在try块中
                //根据当前串口属性来判断是否打开
                if (serialPort1.IsOpen)
                {
                    //串口已经处于打开状态
                    serialPort1.Close();    //关闭串口
                    button1.Text = "打开串口";
                    button1.BackColor = Color.ForestGreen;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    button3.Enabled = false;

                    trackBar1.Enabled = false;
                    trackBar2.Enabled = false;
                    trackBar3.Enabled = false;
                    trackBar4.Enabled = false;
                    trackBar5.Enabled = false;
                    trackBar6.Enabled = false;
                    trackBar7.Enabled = false;
                    trackBar8.Enabled = false;
                    trackBar9.Enabled = false;
                    trackBar10.Enabled = false;
                    trackBar11.Enabled = false;
                    trackBar12.Enabled = false;
                }
                else
                {
                    //串口已经处于关闭状态，则设置好串口属性后打开
                    serialPort1.PortName = comboBox1.Text;
                    serialPort1.BaudRate = Convert.ToInt32(comboBox2.Text);
                    serialPort1.Open();     //打开串口
                    button1.Text = "关闭串口";
                    button1.BackColor = Color.Firebrick;
                    current_time = System.DateTime.Now;     //获取当前时间
                    serialPort1.WriteLine("#Veri+"+current_time.ToString("yyyyMMddHHmm")+" \r");

                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    button3.Enabled = true;

                    trackBar1.Enabled =  true;
                    trackBar2.Enabled =  true;
                    trackBar3.Enabled =  true;
                    trackBar4.Enabled =  true;
                    trackBar5.Enabled =  true;
                    trackBar6.Enabled =  true;
                    trackBar7.Enabled =  true;
                    trackBar8.Enabled =  true;
                    trackBar9.Enabled =  true;
                    trackBar10.Enabled = true;
                    trackBar11.Enabled = true;
                    trackBar12.Enabled = true;

                }
            }
            catch (Exception ex)
            {
                //捕获可能发生的异常并进行处理
                //捕获到异常，创建一个新的对象，之前的不可以再用
                serialPort1 = new System.IO.Ports.SerialPort();
                //刷新COM口选项
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                //响铃并显示异常给用户
                System.Media.SystemSounds.Beep.Play();
                button1.Text = "打开串口";
                button1.BackColor = Color.ForestGreen;
                MessageBox.Show(ex.Message);

                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
                button3.Enabled = false;

                trackBar1.Enabled = false;
                trackBar2.Enabled = false;
                trackBar3.Enabled = false;
                trackBar4.Enabled = false;
                trackBar5.Enabled = false;
                trackBar6.Enabled = false;
                trackBar7.Enabled = false;
                trackBar8.Enabled = false;
                trackBar9.Enabled = false;
                trackBar10.Enabled = false;
                trackBar11.Enabled = false;
                trackBar12.Enabled = false;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //servo1
            textBox1.Text = trackBar1.Value.ToString();
            value_temp = 1500 + trackBar1.Value;
            serialPort1.WriteLine("#1P"+value_temp.ToString()+ V);
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            //servo3
            textBox2.Text = trackBar2.Value.ToString();
            value_temp = 1500 + trackBar2.Value;
            serialPort1.WriteLine("#3P" + value_temp.ToString()+ V);
        }
        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            //servo5
            textBox3.Text = trackBar3.Value.ToString();
            value_temp = 1500 + trackBar3.Value;
            serialPort1.WriteLine("#5P" + value_temp.ToString()+ V);
        }
        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            //servo7
            textBox4.Text = trackBar4.Value.ToString();
            value_temp = 1500 + trackBar4.Value;
            serialPort1.WriteLine("#7P" + value_temp.ToString()+ V);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            //servo9
            textBox5.Text = trackBar5.Value.ToString();
            value_temp = 1500 + trackBar5.Value;
            serialPort1.WriteLine("#9P" + value_temp.ToString()+ V);
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            //servo2
            textBox6.Text = trackBar6.Value.ToString();
            value_temp = 1500 + trackBar6.Value;
            serialPort1.WriteLine("#2P" + value_temp.ToString()+ V);
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            //servo4
            textBox7.Text = trackBar7.Value.ToString();
            value_temp = 1500 + trackBar7.Value;
            serialPort1.WriteLine("#4P" + value_temp.ToString()+ V);
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            //servo6
            textBox8.Text = trackBar8.Value.ToString();
            value_temp = 1500 + trackBar8.Value;
            serialPort1.WriteLine("#6P" + value_temp.ToString()+ V);
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            //servo8
            textBox9.Text = trackBar9.Value.ToString();
            value_temp = 1500 + trackBar9.Value;
            serialPort1.WriteLine("#8P" + value_temp.ToString()+ V);
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            //servo10
            textBox10.Text = trackBar10.Value.ToString();
            value_temp = 1500 + trackBar10.Value;
            serialPort1.WriteLine("#10P" + value_temp.ToString()+ V);
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            //servo12
            textBox11.Text = trackBar11.Value.ToString();
            value_temp = 1500 + trackBar11.Value;
            serialPort1.WriteLine("#12P" + value_temp.ToString()+ V);
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            //servo11
            textBox12.Text = trackBar12.Value.ToString();
            value_temp = 1500 + trackBar12.Value;
            serialPort1.WriteLine("#11P" + value_temp.ToString()+ V);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Num++;  //列表项计数变量自加1
            ListViewItem liv_temp = new ListViewItem(Num.ToString("D2"));     //列表项变量，用于存放值
            String value_temp = "#1P" + (1500 + trackBar1.Value).ToString() 
                              + "#2P" + (1500 + trackBar6.Value).ToString()
                              + "#3P" + (1500 + trackBar2.Value).ToString()
                              + "#4P" + (1500 + trackBar7.Value).ToString()
                              + "#5P" + (1500 + trackBar3.Value).ToString()
                              + "#6P" + (1500 + trackBar8.Value).ToString()
                              + "#7P" + (1500 + trackBar4.Value).ToString()
                              + "#8P" + (1500 + trackBar9.Value).ToString()
                              + "#9P" + (1500 + trackBar5.Value).ToString()
                              + "#10P" + (1500 + trackBar10.Value).ToString()
                              + "#11P" + (1500 + trackBar12.Value).ToString()
                              + "#12P" + (1500 + trackBar11.Value).ToString()
                              + "T1000";
            liv_temp.SubItems.Add(value_temp);
            listView1.Items.Add(liv_temp);
            liv_temp.Selected = true;   //必须要
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Interval = (int)numericUpDown1.Value;    //获取定时值
            timer1.Start();                                 //启动定时器
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cnt >= listView1.Items.Count)
            {
                cnt = 0;
                //发送完成
                if (radioButton2.Checked)
                {
                    //循环运行模式,无动作
                }
                else
                {
                    //单次运行模式
                    timer1.Stop();      //关闭定时器
                    System.Media.SystemSounds.Beep.Play(); //响铃提示用户
                    MessageBox.Show("运行完成");
                }
                
            }
            else
            {
                try
                {
                    serialPort1.WriteLine(listView1.SelectedItems[cnt].SubItems[1].Text + '\r');     //串口发送
                    cnt++;
                    timer1.Interval = (int)numericUpDown1.Value;    //获取定时值
                    timer1.Start();                                 //启动定时器
                }
                catch (Exception ex)
                {
                    serialPort1.Close();
                    //捕获到异常，创建一个新的对象，之前的不可以再用
                    serialPort1 = new System.IO.Ports.SerialPort();
                    //刷新COM口选项
                    comboBox1.Items.Clear();
                    comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
                    //响铃并显示异常给用户
                    System.Media.SystemSounds.Beep.Play();
                    button1.Text = "打开串口";
                    button1.BackColor = Color.ForestGreen;
                    MessageBox.Show(ex.Message);
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    button3.Enabled = false;
                }
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cnt = 0;
            timer1.Stop();                          //关闭定时器
            System.Media.SystemSounds.Beep.Play(); //响铃提示用户
            MessageBox.Show("停止运行");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Num--;  //列表项计数变量自减1
            listView1.Items.Remove(listView1.Items[listView1.Items.Count-1]);
        }
    }
}
