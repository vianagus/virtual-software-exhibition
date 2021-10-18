using UnityEngine;

public class ButtonStandBoothList : MonoBehaviour
{
    private StandBooth standBooth;
    private UserController userController;

    private void Start() 
    {
        userController = FindObjectOfType<UserController>();
    }

    public void SetStandBooth(StandBooth standBooth)
    {
        this.standBooth = standBooth;
    }

    public StandBooth GetStandBooth()
    {
        return this.standBooth;
    }

    // set user destination to stand booth travel point
    public void OnButtonClick()
    {
        userController.MoveTo(standBooth.GetStandBoothTravelPoint());
    }
}
