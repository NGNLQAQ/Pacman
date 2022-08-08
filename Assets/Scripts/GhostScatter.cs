using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScatter : GhostBehaviour
{
    private void OnDisable()
    {
        this.ghost.chase.Enable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Node node = collision.GetComponent<Node>();

        if(node != null && this.enabled && !this.ghost.run.enabled)
        {
            int index = Random.Range(0, node.avaliable.Count);

            if(node.avaliable[index] == -this.ghost.movement.direction && node.avaliable.Count > 1)
            {
                index++;

                if(index >= node.avaliable.Count)
                {
                    index = 0;
                }
            }

            this.ghost.movement.SetDirection(node.avaliable[index]);
        }
    }
}
