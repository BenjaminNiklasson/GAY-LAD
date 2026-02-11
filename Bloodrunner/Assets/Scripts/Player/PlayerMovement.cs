using System;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{

    public InputAction playerControls;
    PlayerInput playerInput;
    public Vector3 moveDirection;
    public Rigidbody rb { get; set; }
    [SerializeField] public float playerSpeed { get; set; } = 0.5f;
    Vector3 camForward;
    Vector3 camRight;
    [SerializeField] float jumpForce = 3;
    bool onGround = false;
    [SerializeField] float zipPower = 3f;
    Globals globals;
    public bool swinging { get; set; } = false;
    KeyCode swingKey = KeyCode.Mouse1;
    GameObject gun;

    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControls.Enable();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        gun = GameObject.FindGameObjectWithTag("Gun");
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    void Update()
    {
        // Get input
        moveDirection = playerControls.ReadValue<Vector3>() * playerSpeed;

        //Swing
        if (Input.GetKeyDown(swingKey) && globals.seeHook && swinging == false)
        {
            Debug.Log("WEEEEEE");
            globals.Swinging();
        }
        if (Input.GetKeyUp(swingKey) && swinging)
        {
            globals.StopSwing();
        }
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
        
        if (swinging)
        {
            gun.transform.LookAt(globals.hook.transform);
        }
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
            rb.linearVelocity = Vector3.zero;
            Vector3 direction = (globals.hookSeen.transform.position - transform.position).normalized;
            rb.linearVelocity += direction * zipPower;
        }
    }

    public void OnReset()
    {
        globals.PlayerDeathGlobal();
    }

    public void OnExplosive()
    {

    }

    //UI
    public void OnPause()
    {
        globals.PauseGame();
    }
    public void BackToMainMenu()
   {
       globals.BackToMainMenu();
   }

}