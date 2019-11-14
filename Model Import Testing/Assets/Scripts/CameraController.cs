using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private float maxZoom = 8.0f;
	private float zoom = 0.0f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerModel");

		transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 18, player.transform.position.z - 10);
		transform.LookAt(player.transform);
	}

    // Update is called once per frame
    void Update()
    {
        AdjustZoom(Input.mouseScrollDelta.y);
		ConstrainZoom();
        transform.localPosition = new Vector3(player.transform.position.x, player.transform.position.y + 18 - (1.8f * zoom), player.transform.position.z - 10 + zoom);
		transform.LookAt(player.transform);
	}

	void AdjustZoom(float amount)
	{
		if ((zoom < maxZoom && amount > 0) || (zoom > 0 && amount < 0))
		{
			zoom += amount;
		}
	}

	void ConstrainZoom()
	{
		zoom = zoom > maxZoom ? maxZoom : zoom;
		zoom = zoom < 0 ? 0 : zoom;
	}
}