using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody playerRigidBody;

    [SerializeField]
    private Vector3 nextMotionStepPosition;
    [SerializeField]
    private float playerSpeed;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private bool canJump;

    void Awake()
    {
        playerTransform = GetComponent<Transform>();
        playerRigidBody = GetComponent<Rigidbody>();

        canJump = false;

        nextMotionStepPosition = playerTransform.position;
    }

    void Update()
    {
        GetBaseInput();
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    private void PlayerMove()
    {
        playerTransform.Translate(nextMotionStepPosition);
    }

    private void PlayerJump()
    {
        if (canJump)
        {
            playerRigidBody.AddForce(nextMotionStepPosition, ForceMode.Impulse);
        }
    }

    private void GetBaseInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            nextMotionStepPosition = Vector3.forward * playerSpeed;
            PlayerMove();
        }
        if (Input.GetKey(KeyCode.S))
        {
            nextMotionStepPosition = Vector3.back * playerSpeed;
            PlayerMove();
        }
        if (Input.GetKey(KeyCode.A))
        {
            nextMotionStepPosition = Vector3.left * playerSpeed;
            PlayerMove();
        }
        if (Input.GetKey(KeyCode.D))
        {
            nextMotionStepPosition = Vector3.right * playerSpeed;
            PlayerMove();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            nextMotionStepPosition = Vector3.up * jumpPower;
            PlayerJump();
        }
    }
}
