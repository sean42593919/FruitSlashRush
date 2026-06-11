using UnityEngine;

public class Blade : MonoBehaviour
{
    private Camera mainCamera;
    private CircleCollider2D bladeCollider;
    private TrailRenderer trail;

    void Start()
    {
        mainCamera = Camera.main;
        bladeCollider = GetComponent<CircleCollider2D>();
        trail = GetComponent<TrailRenderer>();

        bladeCollider.enabled = false;
        trail.emitting = false;
    }

    void Update()
    {
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        if (Input.GetMouseButtonDown(0))
        {
            transform.position = mousePosition;

            trail.emitting = false;
            trail.Clear();

            bladeCollider.enabled = true;

            Invoke(nameof(StartTrail), 0.01f);
        }

        if (Input.GetMouseButton(0))
        {
            transform.position = mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            bladeCollider.enabled = false;
            trail.emitting = false;
            trail.Clear();
        }
    }

    void StartTrail()
    {
        trail.Clear();
        trail.emitting = true;
    }
}