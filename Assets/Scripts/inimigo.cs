using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float velocidade = 1f; // velocidade do inimigo
    public float vida = 10f; // quantidade de vida do inimigo

    private bool right = true; // a direção que o morcego está se movendo
    private bool ativo = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameObject.Find("GameController").GetComponent<Game>().pausado)
        {
            move();

        }
        
        
    }

    public void tomaDano(float dano)
    {
        vida -= dano;
        if(vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (!GameObject.Find("GameController").GetComponent<Game>().pausado)
        {
            GameObject.Find("GameController").GetComponent<Game>().pontua(10);
        }
    }

    private void move()
    {
        if (transform.position.x > 7.7) // se o inimigo chegar ao canto da tela muda a direção
        {
            right = false;
        }
        else if (transform.position.x < -7.7)
        {
            right = true;
        }

        if (right) // Andar para baixo e para a direita
        {
            transform.position += (transform.up * Time.deltaTime * -0.2f * velocidade) + (transform.right * Time.deltaTime * 1.5f * velocidade);
        }
        else // Andar para baixo e para a esquerda
        {
            transform.position += (transform.up * Time.deltaTime * -0.2f * velocidade) + (transform.right * Time.deltaTime * -1.5f * velocidade);
        }
    }

}
