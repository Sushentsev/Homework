using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Контрольная_работа
{
    /// <summary>
    /// Игра "Найди пару".
    /// Текст кнопок черный, фон черный. 
    /// Если пользователь нажимает кнопку, то фон становится белым.
    /// </summary>
    public partial class Form : System.Windows.Forms.Form
    {
        /// <summary>
        /// Количество конопок в строке.
        /// Пользователь должен сам иницилизировать значением.
        /// </summary>
        private int n;

        /// <summary>
        /// Список всех значенией.
        /// </summary>
        private List<int> values = new List<int>();

        /// <summary>
        /// Первая открытая кнопка.
        /// </summary>
        private Button firstClickedButton;

        /// <summary>
        /// Вторая открытая кнопка
        /// </summary>
        private Button secondClickedButton;
        
        /// <summary>
        /// Иницилизация формы
        /// </summary>
        public Form()
        {
            InitializeComponent();
            OnFormCreation();
        }

        /// <summary>
        /// Событие, возникающее при создании формы
        /// </summary>
        private void OnFormCreation()
        {
            if (n % 2 == 1)
            {
                throw new IncorrectSizeException("Нечетное количество кнопок!");
            }

            LoadValues(values);
            FillButtonsByValues();
        }

        /// <summary>
        /// Заполнение списка значениями
        /// </summary>
        /// <param name="values">Список для заполнения</param>
        private void LoadValues(List<int> values)
        {
            for (var i = 1; i <= (n^2 / 2); ++i)
            {
                for (var j = 1; j <= 2; ++j)
                {
                    values.Add(i);
                }
            }
        }

        /// <summary>
        /// Заполнение кнопок значениями
        /// </summary>
        private void FillButtonsByValues()
        {
            //Перебор всех Controls в TableLayout
            foreach (var control in tableLayout.Controls)
            {
                var button = control as Button;

                if (button != null)
                {
                    var random = new Random();
                    var randomValue = random.Next(values.Count);
                    button.Text = Convert.ToString(values[randomValue]);
                    button.BackColor = Color.Black;
                    values.RemoveAt(randomValue);
                }
            }
        }

        /// <summary>
        /// Событие, возникающее при нажатии на кнопку
        /// </summary>
        private void OnButtonClick(object sender, EventArgs e)
        {
            CheckingOnWin();
            var button = sender as Button;

            //Проверка на то, что кнопка уже нажата либо уже неактивна
            if (button.BackColor == Color.White)
            {
                return;
            }

            button.BackColor = Color.White;

            if (firstClickedButton == null)
            {
                firstClickedButton = button;
            }
            else if (secondClickedButton == null)
            {
                secondClickedButton = button;

                if (firstClickedButton.Text == secondClickedButton.Text)
                {
                    firstClickedButton = null;
                    secondClickedButton = null;
                }
            }
            else
            {
                firstClickedButton.BackColor = Color.Black;
                secondClickedButton.BackColor = Color.Black;
                firstClickedButton = button;
                secondClickedButton = null;
            }
        }

        //Проверка на выигрыш
        private void CheckingOnWin()
        {
            foreach (var control in tableLayout.Controls)
            {
                var button = control as Button;

                if (button != null)
                {
                    if (button.BackColor == Color.Black)
                    {
                        return;
                    }
                }

                MessageBox.Show("Вы выиграли игру! Конгратюлэйшонс!");
                Close();
            }
        }
    }
}
