using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RollerBall.Extensions;

namespace RollerBall.Collections
{
    public struct TypicalObject // Common class
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
            "Самолёт", "Пончик", "Бикукле", "Том Ям"}; // Names for TypicalObject class

        private void Start()
        {

            for (int i = 0; i < Random.Range(10, 25); i++)// Creating of int array
            {
                intList.Add(Random.Range(0, 10));
            }
            print($"CountInt: {intList.IntElementCount(5)}");// search for 5 in int array

            for (int i = 0; i < Random.Range(60, 125); i++)// Creating commont array of TypicalObjects
            {
                listObj.Add(new TypicalObject(names[Random.Range(0,names.Length)], Random.Range(0,5)) ); // creating random object with random ID
            }
            print($"CountObj: {listObj.CommonListElementCount(new TypicalObject("Пипидастр", 3))}"); // looking for similar objects
            print($"CountObjLinq: {listObj.CommonListElementCount(new TypicalObject("Пипидастр", 3))}"); // looking for similar objects with Linq
        }
    }
    

}
