using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	Light lightSource;
    // Start is called before the first frame update
    void Start()
    {
		gameObject.AddComponent<Light>();
		lightSource = gameObject.GetComponent<Light>();
		lightSource.enabled = false;
		lightSource.transform.position = new Vector3(lightSource.transform.position.x, lightSource.transform.position.y + 0.5f, lightSource.transform.position.z);
		lightSource.intensity = 0.3f;
		lightSource.color = Color.grey;
    }

	private void OnMouseEnter()
	{
		lightSource.enabled = true;
		Debug.Log("Mouse has entered object space");
	}

	private void OnMouseExit()
	{
		lightSource.enabled = false;
		Debug.Log("Mouse has left object space");
	}
}
