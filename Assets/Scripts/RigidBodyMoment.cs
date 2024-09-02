using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RigidBodyMoment : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumpForce;
    public Vector2 inputVector;
    public Rigidbody rigdBody;
    public Vector3 Velocity;
    public float velocityMagnitude;
    public bool CanJump;

    public int collectedItems;


    void Start()
    {
        rigdBody = GetComponent<Rigidbody>();
        CanJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        rigdBody.AddForce(inputVector.x * speed, 0f, inputVector.y * speed, ForceMode.Impulse);

        Velocity = rigdBody.velocity;
        velocityMagnitude = Velocity.magnitude;



        if (Input.GetKeyDown(KeyCode.Space)&& CanJump)
        {
            rigdBody.AddForce(0f, jumpForce, 0f, ForceMode.Impulse);
            CanJump = false;
        }
        
    }
    private void OnCollisionEnter(Collision contraloQueChoque)
    {
        Debug.Log("choque contra: " + contraloQueChoque.gameObject.name);

        if (contraloQueChoque.gameObject.CompareTag("Ground"))
        {
            CanJump = true;
        }
        if (contraloQueChoque.gameObject.CompareTag("KillZone"))
        {
            Debug.Log("KILL MEEEE");

            SceneManager.LoadScene(1);
        }

        if (contraloQueChoque.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene(2);
        }

        if (contraloQueChoque.gameObject.CompareTag("Item"))
        {
            Destroy(contraloQueChoque.gameObject);
            collectedItems++;
        }

    
    }
}
