using UnityEngine;
using UnityEngine.Video;

public class BigScreen : MonoBehaviour
{
    [SerializeField] VideoClip videoClip;
    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
        videoPlayer.clip = videoClip;
        videoPlayer.isLooping = true;
    }

}
