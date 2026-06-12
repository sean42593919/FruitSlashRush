using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            AudioManager.Instance.PlayBomb();
            GameManager.Instance.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}