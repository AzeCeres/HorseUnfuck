using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public SceneController sceneController;
    
    private Camera cam;
    [SerializeField] private float moveSpeed = 5f;
    private float movementMultiplier = 10f;

    [SerializeField] private float runMultiplier = 2f;
    
    private Rigidbody rb;
    private float drag = 5.5f;
    private Vector3 moveDirection;

    private bool canDie = false;

    //public GameObject beam;
    
    [SerializeField] private float fov = 60;
    private float runFOV = 10;
    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
        rb = GetComponent<Rigidbody>();
    }
    private void Start() {
        rb.freezeRotation = true;
        cam.fieldOfView = fov;
        canDie = false;

    }
    private void FixedUpdate()
    {
        Drag();
        Move(new Vector2(0,1), false);
        SpawnObjects();
        if (rb.velocity.magnitude > 0.2)
        {
            canDie = true;
        }
        if (rb.velocity.magnitude <= 0.1 && canDie)
        {
            print("Game over");
            sceneController.GameOver();
            //sceneController.gameOver = true;
        }
    }
    void Drag()
    {
        Vector3 velocity = transform.InverseTransformDirection(rb.velocity);
        float forceX = -drag * velocity.x;
        float forceZ = -drag * velocity.z;
        
        rb.AddRelativeForce(new Vector3(forceX, 0, forceZ));
    }
    public void Move(Vector2 moveVector, bool run)
    {
        moveDirection = transform.forward * moveVector.y + transform.right * moveVector.x;
        if (run)
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed * movementMultiplier * runMultiplier), ForceMode.Acceleration);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov + runFOV, 0.1f);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * (moveSpeed * movementMultiplier), ForceMode.Acceleration);
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, fov, 0.1f);
        }
        
        
    }

    public void SpawnObjects()
    {
        //print(rb.velocity.magnitude);
        
    }
}
