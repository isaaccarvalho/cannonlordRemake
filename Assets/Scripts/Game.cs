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
    public GameObject iniciarSprite, pausarSprite, jogoPausadoTxt; // Elementos da UI
    public GameObject obstaculo; // Obstaculos do jogo


    public float tempoSpawnInimigo = 4f; // intervalo em que cada inimigo é instanciado
    private float tempoSpawn = 0.0f; // variavel auxiliar, tempo em que irá ser instanciado
    private float pontos = 0;

    public bool iniciado = false;
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

            // Instancia aleatoriamente os inimigos numa posição x entre -7 e 7
            int x = Random.Range(-7, 7);
            Vector3 posicaoSpawn = new Vector3(x, transform.position.y, 0);
            Instantiate(inimigo, posicaoSpawn, gameObject.transform.rotation);
        }
    }

    public void reiniciar()
    {
        // É chamado pelo Botão na UI
        // Destruir os objetos instanciados, restaurar as balas do canhão, zerar os pontos e pausar o jogo
        pausa();
        canhao.GetComponent<canhao>().recarrega();
        pontos = 0;
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("inimigo");
        foreach (GameObject obj in inimigos)
        {
            Destroy(obj);
        }
        GameObject[] obstaculos = GameObject.FindGameObjectsWithTag("obstaculo");
        foreach (GameObject obj in obstaculos)
        {
            Destroy(obj);
        }
        GameObject[] balas = GameObject.FindGameObjectsWithTag("bala");
        foreach (GameObject obj in balas)
        {
            Destroy(obj);
        }
        btnRecarregar.GetComponent<Button>().interactable = false;
        btnAtirar.GetComponent<Button>().interactable = false;
        iniciado = false;
        pontuacao.GetComponent<Text>().text = "0";
    }

    public void inicia()
    {
        if(!iniciado) // Instanciar os Obstaculos
        {
            iniciado = true;
            Instantiate(obstaculo, new Vector3(-4.5f, 0.15f, 0), transform.rotation);
            Instantiate(obstaculo, new Vector3(0.4f, 3.5f, 0), transform.rotation);
            Instantiate(obstaculo, new Vector3(5.3f, -0.8f, 0), transform.rotation);
        }
        // Ativar os botões de atirar e recarregar, ativar o canhão, mudar o icone do botão de play para pause.
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
        // Desativar os botões de atirar e recarregar, desativar o canhão, mudar o icone do botão de pause para play
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
        // Adiciona a quantidae de pontos a variável e muda o placar
        pontos += qtd;
        pontuacao.GetComponent<Text>().text = pontos.ToString();
    }

    public void iniciarPausarBtn()
    {
        // É chamado pelo Botão na UI
        // Mulltipla Função do botão Pausar/Iniciar
        if (pausado)
        {
            inicia();
        } else
        {
            pausa();
        }
    }
}
