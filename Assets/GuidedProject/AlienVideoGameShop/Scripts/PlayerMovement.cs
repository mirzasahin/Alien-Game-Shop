using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player Speed
    public float normalPlayerSpeed = 10f;
    public float sprintPlayerSpeed = 16f;
    private float currentSpeed;

    public float rotationSpeed = 20f;

    private Rigidbody playerRb;
    private Animator playerAnim;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        Cursor.lockState = CursorLockMode.Locked;
        currentSpeed = normalPlayerSpeed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = sprintPlayerSpeed;
            playerAnim.SetBool("isRunning", true);
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = normalPlayerSpeed;
            playerAnim.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(dirX, 0f, dirZ).normalized;

        // Kameranýn bakýþ yönünü al ve sadece yatay düzlemdeki bileþenleri kullan
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraForwardFlat = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;

        // Hareket vektörünü, kameranýn yatay bakýþ yönüne göre döndür
        Vector3 rotatedMovement = Quaternion.LookRotation(cameraForwardFlat) * movement;

        playerRb.velocity = rotatedMovement * currentSpeed * Time.fixedDeltaTime * 5;

        // Player Movement Animation
        if(rotatedMovement.magnitude > 0.1f)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }

        if (rotatedMovement != Vector3.zero)
        {
            // Dönme iþlemi
            Quaternion toRotation = Quaternion.LookRotation(rotatedMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime * 35);
        }
    }
}
