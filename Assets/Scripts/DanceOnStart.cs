using UnityEngine;

public class DanceOnStart : MonoBehaviour
{
    private Dance dance;
    void Start()
    {
        dance = GetComponent<Dance>();
        dance.StartDancing();
    }

}
