using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroud3 : MonoBehaviour
{
    public Transform _Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(0.825f * _Player.position.x + 6.5f, 0.4f * _Player.position.y + 4, 10);
    }
}
