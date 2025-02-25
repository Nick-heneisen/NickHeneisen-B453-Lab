using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // The location in space where the projectiles (or raycast) will be spawned.
    [SerializeField] protected Transform firePoint;

    // How much damage this weapon does.
    [SerializeField] protected int damage;

    // The range of this weapon.
    [SerializeField] protected float range;
    [SerializeField] protected float firerate;
    [SerializeField] protected int bulletCount;
    [SerializeField] protected int maxCapacity;


    [SerializeField] protected PlayerController playerController;

    protected void Awake()
    {
        playerController = GameObject.Find("--- Player ---").GetComponent<PlayerController>();
    }

    protected void Start()
    {
        //Updates the UI at the start.
        UIManager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
    }

    //Handles the shooting behavior of the weapon.
    protected virtual void Shoot()
    {
        UIManager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
        if (bulletCount <= 0)
        {
            Reload();
        }
    }

    //Handles the shooting behavior of the weapon.
    protected virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
    }

    // A coroutine that waits for a second before reloading the weapon.
    protected IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(1f);

        if(playerController.SpareRounds >= maxCapacity)
        {
            bulletCount = maxCapacity;
            playerController.SpareRounds -= maxCapacity;
        }

        UIManager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
    }
}
