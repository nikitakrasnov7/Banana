using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWeels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<WheelCollider>().motorTorque = 10f;
    }

    // Update is called once per frame
    void Update()
    {




    }
}
