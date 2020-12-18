using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   public float Speed;
   private Rigidbody2D rig;

   private bool isJumping;
   public float JumpForce;

    public GameObject bullet;
    public Transform firePoint;

    public GameObject smoke;

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
            smoke.SetActive(true);// ativar fumaça do jetpack
        }

        if(Input.GetKey(KeyCode.L)){
            Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        }
    }


     void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "ground"){
            isJumping = false;
            smoke.SetActive(false); // Desativar fumaca do jetpack
        }
    }
    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Coin"){
            GameController.current.AddScore(5);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag== "enemy"){
           GameController.current.GameOverPanel.SetActive(true);//painel gameover
           GameController.current.PlayerIsAlive = false;//moreu
           Destroy(gameObject);
        }
    }

    public void JumpBtn(){
         if(!isJumping){
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            isJumping = true;
            smoke.SetActive(true);// ativar fumaça do jetpack
        }
    }
    public void FireBtnc(){
           Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
    }
}
