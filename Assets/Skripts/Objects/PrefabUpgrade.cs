using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PrefabUpgrade : MonoBehaviour, IPointerDownHandler
{
    public GameObject prefab;
    private GameObject newObject;

    private GameObject parent;

    public GameObject PointForUpgrade;

    private void Start()
    {
        if (parent == null)
        {
            parent = FindAnyObjectByType<ListUpgrade>().gameObject;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector2 globalPosition = Camera.main.ScreenToWorldPoint(
            new Vector2(eventData.position.x,
            eventData.position.y
            ));


        if (!PlayerController.Instance.UpgradesList.Contains(prefab.GetComponent<TypeObject>().typeUpgrade))
        {
            if (!PlayerController.Instance.isActiveNewUpgrade)
            {
                GameObject newObj = Instantiate(
                                original: prefab,
                                position: new Vector3(globalPosition.x + 1.5f, globalPosition.y, PlayerController.Instance.PlayerCar.transform.position.z),
                                rotation: Quaternion.identity,
                                parent: parent.gameObject.transform
                                );



                newObj.transform.GetChild(0).gameObject.AddComponent<DragObject>().PointForUpgrade = PointForUpgrade;
                PointForUpgrade.SetActive(true);

                PlayerController.Instance.UpgradesList.Add(prefab.GetComponent<TypeObject>().typeUpgrade);
                PlayerController.Instance.isActiveNewUpgrade = true;
            }


        }






    }

}
