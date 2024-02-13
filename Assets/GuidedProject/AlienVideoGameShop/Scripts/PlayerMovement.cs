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
    private bool isMoving;
    public bool isGameStarted;
    private float dirX;
    private float dirZ;

    public GameObject startGameButton;


    [SerializeField] private UIManager UIManagerScript;

    Vector3 movement;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();

        currentSpeed = normalPlayerSpeed;
    }

    private void Update()
    {
       

        if(Camera.main != null && isGameStarted)
        {
            CharacterAnimations();
        }
    }

    private void FixedUpdate()
    {
        if(Camera.main != null && isGameStarted)
        {
            CharacterController();
        }
    }

    private void CharacterController()
    {
        dirX = Input.GetAxis("Horizontal");
        dirZ = Input.GetAxis("Vertical");

        movement = new Vector3(dirX, 0f, dirZ).normalized;

        // Kameran�n bak�� y�n�n� al ve sadece yatay d�zlemdeki bile�enleri kullan
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraForwardFlat = new Vector3(cameraForward.x, 0f, cameraForward.z).normalized;

        // Hareket vekt�r�n�, kameran�n yatay bak�� y�n�ne g�re d�nd�r
        Vector3 rotatedMovement = Quaternion.LookRotation(cameraForwardFlat) * movement;

        playerRb.velocity = rotatedMovement * currentSpeed * Time.fixedDeltaTime * 5;

        // Player Movement Animation
        if (rotatedMovement.magnitude > 0.1f)
        {
            playerAnim.SetBool("isMoving", true);
        }
        else
        {
            playerAnim.SetBool("isMoving", false);
        }

        if (rotatedMovement != Vector3.zero)
        {
            // D�nme i�lemi
            Quaternion toRotation = Quaternion.LookRotation(rotatedMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime * 35);
        }
    }

    private void CharacterAnimations()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            currentSpeed = sprintPlayerSpeed;
            playerAnim.SetBool("isRunning", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            currentSpeed = normalPlayerSpeed;
            playerAnim.SetBool("isRunning", false);
        }



        if (Input.GetKeyDown(KeyCode.Space) && movement.magnitude < 0.1f)
        {
            playerAnim.SetTrigger("idleJumping");
            playerRb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }

        else if (Input.GetKeyDown(KeyCode.Space) && movement.magnitude > 0.1f)
        {
            playerAnim.SetTrigger("runJumping");
        }
    }

    public void GameStarter()
    {
        isGameStarted = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void StartGameButton()
    {
        if (!isGameStarted)
        {
            startGameButton.SetActive(true);
        }
    }
}


