using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private Transform target;

    private void Start()
    {
        target = FindObjectOfType<PhysicsMovement>().transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (target.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
        else if (target.position.x > transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}
