using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Autopista_en_fuga_2
{
    public partial class Form1 : Form
    {
        private int Velocidad;
        private PictureBox[] road = new PictureBox[8];
        private int Puntaje = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Velocidad = 3;
            road[0] = pictureBox1;
            road[1] = pictureBox2;
            road[2] = pictureBox3;
            road[3] = pictureBox4;
            road[4] = pictureBox5;
            road[5] = pictureBox6;
            road[6] = pictureBox7;
            road[7] = pictureBox8;

        }

        private void MovimientoPista_Tick(object sender, EventArgs e)
        {
            foreach (PictureBox pb in road)
            {
                pb.Top += Velocidad;
                if (pb.Top >= this.Height)
                {
                    pb.Top = -pb.Height;
                }
            }
            if (Puntaje > 10 && Puntaje < 30)
            {
                Velocidad = 5;
            }
            if (Puntaje > 30 && Puntaje < 50)
            {
                Velocidad = 6;
            }
            if (Puntaje > 50 && Puntaje < 70)
            {
                Velocidad = 7;
            }
            if (Puntaje > 100)
            {
                Velocidad = 9;
            }
            label2.Text = "Velocidad" + Velocidad;
            if ((CarroPrincipal.Bounds.IntersectsWith(Carro1.Bounds)))
            {
                endgame();
            }
            if ((CarroPrincipal.Bounds.IntersectsWith(Carro2.Bounds)))
            {
                endgame();
            }
            if ((CarroPrincipal.Bounds.IntersectsWith(Carro3.Bounds)))
            {
                endgame();
            }

        }
        private void endgame()
        {
            button1.Visible = true;
            label3.Visible = true;
            MovimientoPista.Stop();
            CarroAmarillo.Stop();
            CarroAzulSubido.Stop();
            CarroAzulBajo.Stop();
        }

        private void LadoDerecho_Tick(object sender, EventArgs e)
        {
            if (CarroPrincipal.Location.X < 275)
            {
                CarroPrincipal.Left += 5;
            }
        }



        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                LadoDerecho.Start();
            }
            if (e.KeyCode == Keys.Left)
            {
                LadoIzquierdo.Start();
            }
            if (e.KeyCode == Keys.Up)
            {
                LadoArriba.Start();
            }
            if (e.KeyCode == Keys.Down)
            {
                LadoAbajo.Start();
            }
        }

        

        private void LadoIzquierdo_Tick(object sender, EventArgs e)
        {
            if (CarroPrincipal.Location.X > 0)
            {
                CarroPrincipal.Left -= 5;
            }
        }
        
       

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            LadoDerecho.Stop();
            LadoIzquierdo.Stop();
            LadoArriba.Stop();
            LadoAbajo.Stop();
        }

        private void CarroAmarillo_Tick(object sender, EventArgs e)
        {
            Carro1.Top += Velocidad / 2;
            if (Carro1.Top >= this.Height)
            {
                Puntaje += 1;
                label1.Text = "Puntaje " + Puntaje;



                Random rnd = new Random();
                Carro1.Top = -(Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 200)) + Carro1.Height);
                Carro1.Left = Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 50)) + 0;
            }
        }


        private void CarroAzulSubido_Tick(object sender, EventArgs e)
        {
            Carro2.Top += Velocidad / 3;
            if (Carro2.Top >= this.Height)
            {
                Puntaje += 1;
                label1.Text = "Puntaje " + Puntaje;

                Random rnd = new Random();
                Carro2.Top = -(Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 200)) + Carro2.Height);
                Carro2.Left = Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 50)) + 100;
            }
        }
        private void CarroAzulBajo_Tick(object sender, EventArgs e)
        {
            Carro3.Top += Velocidad * 1 / 2;
            if (Carro3.Top >= this.Height)
            {
                Puntaje += 1;
                label1.Text = "Puntaje " + Puntaje;
                Random rnd = new Random();
                Carro3.Top = -(Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 200)) + Carro3.Height);
                Carro3.Left = Convert.ToInt32(Math.Ceiling(rnd.NextDouble() * 120)) + 180;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Puntaje = 0;
            this.Controls.Clear();
            InitializeComponent();
            Form1_Load(e, e);
        }

        private void LadoArriba_Tick_1(object sender, EventArgs e)
        {
            if (CarroPrincipal.Top > 0) 
            {
                CarroPrincipal.Top -= 5;
            }
        }

        private void LadoAbajo_Tick_1(object sender, EventArgs e)
        {
            if (CarroPrincipal.Bottom < this.ClientSize.Height)
            {
                CarroPrincipal.Top += 5;
            }
        }
    }
}