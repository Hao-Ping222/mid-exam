using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    public Transform target;
    Transform _Transform;
    public float xOffset = 1.8f;

    void Start()
    {
        _Transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 followPos = new Vector3(target.position.x + xOffset,_Transform.position.y, _Transform.position.z);
        _Transform.position = followPos;
    }
}
