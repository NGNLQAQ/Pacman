using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{ 
    public Movement movement { get; private set; }
    public GhostStart start { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostRunAway run { get; private set; }
    public GhostScatter scatter { get; private set; }
    
    public GhostBehaviour initial;

    public Transform target;

    public int score = 200;

    private void Awake()
    {
        this.movement = GetComponent<Movement>();
        this.start = GetComponent<GhostStart>();
        this.chase = GetComponent<GhostChase>();
        this.run = GetComponent<GhostRunAway>();
        this.scatter = GetComponent<GhostScatter>();
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        this.gameObject.SetActive(true);
        this.movement.ResetState();

        this.run.Disable();
        this.chase.Disable();
        this.scatter.Enable();
        
        if(this.start != this.initial)
        {
            this.start.Disable();
        }

        if(this.initial != null)
        {
            this.initial.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if(this.run.enabled)
            {
                FindObjectOfType<GameManager>().GhostEaten(this);
            }
            else
            {
                FindObjectOfType<GameManager>().PacmanEaten();
                this.chase.Disable();
            }
        }
    }
}
