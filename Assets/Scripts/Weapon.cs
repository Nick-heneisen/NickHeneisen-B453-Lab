using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // The location in space where the projectiles (or raycast) will be spawned.
    [SerializeField] protected Transform firePoint;

    // How much damage this weapon does.
    [SerializeField] protected float damage;

    // The range of this weapon.
    [SerializeField] protected float range;

    // How quickly this weapon can fire.
    [SerializeField] protected float fireRate;

    // How many bullets this weapon can hold.
    [SerializeField] protected float bulletCount;

    protected virtual void Start()
    {
        // Code to initialize the weapon.
    }

    protected virtual void Shoot()
    {
        // Code to shoot the weapon.
    }
    protected virtual void Reload()
    {
        // Code to reload the weapon.
    }
}