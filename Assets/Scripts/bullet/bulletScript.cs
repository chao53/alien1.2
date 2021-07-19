using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update  
    void Start()
    {
        Destroy(gameObject, 2.5f);  // 2.5sec
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(1);
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("player"))
        {
            if ((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > 9.6f
            || (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < -9.6f)
            {
                Destroy(gameObject);
            }
        }
        
    }
}
