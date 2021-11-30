using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed;
    public float normalSpeed = 10.0f;
    public float sprintSpeed = 20.0f;


    float rotation = 0.0f;
    public float camRotation = 0.0f;
    public float rotationSpeed = 2.0f;
    public float camRotationSpeed = 1.5f;
    public float jumpForce = 300.0f;

    Rigidbody myRigidbody;
    GameObject cam;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;

    public float maxSprint = 5.0f;
    float sprintTimer;

    Animator myAnim;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        cam = GameObject.Find("Main Camera ");
        myRigidbody = GetComponent<Rigidbody>();

        sprintTimer = maxSprint;
    }

    // Update is called once per frame
    void Update()
    {

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintSpeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        } else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

        

        camRotation = Mathf.Clamp(camRotation, -40.0f, 40.0f);

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
       

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);
        myAnim.SetFloat("speed", newVelocity.magnitude);
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));
    }
}
