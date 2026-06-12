using UnityEngine;

public class Heart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            GameManager.Instance.Heal(1);
            Destroy(gameObject);
        }
    }
}