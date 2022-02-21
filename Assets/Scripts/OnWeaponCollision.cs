using UnityEngine;
using TMPro;

public class OnWeaponCollision : MonoBehaviour
{
    [SerializeField] private Material[] gunMaterials;

    public Weapon currentWeapon;
    public TMP_Text weaponName;
    public TMP_Text weaponBullets;

    public float bulletsLeft;
    public float shootSpeed;
    public float magazineSize;
    public float reloadTime;
    public GameObject bulletType;
    public Material gunMaterial;
    public float force;

    private PlayerShoot playerShoot;
    private bool weaponPicked = false;

    private void Awake()
    {
        playerShoot = GetComponent<PlayerShoot>();
    }
    private void Update()
    {
        if (weaponPicked)
            weaponBullets.text = ($"{ bulletsLeft} / { currentWeapon.ammoSize}");
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!weaponPicked)
            weaponPicked = true;

        WeaponDisplay weaponDisplay = collider.gameObject.GetComponent<WeaponDisplay>();

        if (weaponDisplay != null)
        {
            currentWeapon = weaponDisplay.weapon;
            playerShoot.isShootAble = true;

            weaponName.text = currentWeapon.weaponName;
            magazineSize = currentWeapon.ammoSize;
            bulletsLeft = magazineSize;
            force = currentWeapon.force;
            shootSpeed = currentWeapon.shootSpeed;
            reloadTime = currentWeapon.reloadTime;
            bulletType = currentWeapon.bulletType;
            gunMaterial = currentWeapon.gunMaterial;


            foreach (Material individualMaterial in gunMaterials)
            {
                individualMaterial.mainTexture = currentWeapon.gunMaterial.mainTexture;
            }
        }
    }
}
