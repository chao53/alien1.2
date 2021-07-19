using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyScript : MonoBehaviour
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
                    GameObject.Find("switch3").transform.Translate(100 * Vector3.left);
                    Destroy(gameObject);
                }
            }
        }
    }
}
