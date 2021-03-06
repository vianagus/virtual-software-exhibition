using UnityEngine;
using UnityEngine.AI;

public class UserController : MonoBehaviour
{
    private RaycastHit hit;
    private NavMeshAgent navMeshAgent;
    private LineRenderer lineRenderer;

    [Header("Camera")]
    [SerializeField] Camera userCamera;
    [SerializeField] Transform userCameraPosition;
    [SerializeField] float userCameraSpeed;
    private float xRotation;
    private float yRotation;

    // init UI
    private UIBrochure brochureUI;
    private UIPoster posterUI;
    private UIDistanceWarning distanceWarningUI;
    
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        // init UI
        brochureUI = FindObjectOfType<UIBrochure>();
        posterUI = FindObjectOfType<UIPoster>();
        distanceWarningUI = FindObjectOfType<UIDistanceWarning>();

        // init for draw path
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        lineRenderer.positionCount = 0;
    }

    private void LateUpdate()
    {
        userCamera.transform.position = userCameraPosition.position;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)) CameraLook();

        if(Input.GetMouseButtonDown(1)) Movement();

        if(Input.GetMouseButtonUp(0)) Interact();

        if(navMeshAgent.hasPath)
        {
            DrawPath();
        }
    }

    private void ShootRaycast()
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
        ShootRaycast();
        if(hit.collider == null) return;
        if(hit.collider.tag == "Floor")
        {
            Vector3 destination = hit.point;
            MoveTo(destination);
        }
    }

    public void MoveTo(Vector3 destination)
    {
        navMeshAgent.SetDestination(destination);
    }

    private void DrawPath()
    {
        lineRenderer.positionCount = navMeshAgent.path.corners.Length;
        lineRenderer.SetPosition(0, transform.position);

        if(navMeshAgent.path.corners.Length < 2) return;

        for (int i = 1; i < navMeshAgent.path.corners.Length; i++)
        {
            Vector3 pointPosition = new Vector3(navMeshAgent.path.corners[i].x,
                                                navMeshAgent.path.corners[i].y,
                                                navMeshAgent.path.corners[i].z);
            lineRenderer.SetPosition(i, pointPosition);
        }
    }

    private void Interact()
    {
        ShootRaycast();
        if(hit.collider == null) return;

        // interact with poster
        if(hit.collider.CompareTag("Poster"))
        {
            ShowPoster();
        }
        else if(hit.collider.CompareTag("Brochure"))
        {
            ShowBrochure();
        }
    }

    private void ShowPoster()
    {
        float reachLimit = 6f;
        float distance = Vector3.Distance(transform.position, hit.collider.GetComponentInParent<StandBooth>().transform.position);

        if (distance > reachLimit) // show distance warning UI if too far from the stand booth
        {
            // show distance warning in duration
            distanceWarningUI.Active(1.5f);
        }
        else // show poster UI
        {
            Sprite poster = hit.collider.GetComponentInChildren<SpriteRenderer>().sprite;
            posterUI.OpenPoster(poster);
        }
    }

    private void ShowBrochure()
    {
        StandBooth standBooth = hit.collider.GetComponentInParent<StandBooth>();
        brochureUI.OpenBrochure(standBooth);
    }
}
