using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мульти_калькулятор
{
    public partial class Form1 : Form
    {
        // Индикатор количества уже составленных числел (1 - 1 число готово для обработки, 2 - оба числа готовы для обработки)
        // numberisdone необходим для упрощения работы программы, поскольку мы вводим 2 оператора: любой кроме равно и само равно
        int numbersaredone = 1;

        // Индикатор заполненности дробного числа (false - число введено не до конца, true - число введено полностью)

        bool decimalisright = false;

        // Индикатор введённости оператора (false - оператор не введён, true - оператор введён)
        bool signisdone = false;

        // Первое число (дробное), введённое в калькулятор
        decimal number_1;

        // Второе число (дробное), введённое в калькулятор (определяется после подтверждения ввода первого числа)
        decimal number_2;

        // Индикатор модуля введённого числа (true - введённое число положительное, false - введённое число отрицательное)
        bool num_pos_neg = true;

        // Результат взаимодействия с введёнными ранее числами (результат - всегда дробное число)
        decimal result;

        // Индикатор полученности результата (необходим для блокировки кнопок, когда получен результат)
        bool resultisdone = false;

        // Тип совершённой операции
        string operation;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //!!!
        {
            //Проверить!!!
            if ( (number_1 < 0) || (number_2 < 0) && !(number_1 < 0 && number_2 < 0) )
            {
                num_pos_neg = false;
            }

            else
            {
                num_pos_neg = true;
            }

            /*if (numbersaredone == 1 && signisdone == true)
            {
                number_1 = Convert.ToDouble(x);
            }

            else if (numbersaredone == 2)
            {
                number_2 = Convert.ToDouble(x);
            } */
        }

        /*
         * 
         * // Калькулятор //
         * 
        */

        // Кнопка 1

        private void button1_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "1";
            }
        }

        // Кнопка 2

        private void button2_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "2";
            }
        }

        // Кнопка 3

        private void button3_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "3";
            }
        }

        // Кнопка 4

        private void button4_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "4";
            }
        }

        // Кнопка 5

        private void button5_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "5";
            }
        }

        // Кнопка 6

        private void button6_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "6";
            }
        }

        // Кнопка 7

        private void button7_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "7";
            }
        }

        // Кнопка 8

        private void button8_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "8";
            }
        }

        // Кнопка 9

        private void button9_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "9";
            }
        }

        // Кнопка 0

        private void button10_Click(object sender, EventArgs e)
        {
            if (resultisdone == false)
            {
                textBox2.Text += "0";
            }
        }

        // Кнопка , (разделение части числа -> условное превращение целого числа в дробное)

        private void button11_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf(",") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (resultisdone == false) )
            {
                decimalisright = false;
                textBox2.Text += ",";

                while ( (textBox2.Text.IndexOf(",") == -1) /*&& (по индексу вычислить введена ли цифра после запятой!!!)*/ )
                {
                    decimalisright = true;
                }
            }
        }

        // На примере данного оператора будет разобран алгоритм преобразования текста в дробное число (string в decimal)

        // Кнопка = (оператор равно - оператор, производящий вычисления)

        private void button12_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("=") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (signisdone == true) && (numbersaredone == 2) && (decimalisright == true) )
            {
                textBox2.Text += "="; // добавляет видимость оператора
                string x = textBox2.Text; // преобразовывает текст для копирования
                int x1 = x.Length - 1;
                x = x.Remove(x1); // удаляет оператор для преобразования данных в число (string в decimal)
                number_2 = Convert.ToDecimal(x); // преобразует скорректированный текст в число
                textBox2.Clear();

                switch (operation) // определение типа совершённой операции
                {
                    case "Деление":
                        
                        result = number_1 / number_2;

                        numbersaredone = 1;
                        signisdone = false;
                        /*result = 0;
                        number_1 = 0;
                        number_2 = 0;*/
                        resultisdone = false;

                        break;

                    case "Умножение":

                        result = number_1 * number_2;

                        numbersaredone = 1;
                        signisdone = false;
                        /*result = 0;
                        number_1 = 0;
                        number_2 = 0;*/
                        resultisdone = false;

                        break;

                    case "Вычитание":

                        result = number_1 - number_2;

                        numbersaredone = 1;
                        signisdone = false;
                        /*result = 0;
                        number_1 = 0;
                        number_2 = 0;*/
                        resultisdone = false;

                        break;

                    case "Сложение":

                        result = number_1 + number_2;

                        numbersaredone = 1;
                        signisdone = false;
                        /*result = 0;
                        number_1 = 0;
                        number_2 = 0;*/
                        resultisdone = false;

                        break;
                }

                textBox2.Text += result;

                resultisdone = true;
            }
        }

        // Кнопка DEL (оператор удаления последнего символа введённого числа / оператор удаления результата взаимодействия чисел для ввода новых значений чисел)

        private void button13_Click(object sender, EventArgs e) // !!!
        {
            if (resultisdone == false)
            {
                //textBox2.Text = Convert.ToString(number_1);
            }

            if (resultisdone == true)
            {
                textBox2.Clear();
                numbersaredone = 1;
                signisdone = false;
                /*result = 0;
                number_1 = 0;
                number_2 = 0;*/
                resultisdone = false;
            }
        }

        // Кнопка / (оператор деления)

        private void button14_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("/") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (num_pos_neg == true) && (resultisdone == false) && (decimalisright == true) ) // функция будет выполняться только тогда, когда число (оба числа?) положительное
            {
                operation = "Деление";
                textBox2.Text += "/";
                signisdone = true; // даёт программе понять, что оператор введён
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                textBox2.Clear();

                numbersaredone++;
            }
        }

        // Кнопка * (оператор умножения)

        private void button15_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("*") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (num_pos_neg == true) && (resultisdone == false) && (decimalisright == true) )
            {
                operation = "Умножение";
                textBox2.Text += "*";
                signisdone = true;
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                textBox2.Clear();

                numbersaredone++;
            }
        }

        // Кнопка - (оператор вычитания) / !!!

        private void button16_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("-") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (num_pos_neg == true) && (resultisdone == false) && (decimalisright == true) )
            {
                textBox2.Text += "-";
                signisdone = true;
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                numbersaredone++;
            }
        }

        // Кнопка + (оператор сложения) / !!!

        private void button17_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("+") == -1) && (textBox2.Text.IndexOf("∞") == -1) && (num_pos_neg == true) && (resultisdone == false) && (decimalisright == true) )
            {
                textBox2.Clear();
                if (signisdone == false)
                {
                    /*number_1 = decimal.Parse(textBox2.Text);
                    textBox2.Clear();
                    textBox2.Text = number_1.ToString() + "+";
                    signisdone = true;
                    numberisdone++;
                }

                else
                {
                    textBox2.Text = "KJK";
                    //this.Close();*/

                    textBox2.Text += "+";
                    signisdone = true;
                    string x = textBox2.Text;
                    int x1 = x.Length - 1;
                    x = x.Remove(x1);
                    //number_1 = Convert.ToDecimal(x);
                    numbersaredone++;
                    textBox2.Clear();
                }
            }
        }

        // Кнопка INV (оператор инвариации числа) / !!!

        private void button18_Click(object sender, EventArgs e)
        {

        }

        // Кнопка DEG (перевод из режима ввода градусов в режим ввода радиан (для sin, cos и tg) )

        private void button19_Click(object sender, EventArgs e)
        {
            // Сделать if clicked -> DEG -> RED (надпись меняется)
        }

        // Кнопка % (оператор процента) // !!!

        private void button20_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("%") == -1) && (textBox2.Text.IndexOf("∞") == -1) )
            {
                textBox2.Text += "%";
                numbersaredone++;
            }
        }

        // Кнопка SIN (оператор синуса) // !!!

        private void button21_Click(object sender, EventArgs e)
        {
            textBox2.Text += "sin(";
        }

        // Кнопка COS (косинуса) // !!!

        private void button22_Click(object sender, EventArgs e)
        {
            textBox2.Text += "cos(";
        }

        // Кнопка TAN (тангенса) // !!!

        private void button23_Click(object sender, EventArgs e)
        {
            textBox2.Text += "tan(";
        }

        // Кнопка LN (оператор натурального логорифма) // !!!

        private void button24_Click(object sender, EventArgs e)
        {
            textBox2.Text += "ln(";
        }

        // Кнопка LOG (оператор логорифма)

        private void button25_Click(object sender, EventArgs e)
        {
            textBox2.Text += "log(";
        }

        // Кнопка ! (оператор факториала) // !!!

        private void button26_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("!") == -1) && (textBox2.Text.IndexOf("∞") == -1) )
            {
                textBox2.Text += "!";
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                numbersaredone++;
            }
        }

        // Кнопка π (оператор пи) // !!!

        private void button27_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("π") == -1) && (textBox2.Text.IndexOf("∞") == -1) )
            {
                textBox2.Text += "π";
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                numbersaredone++;
            }
        }

        // Кнопка e (оператор экспаненты) // !!!

        private void button28_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("e") == -1) && (textBox2.Text.IndexOf("∞") == -1) )
            {
                textBox2.Text += "e";
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                numbersaredone++;
            }
        }

        // Кнопка ^ (оператор возведения в степень) // !!!

        private void button29_Click(object sender, EventArgs e)
        {
            if ( (textBox2.Text.IndexOf("^") == -1) && (textBox2.Text.IndexOf("∞") == -1) )
            {
                textBox2.Text += "^";
                string x = textBox2.Text;
                int x1 = x.Length - 1;
                x = x.Remove(x1);
                number_1 = Convert.ToDecimal(x);
                numbersaredone++;
            }
        }

        // Кнопка ( (оператор открытия скобки) // !!!

        private void button30_Click(object sender, EventArgs e)
        {
            textBox2.Text += "(";
        }

        // Кнопка ) (оператор закрытия скобки) // !!!

        private void button31_Click(object sender, EventArgs e)
        {
            textBox2.Text += ")";
        }

        // Кнопка √ (оператор извлечения квадрата) // !!!

        private void button32_Click(object sender, EventArgs e)
        {
            textBox2.Text += "√";
            string x = textBox2.Text;
            int x1 = x.Length - 1;
            x = x.Remove(x1);
            number_1 = Convert.ToDecimal(x);
            numbersaredone++;
        }

        // Кнопка +/- (оператор изменения модуля числа) // !!!

        private void button33_Click(object sender, EventArgs e) // !!!
        {
            //textBox2.Text = Convert.ToString(number_1);
        }

        // Окно ввода / вывода данных из калькулятора

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*if (numberisdone == 1)
            {
                number_1 = Convert.ToDouble(textBox2.Text);
                textBox2.Text = Convert.ToString(number_1);

                string y = textBox2.Text;
                int y1 = y.Length - 1;
                y = y.Remove(y1);
                number_2 = Convert.ToDouble(y);
                textBox2.Text = Convert.ToString(number_2);
            }*/
        }

        /*
         *
         * // Программный калькулятор //
         *  
        */

        /* // Кнопка 0

        private void button34_Click(object sender, EventArgs e) // !!!
        {
            textBox4.Text += "0";
        }

        // Кнопка 1

        private void button35_Click(object sender, EventArgs e) // !!!
        {
            textBox4.Text += "1";
        }

        // Кнопка = (оператор равно / вычисления)

        private void button36_Click(object sender, EventArgs e) // !!!
        {
            if ( (textBox4.Text.IndexOf("=") == -1) && (textBox4.Text.IndexOf("∞") == -1) )
            {
                textBox4.Text += "=";
                numberisdone = true;
            }
        }

        // Кнопка - (оператор вычитания) 

        private void button37_Click(object sender, EventArgs e) // !!!
        {
            if ( (textBox4.Text.IndexOf("-") == -1) && (textBox4.Text.IndexOf("∞") == -1) )
            {
                textBox4.Text += "-";
                numberisdone= true;
            }
        }

        // Кнопка + (оператор сложения)

        private void button38_Click(object sender, EventArgs e)
        {
            if ( (textBox4.Text.IndexOf("+") == -1) && (textBox4.Text.IndexOf("∞") == -1) )
            {
                textBox4.Text += "+";
                numberisdone = true;
            }
        }

        // Кнопка * (оператор умножения)

        private void button39_Click(object sender, EventArgs e) // !!!
        {
            if ( (textBox4.Text.IndexOf("*") == -1) && (textBox4.Text.IndexOf("∞") == -1) )
            {
                textBox4.Text += "*";
                numberisdone = true;
            }
        }

        // Окно ввода / вывода данных из программного калькулятора // !!! */

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {
            Environment.Exit(0); // закрытие программы
        }
    }
}