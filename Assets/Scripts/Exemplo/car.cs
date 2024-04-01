using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public int speed = 20;
    public int gear = 5;

    public GameObject carPrefab;


    public int TotalSpeed
    {
        get { return speed * gear; } //busca um valor e retorna ele para a função
        //usado normalmente em conjunto com set -> atribui o valor de get a um elemento

    }

    public void CreateCar()
    {
        var a = Instantiate(carPrefab);
        a.transform.position = Vector3.zero;
    }

}
