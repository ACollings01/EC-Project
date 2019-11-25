using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIObject : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta;
    }

	public void Close()
	{
		gameObject.SetActive(false);
	}
}
