using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipScript : MonoBehaviour
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
            if (((gameObject.transform.position.x - GameObject.Find("player").transform.position.x) < 2.1f
            && (gameObject.transform.position.x - GameObject.Find("player").transform.position.x) > -2.1f)
            && ((gameObject.transform.position.y - GameObject.Find("player").transform.position.y) < 3
            && (gameObject.transform.position.y - GameObject.Find("player").transform.position.y) > -3))
            {
                if (GameObject.Find("player").GetComponent<playerScript>().ReturnPicking() == 1)
                {
                    SceneManager.LoadScene("5");
                }
            }
        }
    }
}
