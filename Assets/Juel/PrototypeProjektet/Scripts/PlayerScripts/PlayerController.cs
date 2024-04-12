using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Temp UI")]
    public int score = 0;
    public int numOfTrashInBag = 0;
    public int BagSize;

    [Header(" ")]
    [Header("Stats and Utilities")]



    public float moveSpeed = 5f;
    public float sensitivity;
    public Transform t_playerCamera;



    public bool CanPickUpTrash;
    public bool HasTrash;


    public Camera playerCamera;
    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -90f;
    public float bottomClamp = 90f;



    private Rigidbody rb;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        // Lock cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        HasTrash = numOfTrashInBag >= 1;

        CanPickUpTrash = BagSize > numOfTrashInBag;


        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = (t_playerCamera.forward * verticalInput + t_playerCamera.right * horizontalInput).normalized;
        Vector3 moveVelocity = moveDirection * moveSpeed;

        // Apply movement to the rigidbody
        rb.velocity = new Vector3(moveVelocity.x, rb.velocity.y, moveVelocity.z);



        // Player rotation (looking around)
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        //Xrotation (up and down)
        xRotation -= mouseY;

        //Rotation Clamp
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);

        //Rotation around the y axis ( Look left and Right)
        yRotation += mouseX;

        //Apply rotations to our transform
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
