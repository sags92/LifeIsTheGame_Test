using UnityEngine;

public class Dance : MonoBehaviour
{
    [SerializeField] private Animator charAnimator;

    public void DanceMacarena()
    {
        GlobalSettings.SelectDance("isMacarena");
        StartDancing();
    }
    public void DanceHouse()
    {
        GlobalSettings.SelectDance("isHouse");
        StartDancing();
    }
    public void DanceHipHop()
    {
        GlobalSettings.SelectDance("isHipHop");
        StartDancing();
    }
    public void StartDancing()
    {
        charAnimator.enabled = true;
        charAnimator.SetTrigger(GlobalSettings.GetActualDance());
    }
}
