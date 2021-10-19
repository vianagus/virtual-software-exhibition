using UnityEngine;
using UnityEngine.AI;

public class DrawPath : MonoBehaviour
{
    private UserController user;
    private LineRenderer lineRenderer;
    private NavMeshPath path;

    private void Start() 
    {
        user = FindObjectOfType<UserController>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        //NavMesh.CalculatePath(user.transform.position, user.GetDestination(), NavMesh.AllAreas, path);
        //Vector3[] corners = path.corners;
        //lineRenderer.SetPositions(corners);
    }
}
