using UnityEngine;
using UnityEngine.Video;

public class BigScreen : MonoBehaviour
{
    [SerializeField] VideoClip videoClip;

    private AudioSource audioSource;
    private VideoPlayer videoPlayer;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        videoPlayer = GetComponentInChildren<VideoPlayer>();
        videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
        videoPlayer.clip = videoClip;
        videoPlayer.isLooping = true;
    }

}
