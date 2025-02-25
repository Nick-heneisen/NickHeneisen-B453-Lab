using UnityEngine;

public class Pistol : Weapon
{
    //Handles the shooting behavior of the weapon
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    // This method overrides the parent class to modify the shooting behavior of the weapon class
    protected override void Shoot() { 
        bulletCount--;

        // Call the parent class's Shoot method, which does the basic function of shooting
        base.Shoot();

        RaycastHit hit;
        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);
        if(Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            if (hit.collider != null)
            {
                IDamagable damagable = hit.collider.GetComponent<IDamagable>();
                if (damagable != null)
                {
                    damagable.TakeDamage(damage);
                }
            }
        }
    }

    // This method overrides the parent class to modify the reloading behavior of the weapon class
    protected override void Reload() {
        // Call the parent class's Reload method, which does the basic function of reloading
        base.Reload();
    }
}
