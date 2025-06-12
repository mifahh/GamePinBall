using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUIController : MonoBehaviour
{
    public Button MainMenuButton;

    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton.onClick.AddListener(BackToMainMenu);
    }

    // Update is called once per frame
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
