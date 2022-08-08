using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour
{

    public Transform exit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 position = collision.transform.position;
        position.x = this.exit.position.x;
        position.y = this.exit.position.y;
        collision.transform.position = position;
    }
}
