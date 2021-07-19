using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footballscript : MonoBehaviour
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
            if ((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < 0.9f
            && (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > -0.9f
            && (((gameObject.transform.position.y - GameObject.Find("player").transform.position.y) < 0.4f)
            && (gameObject.transform.position.y - GameObject.Find("player").transform.position.y) > -0.4f))
            {
                this.gameObject.transform.Translate(10 * Vector3.right * Time.deltaTime);
            }
        }
    }
}
