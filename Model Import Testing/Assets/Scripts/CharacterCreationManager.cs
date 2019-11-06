using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationManager : MonoBehaviour
{
    private IDictionary<string, int> stats = new Dictionary<string, int>();

    private GameObject player;
    private PlayerController playerController;

    private int statsTotal;
    private int maxStats = 70;

    public UnityEngine.UI.Text STRText;
    public UnityEngine.UI.Text DEXText;
    public UnityEngine.UI.Text CONText;
    public UnityEngine.UI.Text INTText;
    public UnityEngine.UI.Text WISText;
    public UnityEngine.UI.Text CHAText;
    public UnityEngine.UI.Text pointsLeft;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("PlayerModel");
        playerController = player.GetComponent<PlayerController>();

        // Default all stats to 10
        stats["strength"] = 10;
        stats["dexterity"] = 10;
        stats["constitution"] = 10;
        stats["intelligence"] = 10;
        stats["wisdom"] = 10;
        stats["charisma"] = 10;
        
        // Set the pointsLeft text color to black to match the rest of the stat text
        pointsLeft.color = Color.black;
    }

    private void Update()
    {
        statsTotal = stats["strength"] + stats["dexterity"] + stats["constitution"] + stats["intelligence"] + stats["wisdom"] + stats["charisma"];
        UpdateStatText();
        UpdateStats();
    }

    // Called when a + button is hit in relation to stats
    public void IncrementStat(string stat)
    {
        if (statsTotal < maxStats && stats[stat] < 18)
        {
            stats[stat]++;
        }
    }

    // Called when the - button is hit in relation to stats
    public void DecrementStat(string stat)
    {
        if (stats[stat] > 6)
        {
            stats[stat]--;
        }
    }

    private void UpdateStatText()
    {
        // Update the points left text for players
        pointsLeft.text = "Points Left: " + (maxStats - statsTotal);

        // Updates all text with new values
        STRText.text = "STR:\t" + stats["strength"];
        DEXText.text = "DEX:\t" + stats["dexterity"];
        CONText.text = "CON:\t" + stats["constitution"];
        INTText.text = "INT:\t\t" + stats["intelligence"];
        WISText.text = "WIS:\t\t" + stats["wisdom"];
        CHAText.text = "CHA:\t" + stats["charisma"];

        foreach (System.Collections.Generic.KeyValuePair<string, int> stat in stats)
        {
            if (stat.Value == 18 && stat.Key == "strength")
            {
                STRText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "strength")
            {
                STRText.color = Color.red;
            }
            else if (stat.Key == "strength")
            {
                STRText.color = Color.black;
            }
            else if (stat.Value == 18 && stat.Key == "dexterity")
            {
                DEXText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "dexterity")
            {
                DEXText.color = Color.red;
            }
            else if (stat.Key == "dexterity")
            {
                DEXText.color = Color.black;
            }
            else if (stat.Value == 18 && stat.Key == "constitution")
            {
                CONText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "constitution")
            {
                CONText.color = Color.red;
            }
            else if (stat.Key == "constitution")
            {
                CONText.color = Color.black;
            }
            else if (stat.Value == 18 && stat.Key == "intelligence")
            {
                INTText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "intelligence")
            {
                INTText.color = Color.red;
            }
            else if (stat.Key == "intelligence")
            {
                INTText.color = Color.black;
            }
            else if (stat.Value == 18 && stat.Key == "wisdom")
            {
                WISText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "wisdom")
            {
                WISText.color = Color.red;
            }
            else if (stat.Key == "wisdom")
            {
                WISText.color = Color.black;
            }
            else if (stat.Value == 18 && stat.Key == "charisma")
            {
                CHAText.color = Color.green;
            }
            else if (stat.Value == 6 && stat.Key == "charisma")
            {
                CHAText.color = Color.red;
            }
            else if (stat.Key == "charisma")
            {
                CHAText.color = Color.black;
            }
        }
    }

    private void UpdateStats()
    {
        // Updates the stats in the player object
        playerController.SetSTR(stats["strength"]);
        playerController.SetDEX(stats["dexterity"]);
        playerController.SetCON(stats["constitution"]);
        playerController.SetINT(stats["intelligence"]);
        playerController.SetWIS(stats["wisdom"]);
        playerController.SetCHA(stats["charisma"]);
    }
}
