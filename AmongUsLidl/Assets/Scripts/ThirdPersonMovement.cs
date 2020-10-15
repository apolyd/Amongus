using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public GameObject GroundChecker;
    public CharacterController controller;
    public Transform cam;
    public float speed = 2f;
    public float turnSmoothTIme = 0.1f;
    float turnSmoothVelocity;
    public float gravity = -14f, jumpForce = 6f;
    public Vector3 gravityApply;
    
    //float camCache = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal"); //Get input for the x axis
        float vertical = Input.GetAxisRaw("Vertical"); //Get input for the z axis
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //Get the new direction you are supposed to go and normalize it
        //***************************gravity/jump******************************
        if (gravityApply.y < gravity)
        {
            gravityApply.y = gravity;
        }

        if (GroundChecker.GetComponent<GroundCheck>().isGrounded == false)
        {
            gravityApply.y += gravity * Time.deltaTime;
        }
        else
        {
           
        }


        if (Input.GetKeyDown(KeyCode.Space) && GroundChecker.GetComponent<GroundCheck>().isGrounded == true)
        {
            gravityApply.y = jumpForce;
        }

        controller.Move(gravityApply * Time.deltaTime);

        //*****************************************************************

        if ( direction.magnitude >= 0.1f) //if there is movement detected
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // get the angle we need to move (the cam is to consider the camera angle too)
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTIme); // slowly turn to that angle
            transform.rotation = Quaternion.Euler(0f, angle, 0f); // calculate the Quaternion
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //calculate 1)the rotation 2)movement
            controller.Move(moveDir.normalized * speed * Time.deltaTime);// execute
           

        }
        else
        {
            
        }

        



    }

    


}
