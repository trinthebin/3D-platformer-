using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;


    float rotation = 0.0f;
    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    public float jumpForce = 300.0f;

    Rigidbody myRigidbody;
    GameObject cam;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera ");
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }


        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed)
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
    }
}
