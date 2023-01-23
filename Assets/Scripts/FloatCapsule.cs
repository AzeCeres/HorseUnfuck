using UnityEngine;

public class FloatCapsule : MonoBehaviour
{
    private Rigidbody rb;
    
    [Header("RayCast")]
    [SerializeField] private float rayLenght = 1f;
    [SerializeField] private LayerMask groundLayer;
    
    [Header("Levitating")]
    [SerializeField] private float rideHeight = 0.1f;
    [SerializeField] private float rideSpringDampner = 10f;
    [SerializeField] private float rideSpringStrenght = 5f;

    [Header("Gravity")]
    [SerializeField] private float extraGravity = 20f;

    private float springForce;
    
    [Header("Ground Check")]
    public bool grounded = true;

    [Header("Coyote Time")]
    public bool coyoteTime = true;
    [SerializeField] private float coyoteDelay = 0.2f;
    private  float coyoteTimer;
    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        rayLenght = rayLenght + 1;
        rideHeight = rideHeight + 1;
    }
    private void Update()
    {
        CoyoteTime();
    }
    private void FixedUpdate()
    {
        GroundCast();
        FakeGravity();
    }
    private void GroundCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, rayLenght, groundLayer)){
            float groundedDistanceLeniency = -0.45f;
            if (hit.distance <= rideHeight + groundedDistanceLeniency)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
            
            Vector3 vel = rb.velocity;
            Vector3 rayDir = transform.TransformDirection(-transform.up);
            
            float rayDirVel = Vector3.Dot(rayDir, vel);
            if (!grounded) return;
            
            float x = hit.distance - rideHeight;

            springForce = (x * rideSpringStrenght) - (rayDirVel * rideSpringDampner);

            rb.AddForce(rayDir * springForce);
        }
        else
        {
            grounded = false;
        }
    }
    void FakeGravity()
    {
        if (!grounded)
        {
            rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
        }
    }
    private void CoyoteTime()
    {
        if (grounded)
        {
            //doubleJumpAble = false;
            coyoteTime = true;
            coyoteTimer = Time.timeSinceLevelLoad + coyoteDelay;
        }
        else if (Time.timeSinceLevelLoad >= coyoteTimer)
        {
            coyoteTime = false;
        }
    }
}
