using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    public float speed = 8.0f;
    public float speedMutiplier = 1.0f;

    public Vector2 initialDirection;
    public LayerMask wallLayer;
    public Rigidbody2D rig { get; private set; }
    public Vector2 direction { get; private set; }
    public Vector2 nextdir { get; private set; }
    public Vector3 start { get; private set; }

    private void Awake()
    {
        this.rig = GetComponent<Rigidbody2D>();
        this.start = this.transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.speedMutiplier = 1.0f;
        this.direction = this.initialDirection;
        this.nextdir = Vector2.zero;
        this.transform.position = this.start;
        this.rig.isKinematic = false;
        this.enabled = true;
    }

    private void FixedUpdate()
    {
        Vector2 position = this.rig.position;
        Vector2 translation = this.direction * this.speed * this.speedMutiplier * Time.fixedDeltaTime;
        this.rig.MovePosition(position + translation);
    }

    private void Update()
    {
        if(this.nextdir != Vector2.zero)
        {
            SetDirection(this.nextdir);
        }
    }

    public void SetDirection(Vector2 direction, bool forced = false)
    {
        if(forced || !Check(direction))
        {
            this.direction = direction;
            this.nextdir = Vector2.zero;
        }
        else
        {
            this.nextdir = direction;
        }
    }

    public bool Check(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.75f, 0.0f, direction, 1.5f, this.wallLayer);
        return hit.collider != null;
    }
}
