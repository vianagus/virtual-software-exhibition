using UnityEngine;
using UnityEngine.Video;

[ExecuteInEditMode]
public class StandBoothPrototype : StandBooth
{
    private SpriteRenderer poster;
    private VideoPlayer video;

    private void Awake()
    {
        poster = GetComponentInChildren<SpriteRenderer>();
        video = GetComponentInChildren<VideoPlayer>();

        SetVideo(GetVideo());
    }

    private void Update()
    {
        SetPoster(GetPoster());
    }

    private void SetPoster(Sprite posterSprite)
    {
        if(posterSprite == null) return;
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
