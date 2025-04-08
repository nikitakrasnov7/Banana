
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject PointForUpgrade;

    Vector3 offset;
    public bool isUsing = false;


    private void Update()
    {

        if (isUsing)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    if (PlayerController.Instance.ActiveUpgrade == null)
                    {

                        PlayerController.Instance.ActiveUpgrade = gameObject;

                    }
                }
                if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
                {
                    if (PlayerController.Instance.ActiveUpgrade != null)
                    {
                        if (PlayerController.Instance.ActiveUpgrade.gameObject.name == gameObject.name)
                        {
                            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(
                                                                          touch.position.x,
                                                                          touch.position.y,
                                                                          Camera.main.nearClipPlane +
                                                                          +Vector3.Distance(PlayerController.Instance.PlayerCar.transform.position, Camera.main.transform.position)

                                                                          ) + offset);
                            transform.position = newPosition;

                        }
                    }


                }

                if (touch.phase == TouchPhase.Ended)
                {
                    isUsing = false;
                    PlayerController.Instance.ActiveUpgrade = null;
                    //PointForUpgrade.SetActive(false);

                }
            }
        }

    }
}
