using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownersClass : MonoBehaviour
{

    public List<string> monsterClass = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        List();

        for (int i = 0; i < monsterClass.Count; i++)
        {
        
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
