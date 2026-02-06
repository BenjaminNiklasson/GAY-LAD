using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    
    public InputAction playerControls;
    public Vector3 moveDirection;
    Rigidbody rb;
    [SerializeField] float playerSpeed = 3f;
    Vector3 camForward;
    Vector3 camRight;
    [SerializeField] float jumpForce = 3;
    bool onGround = false;
    [SerializeField] float deccelerationSpeed = 3f;
    [SerializeField] float zipPower = 3f;
    Globals globals;

    private void OnEnable()
    {
        playerControls.Enable();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        moveDirection = playerControls.ReadValue<Vector3>() * playerSpeed;
    }

    private void FixedUpdate()
    {
        camForward = GameObject.FindWithTag("MainCamera").transform.forward;
        camRight = GameObject.FindWithTag("MainCamera").transform.right;
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        moveDirection = (camRight * moveDirection.x + camForward * moveDirection.z) * playerSpeed;

        if (moveDirection != Vector3.zero)
        {
            rb.linearVelocity += moveDirection;
        }
        //rb.AddForce(moveDirection);

        
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            onGround = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            onGround = false;
        }
    }

    public void OnJump()
    {
        if (onGround == true)
        {
            rb.linearVelocity += (new Vector3(0, jumpForce, 0));
        }
    }

    public void OnZip()
    {
        
        if (globals.seeHook)
        {
            //ZIPPING!!!
            Vector3 direction = (globals.hookSeen.transform.position - transform.position).normalized;
            rb.linearVelocity += direction * zipPower;
        }
    }

    public void OnPause()
    {
       
        globals.PauseGame();
    }

   

}
