using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Menu : MonoBehaviour
{
    // save object
    public SaveObject saveObject;

    // buttons
    public Button newGameButton;
    public Button continueButton;
    public Button settingsButton;
    public Button exitButton;
    public Button quitButton;

    // events
    public UnityEvent newGame;
    public UnityEvent loadGame;
    public UnityEvent quitGame;
    public UnityEvent exitToWindows;
    // start a new game
    public void NewGame()
    {
        newGame.Invoke();
        if (GameController.gameController != null)
            GameController.gameController.NewGame();
    }

    // continue a game
    public void LoadGame()
    {
        loadGame.Invoke();
        if (GameController.gameController != null)
            GameController.gameController.StartGame();
    }

    // show settings menu
    public void Settings()
    {

    }
    
    // quit game
    public void QuitGame()
    {
        quitGame.Invoke();
        if (GameController.gameController != null)
            GameController.gameController.QuitGame();
    }

    // exit game
    public void ExitGame()
    {
        exitToWindows.Invoke();
        Application.Quit();
    }

	// Use this for initialization
	void Start () {
        if (saveObject != null && saveObject.hasSave)
        {
            continueButton.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
