using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public GameObject pontuacao; // elemento da UI da pontuação
    public GameObject inimigo; // prefab o inimigo para instanciar

    public float tempoSpawnInimigo = 4f; // intervalo em que cada inimigo é instanciado
    private float tempoSpawn = 0.0f; // variavel auxiliar, tempo em que irá ser instanciado
    private float pontos = 0;

    public bool pausado = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > tempoSpawn && !pausado)
        {
            tempoSpawn = Time.time + tempoSpawnInimigo;

            // Spawn
            int x = Random.Range(-7, 7);
            Vector3 posicaoSpawn = new Vector3(x, transform.position.y, 0);
            Instantiate(inimigo, posicaoSpawn, gameObject.transform.rotation);
        }
    }

    public void reiniciar()
    {
        pausa();
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("inimigo");
        foreach (GameObject obj in inimigos)
        {
            Destroy(obj);
        }
    }

    public void inicia()
    {
        pausado = false;
        GameObject.Find("Canhao").GetComponent<canhao>().enabled = true;
        GameObject.Find("Bala").GetComponent<bala>().enabled = true;
    }

    public void pausa()
    {
        pausado = true;
        GameObject.Find("Canhao").GetComponent<canhao>().enabled = false;
        GameObject.Find("Bala").GetComponent<bala>().enabled = false;
    }

    public void pontua(float qtd)
    {
        pontos += qtd;
        pontuacao.GetComponent<Text>().text = pontos.ToString();
    }
}
