﻿using System;

namespace CODE_BLOG__8._2__OOP_
{
    public class Person
    {
        /* Модификаторы доступа:
        public    - доступно всем и везде для любого класса.
        internal  - открытый в пределах данного проекта.
        protected - доступ только внутри данного класса и его наследников. (по родственным связям)
        private   - доступ только конкретно этому классу, не наследникам и никому другому.
        */

        public string firstName;    // есть модификатор изменим на protected или private, то в методе мэйн будет ошибка, тк не будет
        public string lastName;     // доступа из вне.

        // наследование
        protected decimal money;    // эта переменная будет доступна только внутри данного класса, тоесть если данный класс унаследует
                                    // другой класс, например Doctor, то экземпляры класса Doctor уже не увидят переменную money.


    }
}
