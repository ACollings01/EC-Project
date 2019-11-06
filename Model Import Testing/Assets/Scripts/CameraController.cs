using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float maxZoom = 30;
    private float zoom;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerModel");
    }

    // Update is called once per frame
    void Update()
    {
        AdjustZoom(Input.mouseScrollDelta.y);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 18, player.transform.position.z - 10);
        transform.LookAt(player.transform);

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - zoom, transform.localPosition.z + zoom);
    }

    void AdjustZoom(float amount)
    {
        // Adjusting zoom variable
        if (amount > 0 && zoom < maxZoom)
        {
            zoom += amount;
        }
        else if (amount < 0 && zoom > 1)
        {
            zoom += amount;
        }

        // Checking that zoom hasn't gone past bounds
        zoom = zoom > maxZoom ? maxZoom : zoom;
        zoom = zoom < 1 ? 1 : zoom;
    }
}
