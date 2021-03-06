﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocidadeBala = 4.0f; // velocidade do tiro do canhão

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A bala se move na direção que está apontando
        transform.position += transform.up * Time.deltaTime * velocidadeBala;

    }

    void OnBecameInvisible()
    {
        // Bala é destruida ao sair da tela
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inimigo") // colisão com inimigo
        {
            collision.gameObject.GetComponent<inimigo>().tomaDano(10);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "obstaculo") // colisão com obstáculo
        {
            Destroy(gameObject);
        }
            
    }

}
