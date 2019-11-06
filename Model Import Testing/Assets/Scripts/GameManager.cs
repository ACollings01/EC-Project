using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameManager gameManager;

    private GameObject player;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
        else if (gameManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("PlayerModel");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            Debug.Log("Strength: " + playerController.GetSTR());
            Debug.Log("Dexterity: " + playerController.GetDEX());
            Debug.Log("Constitution: " + playerController.GetCON());
            Debug.Log("Intelligence: " + playerController.GetINT());
            Debug.Log("Wisdom: " + playerController.GetWIS());
            Debug.Log("Charisma: " + playerController.GetCHA());
        }
    }

    public void GoToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
