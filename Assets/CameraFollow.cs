using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform rigidTransform;
    public Vector3 cameraOffset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = rigidTransform.position + cameraOffset;
        transform.LookAt(rigidTransform);
    }
}
