using UnityEngine;

public class BombFlash : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float flashSpeed = 0.2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating(
            nameof(ToggleFlash),
            flashSpeed,
            flashSpeed
        );
    }

    private bool dimmed = false;

    private void ToggleFlash()
    {
        if (spriteRenderer == null) return;

        Color color = spriteRenderer.color;

        if (dimmed)
        {
            color.a = 1f;
        }
        else
        {
            color.a = 0.4f;
        }

        spriteRenderer.color = color;
        dimmed = !dimmed;
    }
}