using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float animationTime = 0.25f;
    public int frame { get; private set; }

    public bool loop = true;

    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(PlayAnimation), this.animationTime, this.animationTime);
    }

    private void PlayAnimation()
    {
        if(!this.spriteRenderer.enabled)
        {
            return;
        }

        this.frame++;

        if(this.frame >= this.sprites.Length && this.loop)
        {
            this.frame = 0;
        }
        
        if(this.frame >= 0 && this.frame < this.sprites.Length)
        {
            this.spriteRenderer.sprite = this.sprites[this.frame];
        }
    }

    public void Restart()
    {
        this.frame = -1;
        PlayAnimation();
    }
}
