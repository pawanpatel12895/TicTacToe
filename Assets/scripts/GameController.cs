using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Text[] buttonList;
    public GameObject gameOverTextPanel;
    public Text gameOverText;

    private string playerSide;
    private int moveCount;

    public string GetPlayerSide() { return playerSide; }
    public void EndTurn()
    {
        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) GameOver();
        else if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) GameOver();
        else if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) GameOver();
        else if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) GameOver();
        else if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) GameOver();
        else if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) GameOver();
        else if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) GameOver();
        else if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) GameOver();

        else if (moveCount >= 9)
            setGameOverText("Draw!!!");
        ChangeSides();
    }
    public void restartGame()
    {
        moveCount = 0;
        playerSide = "X";
        setBoardInteractable(true);
        gameOverTextPanel.SetActive(false);

        for (int i = 0; i < buttonList.Length; i++)
        {   // set each button with empty string
            buttonList[i].text = "";
        }
    }

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }


    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }


    void GameOver()
    {
        setBoardInteractable(false);
        setGameOverText(playerSide + " Wins!!!"); 
    }
    void setGameOverText(string text) 
    {
        gameOverTextPanel.SetActive(true);
        gameOverText.text = text;
    }
    void setBoardInteractable(bool isInteractable)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = isInteractable;
        }
    }

    void Awake() 
    {
        SetGameControllerReferenceOnButtons();
        restartGame();
    }
}
