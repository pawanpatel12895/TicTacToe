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

    void SetGameControllerReferenceOnButtons()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide() { return playerSide; }
    void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
    public void EndTurn() {

        moveCount++;
        if (buttonList[0].text == playerSide && buttonList[1].text == playerSide && buttonList[2].text == playerSide) GameOver();
        if (buttonList[3].text == playerSide && buttonList[4].text == playerSide && buttonList[5].text == playerSide) GameOver();
        if (buttonList[6].text == playerSide && buttonList[7].text == playerSide && buttonList[8].text == playerSide) GameOver();
        if (buttonList[0].text == playerSide && buttonList[3].text == playerSide && buttonList[6].text == playerSide) GameOver();
        if (buttonList[1].text == playerSide && buttonList[4].text == playerSide && buttonList[7].text == playerSide) GameOver();
        if (buttonList[2].text == playerSide && buttonList[5].text == playerSide && buttonList[8].text == playerSide) GameOver();
        if (buttonList[0].text == playerSide && buttonList[4].text == playerSide && buttonList[8].text == playerSide) GameOver();
        if (buttonList[2].text == playerSide && buttonList[4].text == playerSide && buttonList[6].text == playerSide) GameOver();

        if (moveCount >= 9)
            setGameOverText("Draw!!!");
        ChangeSides();
    }
    void GameOver()
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = false;
        }
        setGameOverText(playerSide + " Wins!!!"); 
    }
    void setGameOverText(string text) {

        gameOverTextPanel.SetActive(true);
        gameOverText.text = text;
    }
    void resetGame() {
        playerSide = "X";
        gameOverTextPanel.SetActive(false);
        moveCount = 0;
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = true;
            buttonList[i].text = "";
        }
    }
    void Awake() {
        SetGameControllerReferenceOnButtons();
        resetGame();
    }
}
