using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2Script : MonoBehaviour
{

    //public string shooter;

    void Start()
    {
        Destroy(gameObject, 1);  // 1sec
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "sword")
        {
            GameObject.Find("player").GetComponent<HpScript>().Heal(1);
            GameObject.Find("player").GetComponent<duangScript>().Duang(1);
        }
        if(col.name == "sword1")
        {
            GameObject.Find("player").GetComponent<HpScript>().Heal(1);
            GameObject.Find("player").GetComponent<duangScript>().Duang(-1);
        }
        if (col.name == "player")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(1);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
