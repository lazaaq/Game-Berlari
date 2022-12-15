using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3(target.position.x+7, 0, this.transform.position.z);
    }
}
