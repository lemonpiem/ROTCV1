using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterClass : MonoBehaviour
{

    public List<string> monsterClass = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        List();

        for (int i = 0; i < monsterClass.Count; i++)
        {
            Debug.Log("The monster on position " + i + " is " + monsterClass[i]);
        }

    } 

    void List()
    {
        monsterClass.Add("Drowner_1");
        monsterClass.Add("Drowner_2");
        monsterClass.Add("Drowner_3");

    }

    void Dictionary()
    {
        Dictionary<int, string> monsters = new Dictionary<int, string>();

        monsters.Add(1, "Drowner_1");
        monsters.Add(2, "Drowner_2");
        monsters.Add(3, "Drowner_3");

    }
    

}
