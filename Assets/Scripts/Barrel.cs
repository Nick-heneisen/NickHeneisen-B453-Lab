using UnityEngine;

public class Barrel : MonoBehaviour, IDamagable
{
    [SerializeField] Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void TakeDamage(int damage)
    {
        rb.AddForce(Vector3.up * 10f,ForceMode.Impulse);
    }
}
