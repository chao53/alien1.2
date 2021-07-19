using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordXScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "enemy")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(5);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
