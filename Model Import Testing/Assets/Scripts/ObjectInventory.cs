using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectInventory : MonoBehaviour
{
	private Light lightSource;
	public Item[] items;
	private GameObject player;
	float clickDistance = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
		gameObject.AddComponent<Light>();
		lightSource = gameObject.GetComponent<Light>();
		lightSource.enabled = false;
		lightSource.transform.position = new Vector3(lightSource.transform.position.x, lightSource.transform.position.y + 0.5f, lightSource.transform.position.z);
		lightSource.intensity = 0.3f;
		lightSource.color = Color.grey;

		player = GameObject.FindGameObjectWithTag("PlayerModel");
    }

	private void OnMouseEnter()
	{
		lightSource.enabled = true;
		Debug.Log("Mouse has entered object space");
	}

	private void OnMouseOver()
	{
		if (Vector3.Distance(gameObject.transform.position, player.transform.position) < clickDistance && Input.GetButtonDown("Fire1"))
		{
			OpenLocalInventory();
		}
	}

	private void OnMouseExit()
	{
		lightSource.enabled = false;
		Debug.Log("Mouse has left object space");
	}

	void OpenLocalInventory()
	{
		UIManager.uiManager.OpenExternalInventory(items);
	}
}
