using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.25f);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
