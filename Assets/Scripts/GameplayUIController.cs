using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay"); // or we can write LoadScene(SceneManager.GetActiveScene().name)
    }
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
