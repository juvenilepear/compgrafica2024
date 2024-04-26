using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private Vector3 velocity;
    public float horizontalInput;
    public float verticalInput;
    public float speed = 2.0f;
    public float turnSmoothTime = 0.1f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    float turnSmoothVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // read values from keyboard
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // apply gravity
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // move the object
        if (direction.magnitude >= 0.1f)
        {
            // calculate angle corresponding to the direction the player should be facing
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // make the angle change progressively over time for smooth rotation
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // apply angle to character
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }

}
