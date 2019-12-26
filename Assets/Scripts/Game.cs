using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public GameObject pontuacao; // elemento da UI da pontuação
    public GameObject btnRecarregar; // botão de recarregar o canhao
    public GameObject btnAtirar; // botão para atirar o canhão
    public GameObject inimigo; // prefab o inimigo para instanciar
    public GameObject btnIniciarPausar; // botão de pause e play do jogo
    public GameObject canhao; // objeto canhao para desativa ou ativar quando pausar
    public GameObject iniciarSprite, pausarSprite, jogoPausadoTxt;


    public float tempoSpawnInimigo = 4f; // intervalo em que cada inimigo é instanciado
    private float tempoSpawn = 0.0f; // variavel auxiliar, tempo em que irá ser instanciado
    private float pontos = 0;

    public bool pausado = true;
    // Start is called before the first frame update
    void Start()
    {
        pausa();
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
        pontos = 0;
        pontua(0);
    }

    public void inicia()
    {
        
        btnAtirar.GetComponent<Button>().interactable = true;
        btnRecarregar.GetComponent<Button>().interactable = true;
        canhao.GetComponent<canhao>().ativa();
        pausarSprite.SetActive(true);
        iniciarSprite.SetActive(false);
        jogoPausadoTxt.SetActive(false);
        pausado = false;
        Time.timeScale = 1;



    }

    public void pausa()
    {
        btnRecarregar.GetComponent<Button>().interactable = false;
        btnAtirar.GetComponent<Button>().interactable = false;
        canhao.GetComponent<canhao>().desativa();
        pausarSprite.SetActive(false);
        iniciarSprite.SetActive(true);
        jogoPausadoTxt.SetActive(true);
        pausado = true;
        Time.timeScale = 0;

    }

    public void pontua(float qtd)
    {
        pontos += qtd;
        pontuacao.GetComponent<Text>().text = pontos.ToString();
    }

    public void iniciarPausarBtn()
    {
        if(pausado)
        {
            inicia();
        } else
        {
            pausa();
        }
    }
}
