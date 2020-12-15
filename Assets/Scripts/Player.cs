using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float Speed;
   private Rigidbody2D rig;

   private bool isJumping;
   public float JumpForce;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity = new Vector2(Speed * Time.deltaTime, rig.velocity.y);

        if(Input.GetKey(KeyCode.Space) && !isJumping){
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
        }
    }


     void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground"){
            isJumping = false;
        }
    }
}
