using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string keyToSave = "keyHighscore";

    [Header("References")]
    public TextMeshProUGUI uiTextHighscore;


    public void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        updateText();
    }

    private void updateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(keyToSave, "Sem highscore");
    }

    public void SavePlayerwin(Player p)
    {
        if (p.playername == "") return;
        PlayerPrefs.SetString(keyToSave, p.playername);
        updateText();
    }
}
