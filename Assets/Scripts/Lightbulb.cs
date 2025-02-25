using UnityEngine;

public class Lightbulb : MonoBehaviour, IDamagable
{
    [SerializeField] GameObject light;
    private int health = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            Destroy(light);
        }
    }
}
