using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RollerBall.Extensions;

namespace RollerBall.Collections
{
    public struct TypicalObject // Класс для объекта обобщённого списка
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public TypicalObject(string name, int id)
        {
            Id = id;
            Name = name;
        }
    }


    public class ListCount : MonoBehaviour
    {
        private List<int> intList = new List<int>();
        private List<TypicalObject> listObj = new List<TypicalObject>();
        private string[] names = { "Петя", "Вася", "Жора", "Даша", "Отвёртка", "Скрипач",
            "Барабан", "Долото", "Пипидастр","Анигиляторная пушка", "Овал",
            "Самолёт", "Пончик", "Бикукле", "Том Ям"}; // Имена для объекта TypicalObject

        private void Start()
        {

            for (int i = 0; i < Random.Range(10, 25); i++)// Создаём массив интов
            {
                intList.Add(Random.Range(0, 10));
            }
            print($"CountInt: {intList.IntElementCount(5)}");// Смотрим сколько пятёрок в созданном int массиве

            for (int i = 0; i < Random.Range(60, 125); i++)// Создаём обобщённый список с объектами TypicalObject
            {
                listObj.Add(new TypicalObject(names[Random.Range(0,names.Length)], Random.Range(0,5)) ); // Добавляем объект с рандомным именем и задаём ID
            }
            print($"CountObj: {listObj.CommonListElementCount(new TypicalObject("Пипидастр", 3))}"); //Ищем одинаковые объекты
            print($"CountObjLinq: {listObj.CommonListElementCount(new TypicalObject("Пипидастр", 3))}"); // То же самое, но с помощью Linq
        }
    }
    

}
