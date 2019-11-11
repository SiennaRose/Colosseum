using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroySpikes : MonoBehaviour
{
    public float lifetime = 1.0f;
    public AudioClip stabbedSound;


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
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(stabbedSound);
        }
    }

    public void Destruction()
    {
        Destroy(this.gameObject);
    }
}
