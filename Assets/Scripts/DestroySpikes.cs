using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpikes : MonoBehaviour
{
    public float lifetime = 1.0f;
    //private Player player; 

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<player>();
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

    public void OnTriggerEnter2D()
    {
        
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
