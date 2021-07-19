using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background2Script : MonoBehaviour
{
    public Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0.67f * _Player.position.x + 25f, 0.425f * _Player.position.y + 3f, 10);
    }
}
