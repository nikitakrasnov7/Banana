
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class Ray : MonoBehaviour
{



    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            UnityEngine.Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;


            if (Physics.Raycast(ray, out hit))
            {

                if (hit.collider.GetComponent<DragObject>() != null)
                {
                    hit.collider.GetComponent<DragObject>().isUsing = true;
                }

            }

            //Debug.Log(hit.collider.tag);


        }
    }
}
