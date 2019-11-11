using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyCoin : MonoBehaviour
{
    public float lifetime = 10.0f;
    public AudioClip drinkSound;

    void Start()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = true;
    }

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
            UIController.Instance.myPlayer.GetComponent<PlayerState>().points(1);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(drinkSound);
            gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
            //yield return new WaitForSeconds(3);
            Destruction();
        }
    }

    public void Destruction()
    {
        Destroy(this.gameObject, drinkSound.length);
    }
}
