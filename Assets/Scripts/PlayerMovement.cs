using Unity.Mathematics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public CharacterController controller;
    public float gravityValue = -9.81f; // Gravedad
    public KeyCode jumpKey = KeyCode.Space; // Tecla predeterminada para el salto
    private Vector3 velocity;
    public float horizontalInput;
    public float verticalInput;
    public float jumpSpeed = 5.0f; // Afectará la fuerza del salto
    public float speed = 2.0f;
    public float turnSmoothTime = 0.1f;
    public float jumpHeight =5.0f; // Altura del salto
    float turnSmoothVelocity;
 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>(); // Obtener el componente Animator en Start
    }

    // Update is called once per frame
    void Update()
    {
        // Leer valores del teclado
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Aplicar gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Mover el objeto
        if (direction.magnitude >= 0.1f)
        {
            // Calcular ángulo correspondiente a la dirección hacia la que debe mirar el jugador
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            // Hacer que el ángulo cambie progresivamente con el tiempo para una rotación suave
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            // Aplicar ángulo al personaje
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
            //animacion de movimiento
            animator.SetFloat("VeX", horizontalInput);
            animator.SetFloat("VeY", verticalInput);

        }
     
        // Salto
        if (Input.GetKeyDown(jumpKey) && controller.isGrounded) // Solo saltar si está en el suelo
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue); // Calcular velocidad de salto para la altura deseada
            animator.Play("saltar");
        }
    }
}
