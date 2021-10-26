using UnityEngine;
using UnityEngine.Video;

[ExecuteInEditMode]
[RequireComponent(typeof(StandBooth))]
public class StandBoothPrototype : MonoBehaviour
{
    private StandBooth standBooth;
    private SpriteRenderer poster;
    private VideoPlayer video;
    

    private void Awake()
    {
        standBooth = GetComponent<StandBooth>();
        poster = GetComponentInChildren<SpriteRenderer>();
        video = GetComponentInChildren<VideoPlayer>();

        SetVideo(standBooth.GetVideo());
    }

    private void Update()
    {
        SetPoster(standBooth.GetPoster());
    }

    private void SetPoster(Sprite posterSprite)
    {
        poster.drawMode = SpriteDrawMode.Sliced;
        poster.size = new Vector2(0.8411f * 2, 1.189f * 2); // A0 paper size x 2
        poster.sprite = posterSprite;
    }

    private void SetVideo(VideoClip videoClip)
    {
        video.aspectRatio = VideoAspectRatio.FitOutside;
        video.clip = videoClip;
        video.isLooping = true;
    }
}
