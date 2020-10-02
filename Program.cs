using System;

namespace Функция
{
    class Program
    {
        static float Function_x3(float x)
        {
            float y = x*x*x;
            return (y);
        }

        static void Printing_X_Y(int max_lenght)  // построение сетки для x и y
        {
            string cell = '|' + new string('-', max_lenght);
            Console.WriteLine("\n"+cell+cell+"|");

            int left, right;               // высчитывание пробелов
            left = Counter_of_spaces(1, max_lenght, true);    //true и false передача в переменную l_or_r в следующем методе, left-true, right-false
            right = Counter_of_spaces(1, max_lenght, false);

            Console.WriteLine("|"+new string(' ',left) + 'x' + new string(' ',right)+ "|"
                                 +new string(' ', right) + 'y' + new string(' ', left) + "|"); // меняю left и right местами
                                                                                               // чтобы отзеркалить X и Y
            Console.WriteLine(new string('-',max_lenght*2+3));
        }
       

        static void Printing_Nums(float number1,float number2 , int max_lenght)  // построение строк в таблице со значениями x и y
        {
            int left1, right1, left2, right2;
            left1 = Counter_of_spaces(number1,max_lenght,true);    // true - значит нужно высчитать пробелы слева, false - пробелы справа
            right1 = Counter_of_spaces(number1, max_lenght, false);
            left2 = Counter_of_spaces(number2, max_lenght, false); // меняем true и false местами, чтобы отзеркалить количество пробелов
            right2 = Counter_of_spaces(number2, max_lenght, true);

            Console.WriteLine("|"+ new string(' ',left1)+number1+ new string(' ', right1) + '|'
                                 + new string(' ', left2)+number2+ new string(' ', right2)+'|');
        }



        static int Counter_of_spaces(float number, int max_lenght, bool l_or_r)    // счётчик пробелов для отступа слева или справа
        {                                                            // l_or_r - слева или справа относительно центра таблицы
            int lenght_num = Convert.ToString(number).Length;
            if     (lenght_num % 2 == 0) if (max_lenght%2 == 0 || l_or_r) return (max_lenght-lenght_num)/2;
                                         else return ((max_lenght - lenght_num) / 2)+1;

            else                         if (max_lenght % 2 != 0 || l_or_r) return (max_lenght - lenght_num) / 2;
                                         else  return ((max_lenght - lenght_num )/ 2) + 1;
        }



        static void Main()
        { 
            Console.WriteLine("Добро пожаловать в программу для\nподсчёта значений функции y=x^3\n");

            bool check_parse;
            float step;
            do
            {
                Console.WriteLine("Введите шаг функции");
                check_parse = float.TryParse(Console.ReadLine(), out step);
            } while (check_parse == false || step<=0);

            float x1;
            do
            {
                Console.WriteLine("Введите крайнюю левую точку х");
                check_parse = float.TryParse(Console.ReadLine(), out x1);
            } 
            while (check_parse == false);

            float x2;
            do
            {
                Console.WriteLine("Введите крайнюю правую точку х");
                check_parse = float.TryParse(Console.ReadLine(), out x2);
            }
            while (check_parse == false || x1>x2);

            int num_of_steps = (int)((x2 - x1) / step);

            float[] array_Y = new float[num_of_steps+1]; // создание массива для записи значений Y

            int max_num_lenght = 1;

            for(int i=0; i<= num_of_steps;i++)
            {
                array_Y[i] = Function_x3(x1 + i * step);  // заполнение массива

                if (Convert.ToString(array_Y[i]).Length > max_num_lenght) max_num_lenght = Convert.ToString(array_Y[i]).Length;
                if (Convert.ToString(x1 + i * step).Length > max_num_lenght) max_num_lenght = Convert.ToString(x1 + i * step).Length;
            }                                           //нахождение наибольшего по кол-ву символов числа


            Printing_X_Y(max_num_lenght);

            for (int i = 0; i <= array_Y.Length - 1; i++)
                Printing_Nums(x1 + i * step, array_Y[i], max_num_lenght);

            Console.WriteLine(new string('-', max_num_lenght * 2 + 3)); 

            Console.ReadKey();
        }
    }
}
