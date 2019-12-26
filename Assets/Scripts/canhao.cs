using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canhao : MonoBehaviour
{

    public float velocidade = 1.5f; // velocidade do canhao
    public float alcance = 45; // alcance do giro do canhão, em graus
    public int balas = 5; // balas do canhão

    public GameObject canoCanhao; // cano do canhao que irá girar

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

    void atira()
    {
        if(balas>0)
        {
            balas--;
        }
        
    }
}
