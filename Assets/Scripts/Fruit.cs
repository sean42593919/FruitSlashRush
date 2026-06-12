using UnityEngine;

public class Fruit : MonoBehaviour
{
    public int scoreValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Blade"))
        {
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}