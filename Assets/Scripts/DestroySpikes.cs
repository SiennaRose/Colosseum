using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroySpikes : MonoBehaviour
{
    public float lifetime = 1.0f;
    public GameObject player;

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
        if(col.gameObject.tag == "Player")
        {
            UIController.Instance.myPlayer.GetComponent<PlayerState>().damage(10);
           // player = GameObject.Find("Player");
          //  StartCoroutine(player.GetComponent<BasicMovement>().Knockback();
        }
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
