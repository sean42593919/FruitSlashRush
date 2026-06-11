using UnityEngine;

public class Fruit : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            GameManager.Instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}