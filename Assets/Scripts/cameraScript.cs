using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform _Player;

    void Start()
    {

    }

    void LateUpdate()
    {
        transform.position = new Vector3(_Player.position.x, _Player.position.y + 1.5f, -10);
    }
}
