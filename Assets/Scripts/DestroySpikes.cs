using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpikes : MonoBehaviour
{
    public float lifetime = 10f;

    void Update()
    {
        if(lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
                Destruction();
        }    
    }
    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
