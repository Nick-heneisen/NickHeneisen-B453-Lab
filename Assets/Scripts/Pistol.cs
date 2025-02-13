using UnityEngine;
public class Pistol : Weapon
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    protected override void Shoot()
    {
        RaycastHit hit;
        Debug.DrawRay(firePoint.position, firePoint.forward * range, Color.red, 1f);
        if (Physics.Raycast(firePoint.position, firePoint.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }
}