
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject RayObject;
    public GameObject PlayerCar;


    public List<TypeUpgrade> UpgradesList = new List<TypeUpgrade>();

    public GameObject ActiveUpgrade;
    public GameObject Ground;

    public bool isActiveNewUpgrade = false;

    public bool isGrounded;
    public Vector3 groundNormal;


    public WheelCollider RightFrontWheel;
    public WheelCollider RightBackWheel;

    public WheelCollider LeftFrontWheel;
    public WheelCollider LeftBackWheel;

    //UI
    public GameObject StartGameButton;


    private static PlayerController instance;
    public static PlayerController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<PlayerController>();
            }
            return instance;
        }
    }


    private void Update()
    {
        isGroundedWheel();
    }

    public void InstallingUpgrade(GameObject obj, Vector2 pointPosition)
    {
        obj.transform.position = pointPosition;
    }

    public void StartingFlyCamera()
    {
        PlayerCar.GetComponent<Rigidbody>().isKinematic = false;
        Rigidbody[] list = PlayerCar.transform.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < list.Length; i++)
        {
            list[i].isKinematic = false;
        }
        Camera.main.transform.parent.GetComponent<Animator>().SetTrigger("Start");
        StartGameButton.SetActive(false);
    }


    public void ActivationButtonStart()
    {
        StartGameButton.SetActive(true);
    }

    public void ChangingParametrsCar(int mass, int motor)
    {
        PlayerCar.GetComponent<Rigidbody>().mass = mass;

        RightBackWheel.motorTorque = motor;
        RightFrontWheel.motorTorque = motor;
        LeftBackWheel.motorTorque = motor;
        LeftFrontWheel.motorTorque = motor;
    }

    private void isGroundedWheel()
    {
        if (RightBackWheel.isGrounded &&
            LeftBackWheel.isGrounded)
        {
            Debug.Log("все колеса на земле");
        }
        else
        {

            ChangingParametrsCar(300, 0);
            Debug.Log(" не все колеса на земле");
        }
    }
}
