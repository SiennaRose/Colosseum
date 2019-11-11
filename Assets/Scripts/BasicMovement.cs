using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public Animator animator;

    public Rigidbody2D rb; 

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal")*4, Input.GetAxis("Vertical")*4, 0.0f);
        
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Magnitude", movement.magnitude);

        //transform.position = transform.position + movement * Time.deltaTime;
        rb.velocity = new Vector2(movement.x, movement.y);
    }

    //public IEnumerator Knockback()
    //{
     //   float timer = 0;    
      //  while(knockDur > timer)
      //  {
      //      timer += Time.deltaTime;
       //     rb.AddForce(transform.position.x * -100,transform.y*100);
       // }
      //  yield return 0;
    //}
}
