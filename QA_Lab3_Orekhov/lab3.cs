using System;

/**
 
@mainpage Документация по проекту Flat
<img src="E:\stp\LAB3\LAB3\logo.jpg" alt="">
# Описание
Программа моделирует квартиру с двумя комнатами и осуществляет расчет площади, приходящейся на одного человека, а также определяет минимальную площадь среди комнат.
# Классы
@par Room — комната
@par roomdetail- производный от Room. Добавляет информацию о количестве взрослых и детей в комнате 
@par Flat — квартира
# Автор
Матвей О, 2025
*/
namespace stp_lab6
{
    /**
     \brief Класс для описания комнаты.
     Этот класс используется для хранения информации о комнате, включая площадь и количество 
    */
    public class room 
    {
        protected double S;
        protected int people;

        /**
         \brief Ввод для класса Room.
         \param S Площадь комнаты.
         \param m Количество людей в комнате.
        */
        public void Init(double s, int m)
        {
            S = s;
            people = m;
        }

        /**
            \brief Возвращает площадь на одного человека.
        
            \return Площадь, приходящаяся на одного человека.  \f$ \text{Square for one person} = \frac{S}{\text{people}} \f$ 
        */
        public double square_for_one_people()
        {
            return S / people;
        }

        /**
         \brief Отображает информацию о комнате.
         \details Этот метод выводит площадь комнаты и количество людей в ней.
        */
        public void Display()
        {
            string s1, s2;
            s1 = Convert.ToString(S);
            s2 = Convert.ToString(people);
            Console.WriteLine("square = " + s1 + " number of people = " + s2);
        }

        /**
         \brief Читает данные о комнате из ввода.
         \details Этот метод считывает площадь и количество людей из стандартного ввода.
        */
        public void Read()
        {
            string s = "";
            s = Console.ReadLine();
            string[] s1;
            s1 = s.Split(new char[] { ' ', '\t' },
            StringSplitOptions.RemoveEmptyEntries);
            S = Convert.ToInt32(s1[0]);
            people = Convert.ToInt32(s1[1]);
        }
    }

    /**
     \brief Класс для описания деталей комнаты, наследует класс Room.
     Этот класс добавляет информацию о количестве взрослых и детей в комнате.
    */
    public class roomdetail : room
    {
        private int adults;
        private int child;

        /**
         \brief Инициализация данных для класса RoomDetail.
         \param m Площадь комнаты.
         \param s Количество людей в комнате.
         \param v Количество взрослых.
         \param c Количество детей.
        */
        public void Init(double m, int s, int v, int c)
        {
            base.Init(m, s);
            adults = v;
            child = c;
        }

        /**
         \brief Возвращает площадь на одного человека, учитывая взрослых и детей.
         \return Площадь, приходящаяся на одного человека.  \f$ \text{Square for one person} = \frac{S}{\text{adults} + 2 \cdot \text{children}} \f$ 
        */
        public new double square_for_one_people()
        {
            return S / (adults + 2 * child);
        }

    }

    /**
     \brief Класс для описания квартиры.
     Этот класс хранит информацию о квартире, включая общую площадь и комнаты.
    */
    public class flat
    {
        private String Fam;
        private double total_area;
        public room FirstClass = new room();
        public roomdetail SecondClass = new roomdetail();

        /**
         \brief Инициализация данных для класса Flat.
         \param f Фамилия владельца квартиры.
         \param v Общая площадь квартиры.
         \param m1 Площадь первой комнаты.
         \param s1 Количество людей в первой комнате.
         \param m2 Площадь второй комнаты.
         \param s2 Количество людей во второй комнате.
         \param v2 Количество взрослых во второй комнате.
         \param c2 Количество детей во второй комнате.
        */
        public void Init(String f, double v, double m1, int s1, double m2, int s2, int v2, int c2)
        {
            Fam = f;
            total_area = v;
            FirstClass.Init(m1, s1);
            SecondClass.Init(m2, s2, v2, c2);
        }

        /**
         \brief Вычисляет общую площадь на одного человека для всех комнат.
         \return Общая площадь на одного человека.
         \code
                public double squareAll()
                {
                    double t1;
                    t1 = FirstClass.square_for_one_people();
                    t1 += SecondClass.square_for_one_people();
                    t1 += total_area;
                    return t1;
                }
          \endcode
        */

        public double squareAll() //Метод вычисляет среднюю площаддь на человека по 2 комнатам
        {
            double t1;
            t1 = FirstClass.square_for_one_people();
            t1 += SecondClass.square_for_one_people();
            t1 += total_area;
            return t1;
        }

        /**
         \brief Находит комнату с минимальной площадью на человека.
         \return Комната с наименьшей площадью на человека.
         \code
                public room minn()
                        {
                            double t1, t2, t3;
                            t1 = FirstClass.square_for_one_people() + total_area;
                            t2 = SecondClass.square_for_one_people() + total_area;
                            if (t1 < t2) { t3 = t1; }
                            else { t3 = t2; }
                            if (t1 == t3) { return FirstClass; }
                            if (t2 == t3) { return SecondClass; }
                            return null;
                        }
           \endcode
        */
        public room minn()
        {
            double t1, t2, t3;
            t1 = FirstClass.square_for_one_people() + total_area;
            t2 = SecondClass.square_for_one_people() + total_area;
            if (t1 < t2) { t3 = t1; }
            else { t3 = t2; }
            if (t1 == t3) { return FirstClass; }
            if (t2 == t3) { return SecondClass; }
            return null;
        }

        /**
         \brief Читает данные о квартире и комнатах из ввода.
         \details Этот метод считывает площадь и количество людей из стандартного ввода.
        */
        public void Read() 
        {
            double m1; int s1; double m2; int s2; int s0; int s3;
            Fam = Console.ReadLine();
            Console.WriteLine("square everyone=");
            total_area = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("square1=");
            m1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("number of people1= ");
            s1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("square2=");
            m2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("number of people2= ");
            s0 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("number of adults=");
            s2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("number of children's= ");
            s3 = Convert.ToInt32(Console.ReadLine());
            FirstClass.Init(m1, s1);
            SecondClass.Init(m2, s0, s2, s3);
        }

        /**
         \brief Отображает информацию о квартире и комнатах.
         \return Этот метод выводит общую площадь квартиры и информацию о комнатах.
        */
        public void Display()
        {
            Console.WriteLine(Fam);
            Console.WriteLine(total_area);
            FirstClass.Display();
            SecondClass.Display();
        }

        /**
         \brief Получает фамилию владельца квартиры.
         \return Fam Фамилия владельца.
        */
        public string Getname()
        {
            return Fam;
        }

        /**
         \brief Задаёт фамилию владельца квартиры.
         \param fam Фамилия владельца
        */
        public void Putname(string fam)
        {
            Fam = fam;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            double m;
            flat c = new flat();
            c.Init("Ivanovs", 20, 8, 2, 18, 3, 2, 1);
            m = c.squareAll();
            Console.WriteLine(m);
            Console.ReadLine();
        }
    }
}
