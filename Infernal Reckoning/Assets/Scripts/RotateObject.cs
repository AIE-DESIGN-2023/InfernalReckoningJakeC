using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 10f; // Speed of rotation

    void Update()
    {
        // Rotate the object horizontally
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}