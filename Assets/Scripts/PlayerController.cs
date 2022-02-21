using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10;

    public LayerMask groundMask;

    private CharacterController charController;
    private float charGravity = -15f;
    private Vector3 velocity;
    private bool isGrounded;
    private float jumpHeight = 3;

  

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        charController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        UpdateKeyMovement();
        UpdatePhysics();
    }

    private void UpdatePhysics()
    {
        velocity.y += charGravity * Time.deltaTime;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -1f;
        }
        charController.Move(velocity * Time.deltaTime);
    }
    private void UpdateKeyMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        charController.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * charGravity);
        }
    }

  
}
