using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Farm
{
    public partial class Form1 : Form
    {
        #region 声明字段
        int deltaday = 0;
        List<string> names = new List<string>();
        List<int> price = new List<int>();
        List<int> fm = new List<int>();
        List<int> hungry = new List<int>();
        List<int> mature = new List<int>();
        List<int> planet = new List<int>();
        #endregion
        public Form1()
        {
            InitializeComponent();
            #region 初始化
            //加15个空位
            for (int i = 0; i < 15; i++)
            {
                planet.Add(-1);
            }
            #endregion
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 读取天数
            StreamReader sr = new StreamReader(Application.StartupPath + "\\temp\\day.txt");
            string day = sr.ReadToEnd();
            sr.Close();
            StreamReader sr2 = new StreamReader(Application.StartupPath + "\\temp\\beforeday.txt");
            string beforeday = sr2.ReadToEnd();
            deltaday = Convert.ToInt32(day) - Convert.ToInt32(beforeday);
            MessageBox.Show(deltaday.ToString());
            sr2.Close();
            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\temp\\beforeday.txt");
            sw.Write(day);
            sw.Flush();
            sw.Close();
            #endregion
            #region 读取植物
            for (int i = 1; i < 8; i++)
            {
                string local = Application.StartupPath + "\\plant\\" + i.ToString() + ".txt";
                StreamReader srp = new StreamReader(local, System.Text.Encoding.Default);
                string result = srp.ReadToEnd();
                string[] results = result.Split(";");
                //加入泛型集合
                names.Add(results[0].ToString());
                price.Add(Convert.ToInt32(results[1]));
                fm.Add(Convert.ToInt32(results[2]));
                hungry.Add(Convert.ToInt32(results[3]));
                mature.Add(Convert.ToInt32(results[4]));
            }
            #endregion
            #region 显示植物

            label1.Text = names[0];
            label22.Text = names[1];
            label25.Text = names[2];
            label28.Text = names[3];
            label31.Text = names[4];
            label34.Text = names[5];
            label38.Text = names[6];
            label18.Text = price[0].ToString();
            label21.Text = price[1].ToString();
            label24.Text = price[2].ToString();
            label27.Text = price[3].ToString();
            label30.Text = price[4].ToString();
            label33.Text = price[5].ToString();
            label39.Text = price[6].ToString();
            label19.Text = fm[0].ToString() + "/" + hungry[0].ToString();
            label20.Text = fm[1].ToString() + "/" + hungry[1].ToString();
            label23.Text = fm[2].ToString() + "/" + hungry[2].ToString();
            label26.Text = fm[3].ToString() + "/" + hungry[3].ToString();
            label29.Text = fm[4].ToString() + "/" + hungry[4].ToString();
            label32.Text = fm[5].ToString() + "/" + hungry[5].ToString();
            label40.Text = fm[5].ToString() + "/" + hungry[6].ToString();
            #endregion
        }

        private void label1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == string.Empty)
                {
                    MessageBox.Show("请先选择位置!", "种植失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    planet[Convert.ToInt32(textBox1.Text)] = 0;
                }
            }
            catch (ArgumentOutOfRangeException){
                MessageBox.Show("没有这个位置!","种植失败",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
    }
}
