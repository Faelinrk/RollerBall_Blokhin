using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RollerBall.Extensions;

namespace RollerBall.Collections
{
    public struct TypicalObject // ����� ��� ������� ����������� ������
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
        private string[] names = { "����", "����", "����", "����", "�������", "�������",
            "�������", "������", "���������","������������� �����", "����",
            "������", "������", "�������", "��� ��"}; // ����� ��� ������� TypicalObject

        private void Start()
        {

            for (int i = 0; i < Random.Range(10, 25); i++)// ������ ������ �����
            {
                intList.Add(Random.Range(0, 10));
            }
            print($"CountInt: {intList.IntElementCount(5)}");// ������� ������� ������ � ��������� int �������

            for (int i = 0; i < Random.Range(60, 125); i++)// ������ ���������� ������ � ��������� TypicalObject
            {
                listObj.Add(new TypicalObject(names[Random.Range(0,names.Length)], Random.Range(0,5)) ); // ��������� ������ � ��������� ������ � ����� ID
            }
            print($"CountObj: {listObj.CommonListElementCount(new TypicalObject("���������", 3))}"); //���� ���������� �������
            print($"CountObjLinq: {listObj.CommonListElementCount(new TypicalObject("���������", 3))}"); // �� �� �����, �� � ������� Linq
        }
    }
    

}
