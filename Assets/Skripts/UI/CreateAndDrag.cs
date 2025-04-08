
using UnityEngine;
using UnityEngine.EventSystems;

public class CreateAndDrag : MonoBehaviour, IPointerClickHandler
{
    public GameObject Prefab;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject newPrefab = Instantiate(Prefab);
        Vector2 test = Camera.main.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        newPrefab.transform.position = new Vector3 (test.x, test.y, PlayerController.Instance.PlayerCar.transform.position.z);
    }


}
