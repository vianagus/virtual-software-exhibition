using UnityEngine;
using UnityEngine.Video;

[ExecuteInEditMode]
public class StandBoothPrototype : StandBooth
{
    private SpriteRenderer posterComponent;
    private VideoPlayer videoComponent;

    private void Awake()
    {
        posterComponent = GetComponentInChildren<SpriteRenderer>();
        videoComponent = GetComponentInChildren<VideoPlayer>();

        SetVideo(GetVideo());
    }

    private void Update()
    {
        SetPoster(GetPoster());
    }

    private void SetPoster(Sprite posterSprite)
    {
        if(posterSprite == null) return;
        posterComponent.drawMode = SpriteDrawMode.Sliced;
        posterComponent.size = new Vector2(0.8411f * 2, 1.189f * 2); // A0 paper size x 2
        posterComponent.sprite = posterSprite;
    }

    private void SetVideo(VideoClip videoClip)
    {
        videoComponent.aspectRatio = VideoAspectRatio.FitOutside;
        videoComponent.clip = videoClip;
        videoComponent.isLooping = true;
    }
}
