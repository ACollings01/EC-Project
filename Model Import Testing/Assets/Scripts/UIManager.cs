using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager uiManager;
    public GameObject inGameUI;
    public GameObject charCustUI;

    public GameObject equipmentUI;
    // Start is called before the first frame update
    void Start()
    {
        if (uiManager == null)
        {
            uiManager = this;
        }
        else if (uiManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // Function that handles input related to the UI rather than the player.
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!equipmentUI.activeSelf)
            {
                equipmentUI.SetActive(true);
            }
            else
            {
                equipmentUI.SetActive(false);
            }
        }
    }

    public void InGameScene()
    {
        charCustUI.SetActive(false);
        inGameUI.SetActive(true);
    }
}
