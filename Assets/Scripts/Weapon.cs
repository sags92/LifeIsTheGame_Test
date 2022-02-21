using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons")]
public class Weapon : ScriptableObject
{
    public string weaponName;
    public float force;
    public float shootSpeed;
    public float ammoSize;
    public float reloadTime;
    public GameObject bulletType;
    public Material gunMaterial;
}
