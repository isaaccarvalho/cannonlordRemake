using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canhao : MonoBehaviour
{

    public float velocidade = 1.5f; // velocidade do canhao
    public float alcance = 45; // alcance do giro do canhão, em graus
    public int totalBalas = 5; // total de balas do canhão
    public int balas = 5; // balas do canhão
    public float taxaDeTiros = 0.2f; // tempo de espera para dar o próximo tiro
    public float tempoRecarga = 1f; // tempo de espera para recarregar o canhão

    private float proximoTiro = 0.0f;

    public GameObject canoCanhao; // cano do canhao que irá girar
    public GameObject ponta; // localizacao da ponta do cano do canhao, de onde sairá o tiro
    public GameObject numBalasTxt; // Componente UI para mostrar quantidadde de balas
    public GameObject btnRecarregar; // botão de recarregar o canhao
    public GameObject btnAtirar; // botão para atirar o canhão

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gira();
    }

    void gira()
    {
        float angulo = Mathf.Sin(Time.time * velocidade) * alcance;
        canoCanhao.transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
    }

    public void atira()
    {
        if(balas>0 && Time.time > proximoTiro)
        {
            proximoTiro = Time.time + taxaDeTiros;
            balas--;
            numBalasTxt.GetComponent<Text>().text = balas.ToString();
        }
        
    }

    public void recarregar()
    {
        if (balas < totalBalas)
        {
            btnRecarregar.GetComponent<Button>().interactable = false;
            btnAtirar.GetComponent<Button>().interactable = false;
            Invoke("recarrega", tempoRecarga);
            
        }
    }

    private void recarrega()
    {
        btnAtirar.GetComponent<Button>().interactable = true;
        btnRecarregar.GetComponent<Button>().interactable = true;
        balas = totalBalas;
        numBalasTxt.GetComponent<Text>().text = balas.ToString();
    }
}
