using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class MatarEnemigo : MonoBehaviour
{
    //public AparecerEnemigo aparecer;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    private void OnMouseDown()
    {
        AparecerEnemigo.instancia.AumentarPuntaje();
        //aparecer.AumentarPuntaje();
        LeanPool.Despawn(gameObject);
        
    }


}
