using System.Collections;
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
        transform.position += transform.up * Time.deltaTime * velocidadeBala;

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "inimigo" || collision.gameObject.tag == "obstaculo")
        {
            Destroy(gameObject);
        }
        Debug.Log("colidiu");
    }

}
