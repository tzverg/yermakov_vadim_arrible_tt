using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1F;

    [SerializeField] private GameObject targetGO;

    private Camera mainCamera;
    private Vector3 mousePos;
    [SerializeField] private float cameraRotationAngle = 0F;

    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mousePos = Input.mousePosition;
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            cameraRotationAngle = sensitivity * ((mousePos.x - (Screen.width / 2)) / Screen.width);
            //mainCamera.transform.RotateAround(targetGO.transform.position, Vector3.up, cameraRotationAngle);

            targetGO.transform.Rotate(Vector3.up * cameraRotationAngle);

            cameraRotationAngle = sensitivity * ((mousePos.y - (Screen.height / 2)) / Screen.height);
            mainCamera.transform.RotateAround(targetGO.transform.position, mainCamera.transform.right, -cameraRotationAngle);
        }
    }
}