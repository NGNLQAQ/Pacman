using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public LayerMask wallLayer;
    public List<Vector2> avaliable { get; private set; }

    private void Start()
    {
        this.avaliable = new List<Vector2>();

        Check(Vector2.up);
        Check(Vector2.down);
        Check(Vector2.left);
        Check(Vector2.right);
    }

    private void Check(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.BoxCast(this.transform.position, Vector2.one * 0.5f, 0.0f, direction, 1.0f, this.wallLayer);
        if(hit.collider == null)
        {
            avaliable.Add(direction);
        }
    }
}
