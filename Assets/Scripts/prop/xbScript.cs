using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xbScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player"))
        {
            if (((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < 1
            && (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > -1)
            && ((gameObject.transform.position.y - GameObject.Find("player").transform.position.y) < 1
            && (gameObject.transform.position.y - GameObject.Find("player").transform.position.y) > -1))
            {
                if (GameObject.Find("player").GetComponent<playerScript>().ReturnPicking() == 1)
                {
                    GameObject.Find("player").GetComponent<playerScript>().drinkXb(7);
                    GameObject.Find("player").GetComponent<HpScript>().xb(7);
                    Destroy(gameObject);
                }
            }
        }
        
    }
}
