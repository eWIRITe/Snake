using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.SceneManagement;

public class UiButtonScript : MonoBehaviour
{
    //esc buttons
    public GameObject EscPanel;
    public Scene StartScene;

    //Score
    public TMP_Text Text;
    public GameObject Player;

    //Loose screen
    public TMP_Text LooseScoreText;

    //i use this sckript two times. and at second time i do not need Update()
    public bool needUpdate;

    public void Update()
    {
        if (needUpdate)
        {
            //esc button
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Player.GetComponent<SnakeMoove>().isCanMoove = false;
                Time.timeScale = 0;
                EscPanel.SetActive(true);
            }

            //Score
            Text.text = Player.GetComponent<SnakeMoove>().BodyPices.Count.ToString();

            ScoreOnLooserScreen();
        }
    }

    public void OnReturnButton()
    {
        Player.GetComponent<SnakeMoove>().isCanMoove = true;
        Time.timeScale = 1;
        EscPanel.SetActive(false);
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void ToMenu()
    {
        Player.GetComponent<SnakeMoove>().isCanMoove = true;
        SceneManager.LoadScene(0);
    }

    public void ScoreOnLooserScreen()
    {
        LooseScoreText.text = Player.GetComponent<SnakeMoove>().BodyPices.Count.ToString();
    }

    public void OnAgainButton()
    {
        SceneManager.LoadScene(1);
    }
}
