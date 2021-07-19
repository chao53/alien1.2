using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleBDam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "player")
        {
            col.gameObject.GetComponent<HpScript>().Hurt(2);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
