using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMoment : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumForce;
    public Vector2 inputVector;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(inputVector.x * speed, 0f, inputVector.y * speed), ForceMode.Impulse);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumForce, ForceMode.Impulse);
        }
        
    }
}
