using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    private Vector3 offset = new Vector3(8, 2, -18);
    public GameObject player;
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        transform.position = player.transform.position + offset; //Para la posici�n de la c�mara le sumamos a la posici�n del Player el vector 50,5,0, as� segu�r� al Player a cierta distancia.
    }

}
