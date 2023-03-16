using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schiaccia_la_talpa03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int diff = 0;
        int punti = 0;

        Random random = new Random();

        const int maxOgg = 4;

        PictureBox[] pictureBoxes1 = new PictureBox[maxOgg];
        PictureBox[] pictureBoxes2 = new PictureBox[maxOgg];

        Label score = new Label();

        PictureBox[] vita=new PictureBox[3];
        int numVite = 2;

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < maxOgg; i++)
            {
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point(0, 0);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(313, 224);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;
                if (i < 3)
                {
                    pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
                }
                else
                {
                    pictureBox1.Click += new System.EventHandler(this.pictureBox12_Click);
                }
                pictureBoxes1[i] = pictureBox1;
            }
            pictureBoxes1[0].Image = global::Schiaccia_la_talpa03.Properties.Resources.buco_talpa;
            pictureBoxes1[1].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa1;
            pictureBoxes1[2].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa2;
            pictureBoxes1[3].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa_bomba;

            for (int i = 0; i < maxOgg; i++)
            {
                PictureBox pictureBox1 = new PictureBox();
                pictureBox1.Location = new System.Drawing.Point(0, 0);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(313, 224);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;
                if (i < 3)
                {
                    pictureBox1.Click += new System.EventHandler(this.pictureBox2_Click);
                }
                else
                {
                    pictureBox1.Click += new System.EventHandler(this.pictureBox22_Click);
                }
                pictureBoxes2[i] = pictureBox1;
            }
            pictureBoxes2[0].Image = global::Schiaccia_la_talpa03.Properties.Resources.buco_talpa;
            pictureBoxes2[1].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa1;
            pictureBoxes2[2].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa2;
            pictureBoxes2[3].Image = global::Schiaccia_la_talpa03.Properties.Resources.talpa_bomba;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            diff = 0;
            Button button1 = new Button();
            button1.Location = new System.Drawing.Point(250, 150);
            button1.Name = "button3";
            button1.Size = new System.Drawing.Size(100, 50);
            button1.TabIndex = 0;
            button1.Text = "INIZIA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button3_Click);
            this.Controls.Add(button1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            diff = 1;
            Button button1 = new Button();
            button1.Location = new System.Drawing.Point(250, 150);
            button1.Name = "button3";
            button1.Size = new System.Drawing.Size(100, 50);
            button1.TabIndex = 0;
            button1.Text = "INIZIA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button3_Click);
            this.Controls.Add(button1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();

            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 4);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 2;
            label1.Text = "Score:";
            this.Controls.Add(label1);

            score.AutoSize = true;
            score.Location = new System.Drawing.Point(20, 20);
            score.Name = "label1";
            score.Size = new System.Drawing.Size(44, 16);
            score.TabIndex = 2;
            score.Text = "0";
            this.Controls.Add(score);

            this.BackgroundImage= global::Schiaccia_la_talpa03.Properties.Resources.sfondo_talpe;

            for(int i = 0; i < 3; i++)
            {
                PictureBox pictureBox1= new PictureBox();
                pictureBox1.Image = global::Schiaccia_la_talpa03.Properties.Resources.cuore;
                pictureBox1.Location = new System.Drawing.Point(150+72*i,20);
                pictureBox1.Name = "pictureBox1";
                pictureBox1.Size = new System.Drawing.Size(62, 58);
                pictureBox1.TabIndex = 2;
                pictureBox1.TabStop = false;
                vita[i] = pictureBox1;
                this.Controls.Add(vita[i]);
            }

            timer1.Enabled = true;
            timer1.Start();

            timer2.Enabled = true;
            timer2.Start();

            if (diff == 0)
            {
                timer1.Interval = 300;
                timer2.Interval = 350;
            }
            else
            {
                timer1.Interval = 200;
                timer2.Interval = 250;
            }

        }
        int tempo1 = 0;
        int tempo2 = 0;
        int pos1 = 0;
        int pos2 = 0;

        int x1 = 0;
        int y1 = 0;

        int x2 = 0;
        int y2 = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tempo1 == 3)
            {
                do
                {
                    x1 = random.Next(1000);
                    y1 = random.Next(600);
                } while (!((x1 - x2 > 313 || x1 - x2 < -313) && (y1 - y2 > 224 || y1 - y2 < -224)));
                pos1 = 0;
                pictureBoxes1[pos1].Location = new System.Drawing.Point(x1, y1);
                this.Controls.Add(pictureBoxes1[pos1]);
                tempo1++;
            }
            else if (tempo1 == 4)
            {
                this.Controls.Remove(pictureBoxes1[pos1]);
                pos1 = 1;
                pictureBoxes1[pos1].Location = new System.Drawing.Point(x1, y1);
                this.Controls.Add(pictureBoxes1[pos1]);
                tempo1++;
            }
            else if (tempo1 == 5)
            {
                this.Controls.Remove(pictureBoxes1[pos1]);
                if (random.Next(5) < 4)
                {
                    pos1 = 2;
                }
                else
                {
                    pos1 = 3;
                }
                pictureBoxes1[pos1].Location = new System.Drawing.Point(x1, y1);
                this.Controls.Add(pictureBoxes1[pos1]);
                tempo1++;
            }
            else if (tempo1 == 10)
            {
                this.Controls.Remove(pictureBoxes1[pos1]);
                tempo1 = 0;
            }
            else
            {
                tempo1++;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tempo2 == 3)
            {
                do
                {
                    x2 = random.Next(1000);
                    y2 = random.Next(600);
                } while (!((x2 - x1 > 313 || x2 - x1 < -313) && (y2 - y1 > 224 || y2 - y1 < -224)));
                pos2 = 0;
                pictureBoxes2[pos2].Location = new System.Drawing.Point(x2, y2);
                this.Controls.Add(pictureBoxes2[pos2]);
                tempo2++;
            }
            else if (tempo2 == 4)
            {
                this.Controls.Remove(pictureBoxes2[pos2]);
                pos2 = 1;
                pictureBoxes2[pos2].Location = new System.Drawing.Point(x2, y2);
                this.Controls.Add(pictureBoxes2[pos2]);
                tempo2++;
            }else if (tempo2 == 5)
            {
                this.Controls.Remove(pictureBoxes2[pos2]);
                if (random.Next(5) < 4)
                {
                    pos2 = 2;
                }
                else
                {
                    pos2 = 3;
                }
                pictureBoxes2[pos2].Location = new System.Drawing.Point(x2, y2);
                this.Controls.Add(pictureBoxes2[pos2]);
                tempo2++;
            }
            else if (tempo2 == 10)
            {
                this.Controls.Remove(pictureBoxes2[pos2]);
                tempo2 = 0;
            }
            else
            {
                tempo2++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            punti++;
            score.Text = punti.ToString();
            this.Controls.Remove(pictureBoxes1[pos1]);
            tempo1 = 0;
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            if (numVite < 1)
            {
                finale();
            }
            else
            {
                this.Controls.Remove(vita[numVite]);
                numVite--;
            }
            this.Controls.Remove(pictureBoxes1[pos1]);
            tempo1 = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            punti++;
            score.Text = punti.ToString();
            this.Controls.Remove(pictureBoxes2[pos2]);
            tempo2 = 0;
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            if (numVite < 1)
            {
                finale();
            }
            else
            {
                this.Controls.Remove(vita[numVite]);
                numVite--;
            }
            this.Controls.Remove(pictureBoxes2[pos2]);
            tempo2 = 0;
        }
        private void finale()
        {
            timer1.Stop();
            timer2.Stop();
            this.Controls.Clear();
            Label label1 = new Label();
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(600, 400);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(44, 16);
            label1.TabIndex = 2;
            label1.Text = string.Format("Hai avuto un punteggio di {0} punti", punti);
            this.Controls.Add(label1);
        }
    }
}