using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
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
    [SerializeField] protected int bulletCount;

    [SerializeField] protected int maxCapacity;

    [SerializeField] protected int spareRounds;

    [SerializeField] TMP_Text textUI;

    protected virtual void Start()
    {
        // Code to initialize the weapon.
        textUI.text = bulletCount + " / " + spareRounds;
    }

    public void Shoot()
    {
        if (bulletCount != 0) {
            RaycastHit hit;
            Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);
            if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
            {
                Debug.Log(hit.transform.name);
            }

            bulletCount--;
        }

        textUI.text = bulletCount + " / " + spareRounds;
    }
    public void Reload()
    {
        if (spareRounds >= maxCapacity)
        {
            spareRounds -= maxCapacity - bulletCount;
            bulletCount = maxCapacity;
            
        } else
        {
            bulletCount = spareRounds;
            spareRounds -= spareRounds;
        }

        textUI.text = bulletCount + " / " + spareRounds;
    }
}