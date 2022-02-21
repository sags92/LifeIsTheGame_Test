using UnityEngine;
using TMPro;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject spawnPosition;
    [SerializeField] private TMP_Text reloadingTxt;

    public bool isShootAble, isReloading, isShooting;

    private OnWeaponCollision onWeaponCollision;

    private void Awake()
    {
        onWeaponCollision = GetComponent<OnWeaponCollision>();

        isShootAble = false;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && isShootAble)
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.R) && onWeaponCollision.bulletsLeft < onWeaponCollision.magazineSize && !isReloading)
            Reload();
    }
    private void Shoot()
    {
        isShooting = true;
        onWeaponCollision.bulletsLeft--;

        GameObject newBullet = Instantiate(onWeaponCollision.bulletType, spawnPosition.transform.position, Quaternion.identity);
        newBullet.transform.forward = newBullet.transform.forward.normalized;
        newBullet.GetComponent<Rigidbody>().AddForce(spawnPosition.transform.forward.normalized * onWeaponCollision.currentWeapon.force, ForceMode.Impulse);

        if (isShootAble && isShooting && !isReloading && onWeaponCollision.bulletsLeft <= 0)
            Reload();
    }

    private void Reload()
    {
        isReloading = true;
        isShootAble = false;
        reloadingTxt.enabled = true;
        Invoke("ReloadFinished", onWeaponCollision.currentWeapon.reloadTime);
    }
    private void ReloadFinished()
    {
        onWeaponCollision.bulletsLeft = onWeaponCollision.magazineSize;
        isReloading = false;
        isShootAble = true;
        reloadingTxt.enabled = false;
    }
}
