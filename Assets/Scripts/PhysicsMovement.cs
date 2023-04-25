using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SurfaceSlider surfaceSlider; 
    [SerializeField] private float speed;

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (speed * Time.deltaTime);

        rb.MovePosition(rb.position + offset);
    }
}
