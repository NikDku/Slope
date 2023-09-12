using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    private float horizontalInput;
    [SerializeField] private float maxSpeed = 15;

    private bool canMove = true;

    private Vector3 startPos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb.maxAngularVelocity = Mathf.Infinity;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        UserInput();
        CheckForOutOfBounds();

        if(Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        }
    }

    private void FixedUpdate()
    {
        if(rb.velocity.magnitude < maxSpeed && CheckGrounded())
            rb.AddForceAtPosition(Vector3.forward * 1000 * rb.mass * Time.deltaTime, transform.position);

        rb.AddForceAtPosition(Vector3.right * horizontalInput * 700 * rb.mass * Time.deltaTime, transform.position);
        
        
    }

    private void UserInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }


    private void CheckForOutOfBounds()
    {
        if(transform.position.y < -20)
        {
            GameManager.Instance.FallOff();
        }
    }

    public bool CheckGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 0.8f, LayerMask.GetMask("Ground"));
    }

    public void SetMovable(bool movable)
    {
        canMove = movable;
    }


}
