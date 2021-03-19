using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Meteor : MonoBehaviour
{
    [SerializeField]
    private float speed_test;

    private Rigidbody2D my_rigidBody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start() => my_rigidBody = GetComponent<Rigidbody2D>();

    // Update is called once per frame
    void FixedUpdate() => my_rigidBody.velocity = direction * speed_test;

    public void Initialize(Vector2 direction) => this.direction = direction;

    private void OnBecameInvisible() => Destroy(gameObject);
}
