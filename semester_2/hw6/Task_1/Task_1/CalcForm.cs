using System;
using System.Linq;
using System.Windows.Forms;

namespace Task_1
{
    /// <summary>
    /// Класс, реализующий работу калькулятора
    /// </summary>
    public partial class Calc : Form
    {
        /// <summary>
        /// Значение первого введенного числа
        /// </summary>
        private float value1 = 0;

        /// <summary>
        /// Тип операции
        /// </summary>
        private string operation = "";

        /// <summary>
        /// имеет значение true, если оператор уже был введен
        /// </summary>
        private bool operatorWasEntered = false;

        /// <summary>
        /// Конструктор для класса
        /// </summary>
        public Calc() => InitializeComponent();

        /// <summary>
        /// Событие, возникающее при нажатии цифры
        /// </summary>
        private void OnNumberButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            
            if (display.Text == "0" || display.Text == "Деление на 0!")
            {
                display.Text = button.Text;
            }
            else
            {
                display.Text += button.Text;
            } 
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки операции (прибавить, вычесть, разделить, умножить)
        /// </summary>
        private void OnOperationButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (display.Text != "Деление на 0!" && !operatorWasEntered)
            {
                value1 = float.Parse(display.Text);
                operatorWasEntered = true;
                display.Text = "0";
                operation = button.Text;
            }
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки "Очистить"
        /// </summary>
        private void OnClearButtonClick(object sender, EventArgs e)
        {
            display.Text = "0";
            operatorWasEntered = false;
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки "Равно"
        /// </summary>
        private void OnGetResultButtonClick(object sender, EventArgs e)
        {
            if (display.Text != "Деление на 0!" && operatorWasEntered)
            {
                var value2 = float.Parse(display.Text);

                if (operation == "÷" && value2 == 0)
                {
                    display.Text = "Деление на 0!";
                }
                else
                {
                    display.Text = Calculate(value1, value2).ToString();
                }

                operatorWasEntered = false;
            }
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки "Сменить знак"
        /// </summary>
        private void OnChangeSignButtonClick(object sender, EventArgs e)
        {
            if (display.Text != "Деление на 0!")
            {
                if (display.Text[0] == '-')
                {
                    display.Text = display.Text.Substring(1, display.Text.Length - 1);
                }
                else
                {
                    display.Text = "-" + display.Text;
                }
            }
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки "Точка"
        /// </summary>
        private void OnPointButtonClick(object sender, EventArgs e)
        {
            if (!display.Text.Contains(',') && display.Text != "Деление на 0!")
            {
                display.Text += ',';
            }
        }

        /// <summary>
        /// Событие, возникающее при нажатии кнопки "Процент"
        /// </summary>
        private void OnPercentButtonClick(object sender, EventArgs e)
        {
            if (!operatorWasEntered && display.Text != "Деление на 0!")
            {
                display.Text = (float.Parse(display.Text) / 100).ToString();
            }
        }

        /// <summary>
        /// Вычисление результата
        /// </summary>
        /// <param name="value1">Первое значение</param>
        /// <param name="value2">Второе значение</param>
        /// <returns>Результат вычислений в виде строки</returns>
        private float Calculate(float value1, float value2)
        {
            switch (operation)
            {
                case "+":
                    return value1 + value2;
                case "-":
                    return value1 - value2;
                case "×":
                    return value1 * value2;
                case "÷":
                    return value1 / value2;
                default:
                    return 0;
            }
        }
    }
}
