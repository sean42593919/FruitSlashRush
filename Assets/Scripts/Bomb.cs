using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            GameManager.Instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}