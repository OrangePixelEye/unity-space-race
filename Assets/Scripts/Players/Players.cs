using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public abstract class Players : MonoBehaviour
{
    protected Rigidbody2D my_rigidbody;
    [Range(10f,500f)]
    [SerializeField]
    protected float speed = 12f;
    private Vector2 startPos;

    public abstract void HandleInput();
    protected abstract void GetPoints();

    protected void Start()
    {
        my_rigidbody = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        GameManager.Instance.StartGame();
    }
    
    protected void MoveBar(int vertical)
    {
        my_rigidbody.velocity = new Vector2(0, vertical * speed);
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Respawn();
        if(collision.collider.tag == "Finish")
            GetPoints();
    }

    public void Respawn()
    {
        transform.position = startPos;
    }

    protected void Update()
    {
        HandleInput();
    }
}