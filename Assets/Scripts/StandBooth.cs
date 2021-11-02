using UnityEngine;
using UnityEngine.Video;

public class StandBooth : MonoBehaviour
{
    [Header("Product")]
    [SerializeField] string productName;
    [TextArea(3,6)] [SerializeField] string productDescription;

    [Header("Link")]
    [SerializeField] string presentationLink;
    [SerializeField] string demoLink;

    [Header("Team")]
    [SerializeField] string teamName;
    [SerializeField] TeamMember[] teamMembers;

    [Header("More")]
    [SerializeField] Sprite logo;
    [SerializeField] Sprite poster;
    [SerializeField] VideoClip video;

    private Vector3 travelPoint;
    private float distanceFromPivot = 2;

    [System.Serializable]
    class TeamMember
    {
        public string memberName;
        public string memberInfo;
    }

    private void Start() 
    {
        travelPoint = transform.position + transform.TransformDirection(Vector3.forward * distanceFromPivot);
    }

    public string GetProductName()
    {
        return this.productName;
    }

    public string GetProductDescription()
    {
        return this.productDescription;
    }

    public string GetPresentationLink()
    {
        return this.presentationLink;
    }

    public string GetDemoLink()
    {
        return this.demoLink;
    }

    public string GetTeamName()
    {
        return this.teamName;
    }

    public string GetTeamMemberName(int i)
    {
        return this.teamMembers[i].memberName;
    }

    public string GetTeamMemberInfo(int i)
    {
        return this.teamMembers[i].memberInfo;
    }

    public Sprite GetLogo()
    {
        return this.logo;
    }

    public Sprite GetPoster()
    {
        return this.poster;
    }

    public VideoClip GetVideo()
    {
        return this.video;
    }

    public Vector3 GetStandBoothTravelPoint()
    {
        return this.travelPoint;
    }
}
