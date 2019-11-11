using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPotion : MonoBehaviour
{
    public float lifetime = 10.0f;

    // Update is called once per frame
    void Update()
    {
        if (lifetime > 0)
        {
            lifetime -= Time.deltaTime;
            if (lifetime == 0)
            {
                Destruction();
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            UIController.Instance.myPlayer.GetComponent<PlayerState>().heal(10);
            Destruction();
        }
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
