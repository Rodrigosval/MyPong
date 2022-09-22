using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10f;
    public Image uiPlayer;
    public string playername;

    [Header("Key setup")]
    public KeyCode keyCodemoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;

    public Rigidbody2D myRigidbody2d;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playername = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }



    void Update()
    {
        if (Input.GetKey(keyCodemoveUp))
            myRigidbody2d.MovePosition(transform.position + transform.up * speed);
            //transform.Translate(transform.up * speed);
        else if (Input.GetKey(keyCodeMoveDown))
            myRigidbody2d.MovePosition(transform.position + transform.up * -speed);
            //transform.Translate(transform.up * speed * -1);
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        CheckMaxPoints();
        Debug.Log(currentPoints);
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }


    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints)
        {
            GameManager.Instance.EndGame();
            HighscoreManager.Instance.SavePlayerwin(this);
        }
    }
}
