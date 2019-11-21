using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 打字游戏
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //实例化一个游戏区 
        Panel bg = new Panel();
        //实例化一个控制区
        Panel kz = new Panel();
        //实例化随机对象
        Random r = new Random();
        //实例化己方飞机对象
        PictureBox plan = new PictureBox();
        //实例化得分板
        Label lb1 = new Label();
        //实例化开始按钮
        Label lb2 = new Label();
        //记录分数
        int count = 0;
        //创建敌机
        Timer GreateEnmmy = new Timer();
        //字母下落
        Timer FlyTime = new Timer();
        //lab进度条背景
        Label jdback = new Label();
        //lab进度条
        Label jdtiao = new Label();
        //进度条血量
        int xt = 100;
        //实例化放飞机火苗1
        PictureBox fire2 = new PictureBox();
        //实例化放飞机火苗2
        PictureBox fire = new PictureBox();
        ////装敌机
        List<PictureBox> djBox = new List<PictureBox>();
        ////装子弹
        List<PictureBox> zdBox = new List<PictureBox>();
        //创建子弹生成器
        Timer Greatbutt = new Timer();
        //子弹上升
        Timer buttTop = new Timer();
        //给飞机火苗添加控制时间
        Timer firet = new Timer();
        //实例化声音
        SoundPlayer sy = new SoundPlayer();
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化窗口
            this.Size = new Size(1000, 600);
            //this.BackColor = Color.Red;
            this.BackgroundImage = Image.FromFile(@"../../img/bg.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Left = Screen.PrimaryScreen.Bounds.Width / 2 - this.Width / 2;
            this.Top = Screen.PrimaryScreen.Bounds.Height / 2 - this.Height / 2;

            //创建游戏区
            bg.Width = 800;
            bg.Height = 530;
            bg.BackColor = Color.Pink;
            this.Controls.Add(bg);
            bg.Location = new Point(10, 20);

            //创建控制区
            kz.Width = 200;
            kz.Height = 530;
            kz.BackColor = Color.Cyan;
            kz.Location = new Point(this.Width-kz.Width,20);
            this.Controls.Add(kz);

            //创建飞机属性
            plan.Size = new Size(80,80);
            plan.Tag = "plan";
            plan.Top = bg.Height - plan.Height-30;
            plan.Left = bg.Width / 2 - plan.Width / 2;
            plan.Image = Image.FromFile(@"../../img/plane1.png");
            plan.SizeMode = PictureBoxSizeMode.StretchImage;
            plan.Tag = "plan";
            bg.Controls.Add(plan);

            //创建飞机火苗1属性
            fire.Size = new Size(20, 20);
            fire.Image = imageList2.Images[0];
            fire.Left = plan.Left+ plan.Width/4;
            fire.Top = plan.Top+ plan.Height;
            fire.Tag = 0;
            bg.Controls.Add(fire);

            //创建飞机火苗2属性
            fire2.Size = new Size(20, 20);
            fire2.Tag = 0;
            fire2.Image = imageList2.Images[0];
            fire2.Left = plan.Left + plan.Width / 2;
            fire2.Top = plan.Top + plan.Height;
            bg.Controls.Add(fire2);

           
            firet.Interval = 10;
            firet.Tag = fire;
            firet.Tick += Firet_Tick;
            firet.Start();

            //创建敌机生成器GreateEnmmy
            GreateEnmmy.Interval = 1000;
            GreateEnmmy.Tick += GreateEnmmy_Tick;
          
            //创建敌机下落Flytime
            FlyTime.Interval = 30;
            FlyTime.Tick += FlyTime_Tick;
          
            //得分板属性
            lb1.Font = new Font("", 20);
            lb1.Location = new Point(10,0);
            lb1.Text = 0 + "分";
            lb1.AutoSize = true;
            lb1.BackColor = Color.Transparent;
            kz.Controls.Add(lb1);

            //开始游戏属性
            lb2.Font = new Font("", 20);
            lb2.Location = new Point(10, 30);
            lb2.Text = "开始游戏";
            lb2.AutoSize = true;
            lb2.BackColor = Color.Transparent;
            kz.Controls.Add(lb2);
            lb2.Click += Lb2_Click;

            //初始化血量文字说明
            Label la = new Label();
            la.Font = new Font("",20);
            la.AutoSize = true;
            la.BackColor = Color.Red;
            la.Text = "您的血量↓";
            la.Location = new Point(20,80);
            kz.Controls.Add(la);

            //自定义血条
            jdback.Size = new Size(xt,20);
            jdback.Location = new Point(20, 120);
            jdback.BackColor = Color.Black;
            jdtiao.Size = new Size(100,20);
            jdtiao.Location = new Point(20,120);
            jdtiao.BackColor = Color.Red;
            kz.Controls.Add(jdtiao);
            kz.Controls.Add(jdback);

            //子弹创建生成器
            Greatbutt.Interval = 300;
            Greatbutt.Tick += Greatbutt_Tick;

            //音频路径
            sy.SoundLocation = @"../../video/boom.wav";

            //鼠标移动事件
            bg.MouseMove += Bg_MouseMove;
        }


        //鼠标移动事件飞机动
        private void Bg_MouseMove(object sender, MouseEventArgs e)
        {
            //Cursor.Hide();
            plan.Left = MousePosition.X - this.Left - bg.Left - plan.Width / 2;
            plan.Top = MousePosition.Y - this.Top - bg.Top - plan.Height / 2;
            fire.Left = plan.Left + plan.Width / 4;
            fire.Top = plan.Top + plan.Height;
            fire2.Left = plan.Left + plan.Width / 2;
            fire2.Top = plan.Top + plan.Height; 
        }

        //图标关闭
        private void 关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //开始/暂停游戏
        private void Lb2_Click(object sender, EventArgs e)
        {
            Label lb2 = (Label)sender;
            if (lb2.Text=="开始游戏")
            {
                lb2.Text = "暂停";
                GreateEnmmy.Start();
                FlyTime.Start();
                Greatbutt.Start();
            }
            else if(lb2.Text == "暂停")
            {
                lb2.Text = "开始游戏";
                GreateEnmmy.Stop();
                FlyTime.Stop();
                Greatbutt.Stop();
            }
        }

        //控制飞机火苗
        private void Firet_Tick(object sender, EventArgs e)
        {
            fire.Image = imageList2.Images[(int)fire.Tag];
            fire2.Image = imageList2.Images[(int)fire2.Tag];
            fire2.Tag = (int)fire2.Tag + 1;
            fire.Tag = (int)fire.Tag + 1;
            if ((int)fire.Tag>1|| (int)(int)fire2.Tag > 1)
            {
                fire.Tag = 0;
                fire2.Tag = 0;
            }
        }

        //控制创建敌机属性
        private void GreateEnmmy_Tick(object sender, EventArgs e)
        {
            PictureBox enmmy = new PictureBox();
            enmmy.Size = new Size(50,50);
            enmmy.Tag = "enmmy";
            int djs = r.Next(0,2);
            if (djs==0)
            {
                enmmy.Image = Image.FromFile(@"../../img/Enemy3_" + r.Next(1, 4) + ".png");
            }
            else
            {
                enmmy.Image = Image.FromFile(@"../../img/Enemy"+r.Next(1,4)+".png");
            }
            
            enmmy.SizeMode = PictureBoxSizeMode.StretchImage;
            enmmy.Location = new Point(r.Next(bg.Width-enmmy.Width),0);
            bg.Controls.Add(enmmy);
            djBox.Add(enmmy);
        }

        //创建子弹计时器
        private void Greatbutt_Tick(object sender, EventArgs e)
        {
           PictureBox bullte = new PictureBox();
            bullte.Size = new Size(6, 30);
            bullte.Tag = "zd";
            bullte.Image = Image.FromFile(@"../../img/Ammo4.png");
            bullte.SizeMode = PictureBoxSizeMode.StretchImage;
            bullte.Left = plan.Left + plan.Width / 2 - bullte.Width / 2;
            bullte.Top = plan.Top - bullte.Height;
            bg.Controls.Add(bullte);
            zdBox.Add(bullte);
        }

        //控制敌机下落以及子弹上升
        private void FlyTime_Tick(object sender, EventArgs e)
        {
            foreach (Control item in bg.Controls)
            {
                if (item.Tag.ToString()=="enmmy")
                {
                    item.Top += 3;
                    if (item.Top>=bg.Height)
                    {
                        item.Dispose();
                        xt -= 10;
                        jdtiao.Width = xt;
                        if (xt == 0)
                        {
                            tan();
                        }
                    }
                    if (item.Left>=plan.Left&& item.Left <= plan.Left+plan.Width&&item.Top>=plan.Top&&item.Top<=plan.Top+plan.Height)
                    {
                        sy.Play();
                        baozha(plan);
                        tan();
                    }
                }
                if (item.Tag.ToString() == "zd")
                {
                    item.Top -= 2;
                    if (item.Top < item.Height)
                    {
                        item.Dispose();
                    }
                foreach (Control Enmmy in bg.Controls)
                {
                    if (Enmmy.Tag.ToString() == "enmmy")
                    {
                        if (item.Top <= Enmmy.Top + Enmmy.Height && item.Left >= Enmmy.Left &&  item.Left + item.Width <= Enmmy.Left + Enmmy.Width)
                            {
                                item.Dispose();
                                Enmmy.Dispose();
                                sy.Play();
                                count += 5;
                                lb1.Text = count.ToString() + "分";
                                baozha(Enmmy);
                        }
                    }
                  }
                }
            }
        }

        //爆炸方法
        private void baozha(Control control)
        {
            PictureBox boom = new PictureBox();
            boom.Size = new Size(50, 50);
            boom.Tag = 0;
            boom.Location = new Point(control.Left + control.Width / 2 - boom.Width / 2, control.Top + control.Height / 2 - boom.Height / 2);
            bg.Controls.Add(boom);
            boom.Image = imageList1.Images[0];

            Timer boomTime = new Timer();
            boomTime.Interval = 70;
            boomTime.Tag = boom;
            boomTime.Tick += BoomTime_Tick;
            boomTime.Start();
        }
        //爆炸动画计时器
        private void BoomTime_Tick(object sender, EventArgs e)
        {
            //sender事件的发起者是谁
            Timer boomTime=(Timer)sender;
            //通过强制转换将boomTime的Tag值赋给picture
            PictureBox picture = (PictureBox)boomTime.Tag;
            picture.Image = imageList1.Images[(int)picture.Tag];
            picture.Tag = (int)picture.Tag + 1;
            if ((int)picture.Tag>31)
            {
                boomTime.Dispose();
                picture.Dispose();
            }
        }

        //清空敌机
        private void qingdj()
        {
            foreach (PictureBox dj in djBox)
            {
                dj.Dispose();
            }
        }
        //清空子弹
        private void qingd()
        {
            foreach (PictureBox zidan in zdBox)
            {
                zidan.Dispose();
            }
        }
        //弹窗
        private void tan()
        {
            GreateEnmmy.Stop();
            FlyTime.Stop();
            Greatbutt.Stop();
            if (MessageBox.Show("游戏结束.得分为" + count, "Game Over", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Retry)
            {
                lb1.Text = 0 + "分";
                lb2.Text = "开始游戏";
                count = 0;
                xt = 100;
                jdtiao.Width = xt;
                plan.Top = bg.Height - plan.Height - 30;
                plan.Left = bg.Width / 2 - plan.Width / 2;
                fire.Left = plan.Left + plan.Width / 4;
                fire.Top = plan.Top + plan.Height;
                fire2.Left = plan.Left + plan.Width / 2;
                fire2.Top = plan.Top + plan.Height;
                qingdj();
                qingd();
            }
            else
            {
                this.Close();
            }
        }
    }
}
