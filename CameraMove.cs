using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    Transform PlayerBallTransform;
    Vector3 Offset;

    void Awake()
    {
        PlayerBallTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - PlayerBallTransform.position;
    }

    void LateUpdate()
    {
        transform.position = PlayerBallTransform.position + Offset;
    }
}
