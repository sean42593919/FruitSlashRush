using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            GameManager.Instance.GameOver();
            Destroy(gameObject);
        }
    }
}