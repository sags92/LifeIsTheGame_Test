using System.Collections;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
