using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExercicioDeIf : MonoBehaviour
{

    string txt;
    int number = 5;


    void Start()
    {

        txt = CheckNumber (number);
        Debug.Log(txt);


    }

    string CheckNumber(int number)
    {
        if (number % 2 == 0)
        {
            txt = "n�mero par";
        }

        else 
        {
            txt = "n�mero impar";
        }

        return txt;
    }
}
