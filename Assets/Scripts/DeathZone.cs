using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Fruit fruit =
            other.GetComponent<Fruit>();

        if (fruit != null)
        {
            Destroy(other.gameObject);

            GameManager.Instance.TakeDamage(1);
        }
    }
}