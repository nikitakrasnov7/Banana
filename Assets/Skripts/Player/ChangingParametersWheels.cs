using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingParametersWheels : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Testing")
        {
            PlayerController.Instance.ChangingParametrsCar(600, 550);
        }
    }
}
