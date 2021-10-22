using UnityEngine;
using UnityEngine.Video;

public class BigScreen : MonoBehaviour
{
    [SerializeField] VideoClip videoClip;
    [Range(0,1)] [SerializeField] float volume;
    [SerializeField] float audioRange;
    private VideoPlayer videoPlayer;

    private UserController user;
    private float distanceToUser;

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
        videoPlayer.clip = videoClip;
        videoPlayer.isLooping = true;

        user = FindObjectOfType<UserController>();
    }

    private void Update() 
    {
        distanceToUser = Vector3.Distance(transform.position, user.transform.position);
        if(distanceToUser <= audioRange)
        {
            videoPlayer.SetDirectAudioVolume(0, volume);
        }
        else
        {
            videoPlayer.SetDirectAudioVolume(0, 0);
        }
    }
}
