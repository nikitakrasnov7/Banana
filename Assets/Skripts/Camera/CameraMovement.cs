using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float speed = 5f;

    private bool isMove = true;

    private void Update()
    {
        if (PlayerController.Instance.ActiveUpgrade == null)
        {
            if (Input.touchCount == 1)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 deltaPosition = touch.deltaPosition;

                Vector3 movement = new Vector3(deltaPosition.x, 0, 0).normalized * speed * Time.deltaTime;

                transform.Translate(movement, Space.World);
            }
        }

    }
}
