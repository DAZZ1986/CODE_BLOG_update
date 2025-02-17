﻿using System;

namespace CODE_BLOG__30_Небезопасный_код__unsafe_code__и_указатели
{
    class Program
    {
        static void Main(string[] args)
        {
            // Небезопасный код (unsafe code) и указатели в C# - Учим Шарп #30
            /*
            Работа с указателями является не безопасным кодом. Для его использования необходимо разрешение от разработчика и в целом это не
            используется повсеместно в .NET. Но при этом 50% языка C++ построено на указателях.
            Платформа .NET считает указатели не безопасным кодом, потому, что она берет на себя обязательство на обеспечение целостности,
            безопасности памяти и когда мы начинаем работать с памятью непосредственно, обращаясь к конкретным ячейкам памяти, возникает
            определенная степень опасности, что могут возникнуть утечки памяти, мы можем залесть в другой участок памяти и что то поменять.
            .NET разработчики решили их оставить, но использовать этот инструмент нужно с умом. Было создано специальное ограничение, для 
            того чтобы новичек случайно не написал unsafe code, ограничение требовало - нужно скомпилировать приложение со специальным
            ключом unsafe. Если мы будем использовать ключ в VS, то нужно поставить специальную галочку в свойствах проекта и после этого
            мы можем помечать определенные участки кода, методы, структуры итд как не безопасные(тоесть использовать указатели). В других
            участках кода, даже при том, что мы использовали при компиляции специальный ключ unsafe, мы не сможем работать с указателями.
            Тоесть, использовать указатели сможем только в явно выделенных разработчиком участках кода. Это опред. ответственность, которая
            ложится на разработчика. CLR не следит за unsafe кодом.

            Память - это опред. явчейка в которой хранится набор 0 и 1 и укаждой ячейки памяти есть свой адрес, 1 байт = 8 битам, так вот 
            этот байт имеет определенный адрес в памяти. Когда у нас определяется переменная, по сути мы резирвируем участок в памяти и
            даем ему имя например int i, где i является именем и данное имя хранит в себе указатель на первую ячейку в памяти, а тип 
            определяет кол-во ячеек, сколько нужно занять.
            Тип переменной для участка памяти влияет на интерпритацию данного уч. памяти, тоесть мы можем положить и int и 
            char и в ячейках будут, что так, что так 0 и 1. Вопрос только в том, как будут интерпритироваться эти 0 и 1, как целочисленное
            число или как символ. 
            Н/П:
            int i = 5;  //опредлелили и инициализировали переменную
            int* j;     //определили указатель - тоесть тип переменной j - это указатель.  Это int* - тип указатель!
            j = &i;     //присвоили переменной j, не значение переменной i, а адрес в памяти где хранится значение переменной i. Там по 
                        //итогу может храниться любое значение, а адрес будет всегда один.  (символ & - вытаскивает адрес переменной)

            Указатели - это адрес определенной ячейки в памяти. Чем они полезны - к примеру мы не хотим передовать копию, когда работаем
            со значимыми переменными, когда к примеру передаем ее в метод. Но если нам нужно передать ссылку, мы можем воспользоваться
            указателями. Но так же мы можем это все избежать передав в метод переменную по ссылке ref. Однако для совместимости между 
            другими языками .NET мы и используем указатели.

            unsafe - мы можем применить: 
            1) к опред. участку кода unsafe {}, 
            2) либо к методу - unsafe private static void PointerMethod() {}, 
            3) либо ко всей структуре - unsafe struct State { }
            Для начала нужно понимать, что классы являются ссылочным типом, и они и так передаются по ссылке, поэтому для классов unsafe
            использовать не совсем правильно. А вот для значимых переменных и возникает необходимость работать с указателями.

            Адреса памяти в 32-битной ОС могут поместиться в int, в 64-битной системе нужно ипользовать long или ulong.
            */

            unsafe
            {
                Console.WriteLine("|||||||| unsafe для переменной");
                int i = 30;
                int* address = &i;  //создаем указатель и кладем в него адресс в памяти переменной i. Когда мы создаем указатель, мы даем
                                    //имя для опред. участка в памяти.
                Console.WriteLine(*address);  //обращаемся к нашему указателю. Когда при обращении используем * - эта операция называется
                                              //разименование. ТУТ мы получаем значение.
                Console.WriteLine((long)address); //теперь чтобы получить непосредственно адресc первой ячейки в памяти это переменной, нам
                                                  //нужно привести указатель к стандартному типу, н/п: к long. ТУТ мы получаем адресс.



                Console.WriteLine("|||||||| unsafe для метода");
                int a = 5;
                int b = 7;
                Calc(a, &b);    //в "a", передали значение; в "b", передали адресс;
                Console.WriteLine(a); //вывод 5, тк "а" НЕ изменилось, потому что в метод попала копия
                Console.WriteLine(b); //вывод 700, тк "b" изменилось, потому что в метод мы передали адресс переменной "b".
                
                Console.WriteLine("|||||||| тут сделали через ref, чтобы код был безопасный");
                Calc2(a, ref b);    //в "a", передали значение; в "b", передали адресс;
                Console.WriteLine(a); //вывод 5, тк "а" НЕ изменилось, потому что в метод попала копия
                Console.WriteLine(b); //вывод 700, тк "b" изменилось, потому что в метод мы передали адресс переменной "b".





                Console.WriteLine("|||||||| переход в другой участок памяти");
                Console.WriteLine(*address);  //в этом указателе лежит значение 30.
                int* address2 = address + 4;     //смещаем адресс, прибавив 4, тк int 4 байта, тоесть сместили на 1 ячейку.
                Console.WriteLine(*address2); //теперь тут после смещения указателя лежит непонятное число. В этом и опасность, что мы можем
                                              //в памяти перезаписать в памяти любое какое либо значение от какой то переменной и тем самым
                                              //поломаем какие либо данные и приложение будет работать криво.
                *address2 = 777;              //записали по данному адресу новое значение.
                Console.WriteLine(*address2);    //вывели новое записанное значение.





                Console.WriteLine("|||||||| получаем указатель на другой указатель");
                // Сам по себе адресс тоже хранится в памяти и мы можем получить ссылку адрес в памяти где хранится адрес в памяти.
                // Чтобы получить указатель на указатель, нужно использовать два знака разыменования "**".
                int** adr = &address; //тут мы создали переменную "adr" и положили в нее не значение, а адресс, который в себе содержал
                                      //указатель "address".
                Console.WriteLine((long)adr);  //тут выводим адрес первого указателя adr.
                Console.WriteLine((long)*adr); //тут выводим адрес второго указателя address, из-за вложенности нужно писать так (long)*adr,
                                               //с использованием оператора разыменовывания "*".
                Console.WriteLine(**adr);      //тут выводим значение второго указателя.





            }

        }


        static unsafe void Calc(int i, int* j) // не безопасный код
        {
            i = 500;
            *j = 700;
        }
        static void Calc2(int i, ref int j) // эквивалентный безопасный код, тк за управление этим процессом будет следить CLR, и меньше
                                            // вероятность возникновения утечки памяти или что мы попадем в другой участок памяти.
        {
            i = 500;
            j = 700;
        }

    }
}
