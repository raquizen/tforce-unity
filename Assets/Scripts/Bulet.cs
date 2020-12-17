using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
   public float Speed;
    void Start()
    {
       Destroy(gameObject, 2f);
    }
    void Update()
    {
        //movimentar a bala para a direita
        transform.Translate(Vector3.right * Speed * Time.deltaTime);
    }
}
