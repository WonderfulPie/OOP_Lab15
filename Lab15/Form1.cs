using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace MyCalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;
            button5.Click += button5_Click;
            button6.Click += button6_Click;
            button7.Click += button7_Click;
        }
        //--------------------- Завдання 1 --------------------------//
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання значень x і y з текстових полів
                double x = double.Parse(textBoxXTab1.Text);
                double y = double.Parse(textBoxYTab1.Text);

                // Обчислення виразу за заданою формулою
                double result = (3 + Math.Pow(Math.E, y - 1)) / (1 + Math.Pow(x, 2) * Math.Abs(y - Math.Tan(x)));

                // Відображення результату у вікні виводу
                label3Tab1.Text = "Результат: " + result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення для x та y.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сталася помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //--------------------- Завдання 2 --------------------------//

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання значень сторін трикутника з текстових полів
                double a = double.Parse(textBoxATab2.Text);
                double b = double.Parse(textBoxBTab2.Text);
                double c = double.Parse(textBoxCTab2.Text);

                // Обчислення кутів трикутника у радіанах за косинусним правилом
                double cosA = (b * b + c * c - a * a) / (2 * b * c);
                double cosB = (a * a + c * c - b * b) / (2 * a * c);
                double cosC = (a * a + b * b - c * c) / (2 * a * b);

                // Переведення радіан у градуси
                double angleA = Math.Round(Math.Acos(cosA) * (180 / Math.PI), 3);
                double angleB = Math.Round(Math.Acos(cosB) * (180 / Math.PI), 3);
                double angleC = Math.Round(Math.Acos(cosC) * (180 / Math.PI), 3);

                // Виведення результатів
                label4Tab2.Text = $"Кут A: {angleA} градусів ({cosA} радіан)\n" +
                                   $"Кут B: {angleB} градусів ({cosB} радіан)\n" +
                                   $"Кут C: {angleC} градусів ({cosC} радіан)";
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення. Будь ласка, введіть числові значення для сторін трикутника.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //--------------------- Завдання 3 --------------------------//

        private bool CheckNumber(int N)
        {
            // Перевірка чи число N парне і має дві цифри
            return (N % 2 == 0) && (N >= 10 && N <= 99);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання значення N з текстового поля
                int N = int.Parse(textBox1Tab3.Text);

                // Перевірка та виведення результату
                bool result = CheckNumber(N);
                label2Tab3.Text = result.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення. Будь ласка, введіть ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //--------------------- Завдання 4 --------------------------//

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання вартості книги та суми грошей введених користувачем
                double bookCost = double.Parse(label2Tab4.Text);
                double moneyPaid = double.Parse(textBox1Tab4.Text);

                // Перевірка, чи грошей внесено достатньо
                if (moneyPaid == bookCost)
                {
                    label1Tab4.Text = "Дякую!";
                }
                else if (moneyPaid > bookCost)
                {
                    double change = moneyPaid - bookCost;
                    label1Tab4.Text = $"Візьміть решту: {change} грн";
                }
                else
                {
                    double amountDue = bookCost - moneyPaid;
                    label1Tab4.Text = $"Грошей недостатньо. Сума відсутня: {amountDue} грн";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення. Будь ласка, введіть числові значення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------- Завдання 5 --------------------------//

        private bool IsPerfect(int num)
        {
            int sum = 1; // Ініціалізуємо суму з значенням 1, оскільки 1 є дільником для будь-якого числа

            // Перевіряємо всі числа від 2 до квадратного кореня з num
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    sum += i;
                    int divisor = num / i;
                    if (divisor != i) // Додаємо тільки унікальні дільники
                    {
                        sum += divisor;
                    }
                }
            }

            // Число num є досконалим, якщо sum дорівнює num
            return sum == num;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо введене користувачем значення N
                int N = int.Parse(textBox1Tab5.Text);

                // Проходимо через всі натуральні числа менші за N та виводимо досконалі числа
                listBox1Tab5.Items.Clear();
                for (int i = 1; i < N; i++)
                {
                    if (IsPerfect(i))
                    {
                        listBox1Tab5.Items.Add(i);
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення. Будь ласка, введіть ціле число.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //--------------------- Завдання 6 --------------------------//

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання значень з текстового поля та перетворення їх у цілі числа
                int k = int.Parse(textBox1Tab6.Text);
                int[] originalArray = Array.ConvertAll(textBox2Tab6.Text.Split(','), int.Parse);

                // Створення списку для зберігання елементів, які закінчуються на k
                List<int> newArray = new List<int>();

                // Проходження по кожному елементу вихідного масиву
                foreach (int num in originalArray)
                {
                    // Перевірка, чи закінчується елемент на k
                    if (num % 10 == k)
                    {
                        // Додавання елемента до нового масиву
                        newArray.Add(num);
                    }
                }

                // Виведення нового масиву на екран
                label2Tab6.Text = string.Join(", ", newArray);
            }
            catch (FormatException)
            {
                MessageBox.Show("Помилка введення. Будь ласка, введіть цілі числа, розділені комами.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //--------------------- Завдання 7 --------------------------//

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string text = textBox1Tab7.Text;
                // Створюємо масив символів, що містить всі знаки препинання
                char[] punctuationMarks = { '.', ',', ';', ':', '!', '?', '"', '\'', '(', ')', '[', '-', '+', ']', '{', '}', '<', '>', '/', '\\' };

                // Розділити рядок на слова, використовуючи пробіли та знаки препинання як роздільники
                string[] words = text.Split(new char[] { ' ' }.Concat(punctuationMarks).ToArray(), StringSplitOptions.RemoveEmptyEntries);

                // Знайти найкоротше і найдовше слово
                string shortestWord = words[0];
                string longestWord = words[0];

                foreach (string word in words)
                {
                    if (word.Length < shortestWord.Length)
                    {
                        shortestWord = word;
                    }
                    if (word.Length > longestWord.Length)
                    {
                        longestWord = word;
                    }
                }

                // Вивести результати
                label1Tab7.Text = $"Довжина найкоротшого слова: {shortestWord.Length}. Слово: {shortestWord}";
                label2Tab7.Text = $"Довжина найдовшого слова: {longestWord.Length}. Слово: {longestWord}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Виникла помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1Tab7_Click(object sender, EventArgs e)
        {

        }
    }
}
