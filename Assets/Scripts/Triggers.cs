using System.Collections;
using UnityEngine;

public class Triggers : MonoBehaviour, ITriggerable
{
    [Header("Oneshot Settings")]
    [SerializeField] bool oneShot;

    [Header("Cooldown Settings")]
    [SerializeField] bool cooldown;
    [SerializeField] float cooldownTime = 1f;

    protected bool canTrigger = true;

    public void Trigger()
    {
        if(oneShot)
        {
            OneShotTrigger();
        }
        else if (cooldown)
        {
           CooldownTrigger();
        }
    }

    protected virtual void OneShotTrigger()
    {
        Debug.Log("OneShot Triggered");
        canTrigger = false;
    }

    protected virtual void CooldownTrigger()
    {
        Debug.Log("Cooldown Triggered");
        StartCoroutine(Cooldown());
    }


    protected IEnumerator Cooldown()
    {
        canTrigger = false;
        yield return new WaitForSeconds(cooldownTime);
        canTrigger = true;
    }
}
