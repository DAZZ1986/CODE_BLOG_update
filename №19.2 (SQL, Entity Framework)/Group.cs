﻿using System;
using System.Collections.Generic;

namespace CODE_BLOG__19._2__SQL__Entity_Framework_
{
    public class Group
    {
        // Создали модель для данного класса
        public int Id { get; set; }
        public string Name { get; set; } // в БД имя может быть nullable, и тк это стринг у него по умолчанию значение null, в отличии от
                                         // int, и поэтому знак ? тут не нужен перед типом переменной.
        public int? Year { get; set; }   // в БД год может быть nullable, а у int по умолчанию выставляется 0, поэтому ставим знак ?,
                                         // и теперь в int может быть null.


        // Делаем по сути связи 2 таблиц Group-Id, Song-GroupId (связь между колонками Id и GroupId)
        // ключевое слово virtual означает что метод может быть переопределен.
        public virtual ICollection<Song> Songs { get; set; }  // в этом свойстве у каждой группы будет храниться коллекция всех ее песен, и
                                                              // таким образом у нас сразу будут присоеденины все песни которые относятся
                                                              // к каждой конкретной группе.

        public string Type { get; set; }    // тут мы добавили в нашем коде НОВОЕ поле в таблицу в БД, тоесть теперь нужно обновить
                                            // структуру БД. 

    }
}
