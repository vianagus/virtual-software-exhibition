using UnityEngine;

public class StandBooth : MonoBehaviour
{
    [SerializeField] string standBoothName;
    [SerializeField] float distanceFromPivot;
    private Vector3 travelPoint;

    private void Start() 
    {
        travelPoint = transform.position + transform.TransformDirection(Vector3.forward * distanceFromPivot);
    }

    public string GetName()
    {
        return this.standBoothName;
    }

    public Vector3 GetStandBoothTravelPoint()
    {
        return this.travelPoint;
    }
}
