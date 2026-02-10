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
    Rigidbody rb;
    [SerializeField] float playerSpeed = 3f;
    Vector3 camForward;
    Vector3 camRight;
    [SerializeField] float jumpForce = 3;
    bool onGround = false;
    [SerializeField] float deccelerationSpeed = 3f;
    [SerializeField] float zipPower = 3f;
    Globals globals;
    bool swinging = false;
    KeyCode swingKey = KeyCode.Mouse1;

    GameObject gun;
    SpringJoint joint;
    GameObject hook;
    [SerializeField] float jointSpring = 4.5f;
    [SerializeField] float jointDamper = 7f;
    [SerializeField] float jointMassScale = 4.5f;
    [SerializeField] float swingPush = 3;
    [SerializeField] float swingSpeed = 3;
    LineRenderer lr;

    private void OnEnable()
    {
        playerInput = GetComponent<PlayerInput>();
        playerControls.Enable();
        lr = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        globals = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>();
        gun = GameObject.FindGameObjectWithTag("Gun");
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

        if (Input.GetKeyDown(swingKey) && globals.seeHook && swinging == false)
        {
            Debug.Log("WEEEEEE");
            Swinging();
        }
        if (Input.GetKeyUp(swingKey))
        {
            StopSwing();
        }
        else if (swinging)
        {
            gun.transform.LookAt(hook.transform);
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
    private void Swinging()
    {
        hook = globals.hookSeen;
        swinging = true;
        playerSpeed = playerSpeed * swingSpeed;
        joint = gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = hook.transform.position;

        float distanceFromPoint = Vector3.Distance(transform.position, hook.transform.position);

        joint.maxDistance = distanceFromPoint * 0.25f;
        joint.minDistance = distanceFromPoint * 0.8f;

        joint.spring = jointSpring;
        joint.damper = jointDamper;
        joint.massScale = jointMassScale;

        rb.linearVelocity = rb.linearVelocity * swingPush;

        lr.positionCount = 2;
        DrawRope(gun.transform.GetChild(0).GetChild(0).position, hook.transform.position);
    }
    private void StopSwing()
    {
        swinging = false;
        playerSpeed = playerSpeed / swingSpeed;
        Destroy(GetComponent<SpringJoint>());
        lr.positionCount = 0;
        gun.transform.rotation = new Quaternion(0, 0, 0, 0);
        
    }
    private void DrawRope(Vector3 start, Vector3 stop)
    {
        lr.SetPosition(0, start);
        lr.SetPosition(1, stop);
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