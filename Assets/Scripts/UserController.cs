using UnityEngine;
using UnityEngine.AI;

public class UserController : MonoBehaviour
{
    private RaycastHit hit;
    private NavMeshAgent navMeshAgent;

    [Header("Camera")]
    [SerializeField] Camera userCamera;
    [SerializeField] Transform userCameraPosition;
    [SerializeField] float userCameraSpeed;
    private float xRotation;
    private float yRotation;

    // init UI
    private UIPoster posterUI;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        posterUI = FindObjectOfType<UIPoster>();
    }

    private void LateUpdate()
    {
        userCamera.transform.position = userCameraPosition.position;
    }

    private void Update()
    {
        Raycast();

        if(Input.GetMouseButton(0))
        {
            CameraLook();
        }

        if(Input.GetMouseButtonDown(1))
        {
            Movement();
        }

        if(Input.GetMouseButtonUp(0))
        {
            Interact();
        }
    }

    private void Raycast()
    {
        Ray ray = userCamera.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
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

    private void Movement()
    {
        if(hit.collider == null) return;
        if(hit.collider.tag == "Floor")
        {
            Vector3 destination = hit.point;
            navMeshAgent.SetDestination(destination);
        }
    }

    private void Interact()
    {
        if(hit.collider == null) return;

        // focus to poster
        if(hit.collider.tag == "Poster")
        {
            Sprite poster = hit.collider.GetComponentInChildren<SpriteRenderer>().sprite;
            posterUI.OpenPoster(poster);
        }
    }
}
