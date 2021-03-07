using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlantMaker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maker = textBox1.Text + ";"  + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text + ";"  + textBox5.Text ;
            FileStream fs = new FileStream(Application.StartupPath + "\\MyPlant.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite); //这是干什么用的代码鸭~
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(maker);
            sw.Flush();
            sw.Close();
            MessageBox.Show("已经成功写入到" + Application.StartupPath + "\\MyPlant.txt" + "！记得使用的时候要改名字呀！","建造成功!",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
