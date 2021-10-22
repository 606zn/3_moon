using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3_moon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // DoubleBuffered = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Timer timer = new Timer();  // объект - таймер
            timer.Interval = 40;        // тик - каждые 40 миллисекунд
            int count = 0;              // счетчик перемещений
            int max = 140;              // их максимальное число
            int x = 18;                 // начальные
            int y = 18;                 // координаты
            int d = 50;                 // диаметр шара
            Graphics g = this.CreateGraphics();  // объект - на форме
            g.Clear(Color.DarkBlue);             // очистка цветом фона
            SolidBrush br = new SolidBrush(Color.Yellow);  // задание кисти
            SolidBrush brf = new SolidBrush(Color.DarkBlue);  // задание фона
            g.FillEllipse(br, x, y, d, d);       // заливка - начало
                                                 // Каждые 40 мс будет удаляться и рисоваться новый шарик, остановка через 150 раз
            timer.Tick += new EventHandler((o, ev) =>
            {
                g.FillEllipse(brf, x, y, d, d);
                x += 7;
                y += 4;
                g.FillEllipse(br, x, y, d, d);
                count++;
                if (count == max)
                    timer.Stop();
            }
            );
            timer.Start();   // запустили, остановится сам
        }

    }
}
