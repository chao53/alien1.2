using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background5Script : MonoBehaviour
{
    public Transform _Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0.76f * _Player.position.x + 8.5f, 0.425f * _Player.position.y + 0.3f, 10);
    }
}
