using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotateSpeed;

    void Start()
    {
        rotateSpeed =
            Random.Range(-250f, 250f);
    }

    void Update()
    {
        transform.Rotate(
            0f,
            0f,
            rotateSpeed * Time.deltaTime
        );
    }
}