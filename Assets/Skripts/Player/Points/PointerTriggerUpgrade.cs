using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerTriggerUpgrade : MonoBehaviour
{
    private GameObject ChildObjectUpgrade;
    int count = 0;

    bool iUsing;

    private void Start()
    {
        ChildObjectUpgrade = gameObject.transform.GetChild(0).gameObject;

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Upgrade")
        {
            if (count == 0)
            {
                if (!other.GetComponent<DragObject>().isUsing)
                {
                    if (other.GetComponent<DragObject>() != null)
                    {
                        gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        ChildObjectUpgrade.SetActive(true);
                        Destroy(other.gameObject);
                        count = 1;

                        PlayerController.Instance.isActiveNewUpgrade = false;
                        PlayerController.Instance.ActivationButtonStart();
                    }
                }

            }


        }
    }

}
