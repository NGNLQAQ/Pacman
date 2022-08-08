using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostChase : GhostBehaviour
{
    private void OnDisable()
    {
        this.ghost.scatter.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if (node != null && this.enabled && !this.ghost.run.enabled)
        {
            Vector2 direction = Vector2.zero;
            float min = float.MaxValue;

            foreach(Vector2 available in node.avaliable)
            {
                Vector3 newPos = this.transform.position + new Vector3(available.x, available.y, 0.0f);
                float distance = (this.ghost.target.position - newPos).sqrMagnitude;

                if(distance < min)
                {
                    min = distance;
                    direction = available;
                }
            }

            this.ghost.movement.SetDirection(direction);
        }
    }
}
