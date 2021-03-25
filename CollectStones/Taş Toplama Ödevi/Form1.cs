using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taş_Toplama_Ödevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int k;
        int r=0;
        int n;
        int g1;
        int h1;
        int[,] m = new int[10, 10];
        int l, l1;
        int tlx, tly;
        int p1win;
        int p2win;
        
        
        PictureBox[,] P;
        public void Form1_Load(object sender, EventArgs e)
        {          
            n = 10;
            P = new PictureBox[n, n];           
            int left = 2, top = 2;          
            Color[] colors = new Color[] { Color.White, Color.Black };
            for (int i = 0; i < n; i++)
            {
                left = 2;
                if (i % 2 == 0) { colors[0] = Color.White; colors[1] = Color.Black; }
                else { colors[0] = Color.Black; colors[1] = Color.White; }
                for ( int j = 0; j < n; j++)
                {                   
                    P[j, i] = new PictureBox();
                    P[j, i].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[j, i].Location = new Point(left, top);
                    P[j, i].Size = new Size(70, 70);
                    left += 70;                   
                    P[j, i].Name = j + " " + i;                   
                    P[j, i].SizeMode = PictureBoxSizeMode.CenterImage;
                   
                    P[j, i].MouseClick += (sender2, e2) =>
                    {                       
                        int g;
                        int h;
                        PictureBox p = sender2 as PictureBox;
                        if (r == 1)
                        {
                            if (p.Image != null)
                            {                                
                                g = Hesapla(p.Location.X);
                                h = Hesapla(p.Location.Y);
                                
                                if (P[g, h].Name == "p1" || P[g, h].Name == "p2")
                                {
                                    Temizle();
                                    g1 = g;
                                    h1 = h;

                                    
                                    if (g > 0)
                                    {
                                        if ( P[g - 1, h].Image == null)
                                        {
                                            P[g - 1,h ].Image = Properties.Resources.tick;
                                            P[g - 1,h ].Name = "tick";
                                        }
                                        else if (P[g - 1, h].Name=="t")
                                        {
                                            P[g - 1, h].Name = "t2";
                                        }                                       
                                    }

                                    if (g < 9)
                                    {
                                        if (P[g + 1, h].Image == null)
                                        {                                         
                                            P[g + 1, h].Image = Properties.Resources.tick;
                                            P[g + 1, h].Name = "tick";
                                        }
                                        else if (P[g + 1, h].Name == "t")
                                        {
                                            P[g + 1, h].Name = "t2";
                                        }
                                    }

                                    if (h > 0)
                                    {
                                        if (P[g , h-1].Image == null)
                                        {
                                            P[g, h - 1].Image = Properties.Resources.tick;
                                            P[g, h - 1].Name = "tick";
                                        }
                                        else if (P[g , h - 1].Name == "t")
                                        {
                                            P[g , h - 1].Name = "t2";
                                        }
                                    }

                                    if (h < 9)
                                    {
                                        if (P[g, h + 1].Image == null)
                                        {
                                            P[g, h + 1].Image = Properties.Resources.tick;
                                            P[g, h + 1].Name = "tick";
                                        }
                                        else if (P[g, h + 1].Name == "t")
                                        {
                                            P[g, h + 1].Name = "t2";
                                        }
                                    }
                                }    
                                
                                if (p.Name =="tick")
                                {                                                                      
                                    g = Hesapla(p.Location.X);
                                    h = Hesapla(p.Location.Y);
                                    P[g, h].Name = P[g1, h1].Name;
                                    P[g1,h1].Name = g1 + " " + h1;

                                    if (P[g, h].Name == "p1")
                                    {
                                        p.Image = Properties.Resources.player1;
                                        P[g1, h1].Image = null;
                                        
                                        MesafeYazici(g1, h1, p);
                                        
                                    }

                                    else if (P[g, h].Name == "p2")
                                    {
                                        p.Image = Properties.Resources.player2;
                                        P[g1, h1].Image = null;
                                        
                                        MesafeYazici(g1, h1, p);
                                        
                                    }
                                    Temizle();                                                                       
                                }

                                else if (p.Name=="t2")
                                {
                                    g = Hesapla(p.Location.X);
                                    h = Hesapla(p.Location.Y);
                                    if (P[g1, h1].Name=="p1")
                                    {
                                        p1win--;
                                        if (p1win==0)
                                        {
                                            MessageBox.Show("Player 1 Win");
                                            MessageBox.Show("Game Over!");
                                            Application.Restart();

                                        }
                                    }
                                    else if (P[g1, h1].Name == "p2")
                                    {
                                        p2win--;
                                        if (p1win == 0)
                                        {
                                            MessageBox.Show("Player 2 Win");
                                            MessageBox.Show("Game Over!");
                                            Application.Restart();
                                        }
                                    }
                                    P[g1, h1].Name = h1 + " " + g1;
                                    P[g1, h1].Image = null;
                                    p.Name = "t";                                     
                                    Temizle();
                                    
                                    
                                }
                            }                           
                        }
                                              
                        else
                        {
                            if (p.Image == null)
                            {
                                int t;
                                
                                switch (k)
                                {
                                    case 1:
                                        if (Convert.ToInt32(lbl_target.Text) > 0)
                                        {
                                            t = Convert.ToInt32(lbl_target.Text);
                                            t--;
                                            if (t == 0)
                                            {
                                                btn_target.Enabled = false;                                               
                                            }
                                            lbl_target.Text = Convert.ToString(t);

                                            g = Hesapla(p.Location.X);
                                            h = Hesapla(p.Location.Y);
                                            tlx = p.Location.X;
                                            tly = p.Location.Y;
                                            P[g,h].Name ="t" ;                                           
                                            p.Image = Properties.Resources.target;
                                        }
                                        break;

                                    case 2:
                                        if (Convert.ToInt32(lbl_wall.Text) > 0)
                                        {
                                            t = Convert.ToInt32(lbl_wall.Text);
                                            t--;
                                            if (t == 0)
                                            {
                                                btn_wall.Enabled = false;                                               
                                            }
                                            lbl_wall.Text = Convert.ToString(t);
                                            g = Hesapla(p.Location.X);
                                            h = Hesapla(p.Location.Y);
                                            P[g, h].Name = "w";
                                            p.Image = Properties.Resources.wall;
                                        }
                                        break;

                                    case 3:
                                        if (Convert.ToInt32(lbl_player1.Text) > 0)
                                        {
                                            t = Convert.ToInt32(lbl_player1.Text);
                                            t--;
                                            if (t == 0)
                                            {
                                                btn_player1.Enabled = false;                                             
                                            }
                                            lbl_player1.Text = Convert.ToString(t);

                                            g = Hesapla(p.Location.X);
                                            h = Hesapla(p.Location.Y);
                                            P[g, h].Name = "p1";
                                            p.Image = Properties.Resources.player1;
                                            
                                            p.Paint += new PaintEventHandler((sender3, e3) =>
                                            {
                                                l = p.Location.X - tlx;
                                                l1 = p.Location.Y - tly;
                                                m[g, h] = MesafeHesapla(l, l1);

                                                string text = Convert.ToString(MesafeHesapla(l, l1));

                                                SizeF textSize = e3.Graphics.MeasureString(text, Font);
                                                PointF locationToDraw = new PointF();
                                                locationToDraw.X = (p.Width / 2) - (textSize.Width / 2);
                                                locationToDraw.Y = (p.Height / 2) - (textSize.Height / 2);

                                                if (p.BackColor == Color.Black)
                                                {
                                                    e3.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
                                                }
                                                else
                                                    e3.Graphics.DrawString(text, Font, Brushes.White, locationToDraw);
                                            });
                                                                                      
                                        }
                                        break;

                                    case 4:
                                        if (Convert.ToInt32(lbl_player2.Text) > 0)
                                        {
                                            t = Convert.ToInt32(lbl_player2.Text);
                                            t--;
                                            if (t == 0)
                                            {
                                                btn_player2.Enabled = false;                                             
                                            }
                                            lbl_player2.Text = Convert.ToString(t);
                                            g = Hesapla(p.Location.X);
                                            h = Hesapla(p.Location.Y);
                                            P[g, h].Name = "p2";

                                            p.Image = Properties.Resources.player2;
                                            p.Paint += new PaintEventHandler((sender3, e3) =>
                                            {
                                                l = p.Location.X - tlx;
                                                l1 = p.Location.Y - tly;
                                                m[g, h] = MesafeHesapla(l, l1);

                                                string text = Convert.ToString(m[g, h]);

                                                SizeF textSize = e3.Graphics.MeasureString(text, Font);
                                                PointF locationToDraw = new PointF();
                                                locationToDraw.X = (p.Width / 2) - (textSize.Width / 2);
                                                locationToDraw.Y = (p.Height / 2) - (textSize.Height / 2);

                                                if (p.BackColor == Color.Black)
                                                {
                                                    e3.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
                                                }
                                                else
                                                    e3.Graphics.DrawString(text, Font, Brushes.White, locationToDraw);
                                            });

                                        }
                                        break;
                                }
                            }
                        }
                    };
                    G.Controls.Add(P[j, i]);
                }              
                top += 70;
            }          
        }
        
        private void MesafeYazici(int x, int y, PictureBox p)
        {
            p.Paint += new PaintEventHandler((sender3, e3) =>
            {                
                string text = Convert.ToString(m[x, y] - 1);
                m[Hesapla(p.Location.X), Hesapla(p.Location.Y)] = m[x,y] - 1;
                if (m[Hesapla(p.Location.X), Hesapla(p.Location.Y)]==0)
                {
                    if (P[Hesapla(p.Location.X), Hesapla(p.Location.Y)].Name=="p1")
                    {
                        MessageBox.Show("Player 1 Lost");
                        MessageBox.Show("Game Over!");
                    }
                    else if (P[Hesapla(p.Location.X), Hesapla(p.Location.Y)].Name == "p2")
                    {
                        MessageBox.Show("Player 2 Lost");
                        MessageBox.Show("Game Over!");
                    }
                    Application.Restart();
                }

                SizeF textSize = e3.Graphics.MeasureString(text, Font);
                PointF locationToDraw = new PointF();
                locationToDraw.X = (p.Width / 2) - (textSize.Width / 2);
                locationToDraw.Y = (p.Height / 2) - (textSize.Height / 2);

                if (p.BackColor == Color.Black)
                {
                    e3.Graphics.DrawString(text, Font, Brushes.Black, locationToDraw);
                }
                else
                    e3.Graphics.DrawString(text, Font, Brushes.White, locationToDraw);
            });
        }

        public void Temizle()
        {
            int tmz, tmz1;
            for (tmz = 0; tmz < 10; tmz++)
            {
                for (tmz1 = 0; tmz1 < 10; tmz1++)
                {
                    if (P[tmz, tmz1].Name == "tick")
                    {
                        P[tmz, tmz1].Image = null;
                    }
                    if (P[tmz, tmz1].Name == "t2")
                    {
                        P[tmz, tmz1].Name = "t";
                    }
                }
            }
        }
        public int MesafeHesapla(int a, int p)
        {
            if (a < 0)
            {
                a = a * -1;
            }
            if (p < 0)
            {
                p = p * -1;
            }
            return (p + a) / 70;
        }
        private int Hesapla(int x )
        {
            x = x - 2;
            if (x == 0)
            {
                return 0;
            }
            else
                return x / 70;
        }
        private void btn_target_Click(object sender, EventArgs e)
        {
            k = 1;
        }
        private void btn_wall_Click(object sender, EventArgs e)
        {
            k = 2;
        }
        private void btn_player1_Click(object sender, EventArgs e)
        {
            k = 3;
        }
        private void btn_player2_Click(object sender, EventArgs e)
        {
            k = 4;
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            r = 1 ;
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            if (rdb_lvl1.Checked == true)
            {
                lbl_player1.Text = "5";
                lbl_player2.Text = "5";
                lbl_wall.Text = "2";
                p1win = 5;
                p2win = 5;
            }
            if (rdb_lvl2.Checked == true)
            {
                lbl_player1.Text = "7";
                lbl_player2.Text = "7";
                lbl_wall.Text = "4";
                p1win = 7;
                p2win = 7;
            }
            if (rdb_singleplayer.Checked==true)
            {
                btn_player2.Enabled = false;
                btn_player2.Visible = false;
                lbl_player2.Visible = false;
                
            }
            rdb_singleplayer.Enabled = false;
            rdb_multiplayer.Enabled = false;
            rdb_lvl2.Enabled = false;
            rdb_lvl1.Enabled = false;
            btn_target.Enabled = true;
            btn_wall.Enabled = true;
            btn_player1.Enabled = true;
            btn_player2.Enabled = true;
            btn_tasdiz.Enabled = false;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
