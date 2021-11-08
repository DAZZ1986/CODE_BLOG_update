﻿using System;

namespace CODE_BLOG__23_Анонимные_типы__Anonymous_Type__и_кортежи__ValueTuple_и_Tuple_
{
    class Program
    {
        static void Main(string[] args)
        {
            // Анонимные типы (Anonymous Type) и кортежи (ValueTuple и Tuple) в C# - Учим Шарп #23
            /*
            Анонимные типы - это синтаксический сахар, который позволяет нам создавать объекты определенного типа, но без указания 
            конкретного класса который будет использован, но на самом деле класс будет создан. Относится CODE_BLOG негативно, тк они очень
            сильно урезаны, но при этом они привносят большую вероятность ошибок. Но иногда их можно использовать, чаще всего они яляются
            локальными контейнерами в которые можно положить данные в строгом формате, но не позволяют полноценно ими манипулировать.
            Основная особенность у анонимных типов, что мы не можем изменять значения свойств, тоесть когда мы определяем анонимный тип, 
            мы сразу же задаем свойства и эти свойства являются доступными только для чтения. Это применимо когда нам нужно быстро получить
            какие то данные и положить их на какое то время, и мы не хотим создавать для этого отдельный класс.
            Для объявлния анонимных типов используется ключевое слово var. В анонимном типе методы задать не получится, это просто контейнер
            для хранения данных.

            Кортежи - позволяют нам задавать своеобразные коллекции элементов либо одного типа, либо различных типов. Если у нас есть массив,
            то он может включать в себя данные только одного типа, а кортежи нам позволяют в сокращенной форме создавать наборы данных 
            различных типов. Мы их можем и передовать в методы и возвращать их из методов. Вообще они были придуманы для того, чтобы 
            секономить время если мы не хотим создавать отдельный класс. Лучше их вообще не использовать, а лучше создать отдельный класс.
            Это будет безопаснее и защищеннее от ошибок, но если решили создавать то необходимо понимать, существует 2 основных типа для
            кортежей: 1. Tuple, 2. ValueTuple.
            1. Tuple - позволяет создавать нам набор кортежей различного типа. Максимум мы можем указать 8 значений типов, тоесть 8 типов, 
            к примеру <int, string, double, bool, byte, float, decimal, sbyte>, тоесть это кортеж из 8 элементов. И эти значения в Tuple 
            защищены от записи.
            2. ValueTuple - его стоит использовать когда из метода нужно вернуть более одного значения переменной и при этом их чисто 
            получить, сразу разобрать и далее никак не использовать.


            Принципиальные отличия Tuple от ValueTuple: 
            1. Tuple это ссылочный тип, а ValueTuple это значимый тип, тоесть ссылочный тип будет храниться в Куче, а значимый тип будет 
            храниться в Стеке. Стек как правило на 6 мегабай и доступ к значимым типам осуществляется намного быстрее, но они забивают 
            Стек, а ссылочные типы которые в Куче они хранятся в оперативной памяти, а в Стеке хранится ссылка на их адрес в памяти в Куче.
            Для Tuple и ValueTuple мы не можем задавать методы для них.

            2. Преимущество ValueTuple перед Tuple - мы можем задавать имена нашим значения, в то время как у обычного Tuple есть 
            только стандартные имена Item1, Item2 и до Item8. У ValueTuple значения можно изменять, а у Tuple значения доступны только для
            чтения. 
            */


            Console.WriteLine("||||||| Анонимный тип - создаем без указания класса");
            // создаем анонимный тип без указания класса для хранения данных, зачастую временно - для этого нам нужно ключевое слово var
            var product = new 
            {
                Name = "Milk",
                Energy = 100
            };
            //product.Energy = 55;  // тут будет ошибка тк один раз указав свойство, то далее мы не можем его поменять. Это защита от
            //замены данных, и доступ только для чтения.
            Console.WriteLine(product); // тут нам вывели прям набор параметров как есть)
            Console.WriteLine(product.Energy);
            Console.WriteLine(product.Name);



            Console.WriteLine("|||||||ДАЛЕЕ еще одна особенность анонимных типов");
            // ДАЛЕЕ еще одна особенность анонимных типов - мы можем задавать свойства анонимного типа не только как в первом варианте выше,
            // но и в другом формате. Создали промежуточный класс Eat. Бывает так что нам приходит коллекция еды из класса Eat каким либо
            // магическим образом и мы знаем энерг. ценность этой еды и хотим сделать список продуктов. Тоесть мы хотим объеденить коллекцию
            // еды с какими то конкретными значениями, енерг. ценность к примеру. Но при этом мы не хотим делать отдельный класс, но хотим
            // сделать строгое соответствие, чтобы это не выглядело как Словарь к примеру, а как одна общая структура, для этого мы создаем
            // объект класса еда.
            var eat = new Eat() // тут мы создали объект класса еда
            {
                Name = "Meat"
            };

            var product2 = new  // объявляем наш продукт
            {
                eat.Name,   // и прямо суда можем передать одно из свойст объекта eat от класса еда, и как мы видим мы тут не задаем
                            // конкретное имя для этого свойства, но оно будет подставлено суда. Это равносильно записи Name = eat.Name.
                Energy = 200
            };
            Console.WriteLine(product2);
            Console.WriteLine(product2.Energy); // тут просто собственное свойство Energy у product2
            Console.WriteLine(product2.Name);   // вот тут видим что теперь у product2 есть свое свойство Name









            Console.WriteLine("|||||||ДАЛЕЕ Кортежи - 1. Tuple,  2. ValueTuple.");
            // ДАЛЕЕ Кортежи - 1. Tuple,  2. ValueTuple.

            // 1. Tuple
            Console.WriteLine("|||||||tuple это - Tuple");
            Tuple<int, string> tuple = new Tuple<int, string>(5, "Hello");   // объявили Tuple
            // tuple.Item1 = 55;  // тут ошибка, тк данные read only, тк у Tuple значения доступны только для чтения.
            Console.WriteLine(tuple.Item1); // выводим на консоль
            Console.WriteLine(tuple.Item2);



            // 2. ValueTuple
            Console.WriteLine("|||||||tuple2 - другой формат объявления через var и это - ValueTuple");
            var tuple2 = (45, "Hello World");   // объявили ValueTuple
            Console.WriteLine(tuple2.Item1);    // выводим на консоль
            Console.WriteLine(tuple2.Item2);

            // ValueTuple - задаем имена значениям в кортеже.
            var tuple3 = (Name: "Tomato", Energy: 20);
            Console.WriteLine(tuple3.Name);
            Console.WriteLine(tuple3.Name);
            Console.WriteLine(tuple3.Energy);
            tuple3.Energy = 60; // и тут мы еще можем изменить значение в кортеже, тк ValueTuple значения можно изменять







            Console.WriteLine("||||||| Пример использования ValueTuple (возврат из метода нескольких значений)");
            // Пример когда можно использовать кортеж, создаем метод GetData() и из метода возвращаем несколько значений
            var result = GetData(); // это ValueTuple
            Console.WriteLine(result.Number);   // выводим на консоль
            Console.WriteLine(result.Name);
            Console.WriteLine(result.Flag);


        }



        public static (int Number, string Name, bool Flag) GetData() // из метода возвращаем несколько значений
        {
            var number = 7821;  // тут условно данные получаем из БД
            var name = Guid.NewGuid().ToString();  //  тут условно данные получаем из БД
            bool b = number > 500;  // проверка условия

            return (number, name, b);
        }







    }
}
