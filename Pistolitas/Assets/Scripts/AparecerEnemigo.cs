using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using TMPro;

public class AparecerEnemigo : MonoBehaviour
{

    public float maximoEnemigos;

    float contador = 15;

    public GameObject enemigo;

    public GameObject AvisoInicio;

    public GameObject AvisoFinal;

    public TextMeshProUGUI texto;

    float puntaje;

    public static AparecerEnemigo instancia = null;

    AudioSource source;

    public AudioClip[] sonidos;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }else if(instancia != gameObject)
        {
            Destroy(gameObject);
        }
       
    }

    void Start()
    {
        contador = maximoEnemigos;
        source = GetComponent<AudioSource>();
        puntaje = 0;
        texto.text = puntaje.ToString();
        StartCoroutine(AparicionObjetos());
        
    }

    
    public void Terminar()
    {
        AvisoFinal.SetActive(true);
        source.PlayOneShot(sonidos[2]);

    }
    public void AumentarPuntaje()
    {
        source.PlayOneShot(sonidos[1]);
        puntaje++;
        texto.text = puntaje.ToString();

        if(puntaje == maximoEnemigos)
        {
            Terminar();
        }
    }

    IEnumerator AparicionObjetos()
    {
        source.PlayOneShot(sonidos[0]);
        yield return new WaitForSeconds(1f);
        AvisoInicio.SetActive(false);
        while (contador > 0)
        {
            contador--;
            LeanPool.Spawn(enemigo,new Vector3(Random.Range(-6,6),Random.Range(-2.5f, 2.5f)),new Quaternion(0,0,0,0));
            yield return new WaitForSeconds(1f);
        }
    }
}
