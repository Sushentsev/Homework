using System;
using System.Windows.Forms;

namespace Task_2
{
    /// <summary>
    /// Приложение, показывающее текущее время
    /// </summary>
    public partial class ClockForm : Form
    {
        /// <summary>
        /// Конструктор для класса ClockForm
        /// </summary>
        public ClockForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие, возникающее при тиканье таймера
        /// </summary>
        private void OnTimerTick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
