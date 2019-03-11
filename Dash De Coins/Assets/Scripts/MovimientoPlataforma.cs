﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public GameObject coin;
    public GameObject puya;
    GameObject moneda;
    GameObject spike;
    int probMoneda;
  
    public static float aceleracion = 0.00000003f;
    public static float velocidad = -10;
    public bool Spikes = false;

    int intervalo = 1;
    float nextUpdate = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag != "Plataforma 90")
        {
            probMoneda = Random.Range(1, 5);
            if (probMoneda < 3 && !Spikes)
            {
                if (gameObject.GetComponent<SpriteRenderer>().flipY)
                {
                    moneda = Instantiate(coin, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.75f), Quaternion.identity);
                }
                else
                {
                    moneda = Instantiate(coin, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.75f), Quaternion.identity);
                }
                moneda.transform.parent = gameObject.transform;
                

            }
            if (Spikes)
            {
                if (gameObject.GetComponent<SpriteRenderer>().flipY)
                {
                    spike = Instantiate(puya, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.50f),Quaternion.identity);
                    spike.GetComponent<SpriteRenderer>().flipY = true;
                }
                else
                {
                    spike = Instantiate(puya, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 0.50f), Quaternion.identity);
                }
                spike.transform.parent = gameObject.transform;
                
            }
            //InvokeRepeating("Faster", 0, 1.0f);
        }
        
        
    }   
    private void FixedUpdate()
    {
        if(gameObject.tag == "Plataforma 90"){
            gameObject.transform.Translate(new Vector3(0,-velocidad) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);

            }
           // velocidad -= aceleracion * Time.time;

        }
        else if(gameObject.tag == "Plataforma Inversa")
        {
            gameObject.transform.Translate(new Vector3(velocidad, 0) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);

            }
          //  velocidad -= aceleracion * Time.time;
        }
        else
        {
            gameObject.transform.Translate(new Vector3(velocidad, 0) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);
                
            }
         //   velocidad -= aceleracion * Time.time;

        }
        if(Time.time >= nextUpdate)
        {
          velocidad -= aceleracion * Time.time;
            nextUpdate += intervalo;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Jugador.isOnPlat = true;
        }
    }
}
