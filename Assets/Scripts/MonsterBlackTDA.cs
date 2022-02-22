using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBlackTDA : MonoBehaviour
{
    public string type;
    public int lifebar;
    public int damage;
    public GameObject monsterblack;
    public List<GameObject> monsterBlackGO;

    // Start is called before the first frame update
    void Start()
    {
        monsterBlackGO = new List<GameObject>();
        for (int i=0; i < 1; i++)
        {
            monsterBlackGO.Add(monsterblack);
        }

        monsterBlackGO[0].GetComponent<MonsterBlackTDA>().type = "Drowner1";
        monsterBlackGO[0].GetComponent<MonsterBlackTDA>().lifebar = 100;
        monsterBlackGO[0].GetComponent<MonsterBlackTDA>().damage = 50;

        Debug.Log("Black Monster is a " + monsterBlackGO[0].GetComponent<MonsterBlackTDA>().type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
