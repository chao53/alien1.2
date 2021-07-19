using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
