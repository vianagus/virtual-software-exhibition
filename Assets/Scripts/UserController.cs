using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField] Camera userCamera;
    [SerializeField] Transform userCameraPosition;
    [SerializeField] float userCameraSpeed;
    private float xRotation;
    private float yRotation;
    
    private void Start()
    {
        
    }

    private void LateUpdate()
    {
        userCamera.transform.position = userCameraPosition.position;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            CameraLook();
        }
    }

    private void CameraLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // vertical look
        yRotation -= mouseX;

        // horizontal look
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        userCamera.transform.localEulerAngles = new Vector3(xRotation, yRotation, 0) * userCameraSpeed;
    }
}
