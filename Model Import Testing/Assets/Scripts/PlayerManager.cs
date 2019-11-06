using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerManager playerManager;
 
    // Basically just ensures that the player is in every scene and is the same between scenes

    // Start is called before the first frame update
    void Start()
    {
        if (playerManager == null)
        {
            playerManager = this;
        }
        else if (playerManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
