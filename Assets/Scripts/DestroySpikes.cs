using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpikes : MonoBehaviour
{
    public float lifetime = 1.0f;
    private PlayerState player; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerState>();
    }

    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                Destruction();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
            player.damage(10);
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
