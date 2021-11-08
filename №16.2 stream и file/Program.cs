﻿using System;
using System.IO;
using System.Text;

namespace CODE_BLOG__16._2_stream_и_file
{
    class Program
    {
        static void Main(string[] args)
        {
            // Потоки (stream) и файлы (file) в C# - Учим Шарп #16
            // Для удобного взаимодействия с файлами был создан такой формат как stream (поток).
            // Как представить себе поток - есть бочка с данными и в ней проделали дырку и через эту дырку вытекают данные.

            // Кодировки - это способ кодирования символов.
            // Данные на ПК хранятся в двоичном формате, 1 и 0. В любом алфавите есть звук "А", но в разных алфавитах этот звук будет
            // обозначаться разными символами, так же и кодировки. Н/П: когда данные хранятся в одной кодировке, а мы пытаемся их
            // интерпритировать при помощи другой кодировки, то у нас получается не соответствие/кракозябры. Самая популярная UTF-8,
            // самая быстрая при обработке, ее рекомендует Майкрософт.


            // Запись
            using (var sw = new StreamWriter("test.txt", true , Encoding.UTF8)) // тут объявляем объект потока
            {
                // у объекта потока StreamWriter, ссылка на объект лежит в переменной sw
                sw.WriteLine("Hello, User");
                sw.WriteLine("Привет, User");
            }


            // Чтение
            using (var sr = new StreamReader("test.txt", Encoding.UTF8))
            {
                
                // Чтение построчное EndOfStream
                while (!sr.EndOfStream)  // чтение файла построчно EndOfStream
                {
                    Console.WriteLine(sr.ReadLine() + " - чтение построчное");   // ReadLine у нас прочитает только одну строчку из потока
                }


                //Если мы выполняем верхний и нижний код, тоесть построчное чтение и чтение всего файла, то у нас выполнится только верхний
                //код с построчным чтением, тк указатель чтения уже будет находиться в конце файла и его нужно переносить в начало командой
                //BaseStream.

                // Чтение всего файла ReadToEnd()
                sr.DiscardBufferedData();     // очищаем внутренний буфер
                sr.BaseStream.Seek(0, SeekOrigin.Begin); // тут мы обращаемся к основному потоку и у основного потока вызываем метод
                                                         // перехода в определенную позицию, тоесть переносим указатель в начало.
                string text = sr.ReadToEnd(); // чтение всего файла. Нюанс - когда мы второй раз вызываем команду на чтение всего файла
                                              // ReadToEnd (без обновления указателя на начало), она не отрабатывает, потому, что у нас
                                              // указатель на чтение уже стоит в самом конце файла, тк мы ранее делали построчное чтение.
                                              // Поэтому в переменную text ничего не попадет. Поэтому если мы хотим прочитать файл еще
                                              // раз, у класса StreamReader есть специальный метод sr.DiscardBufferedData(); и
                                              // BaseStream.Seek(0, SeekOrigin.Begin); которые перенесут указатель на начало файла.
                                              // А у класса FileStream.Seek есть метод Seek().
                Console.WriteLine(text);
                
            }







        }
    }
}
