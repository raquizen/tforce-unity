using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{
    public GameObject Platform; //plataforma
    public Transform point; // ponto onde acaba a camera
    public float Distance;// distancia entre as plataformas
    private  float platformWidth; // tamanho da plataforma
    void Start()
    {
        if(Platform.GetComponent<BoxCollider2D>()){
            //pegando o tamanho do coliser
            platformWidth = Platform.GetComponent<BoxCollider2D>().size.x;
        }
        else{
            //pegando o tamanho do coliser com formas diferentes
            platformWidth = Platform.GetComponent<PolygonCollider2D>().bounds.size.x;
        }
        
    }

    
    void Update()
    {
        //logica para gerar plataformas //  se o objeto estiver fora da camera
        if(transform.position.x < point.position.x){

            Distance = Random.Range(3f, 8f);

            //gera nova plataforma
            transform.position = new Vector3(transform.position.x + platformWidth + Distance, transform.position.y, transform.position.z);

            // instanciando nova plataforma na cena
            Instantiate(Platform, transform.position, transform.rotation);
        }
    }
}
