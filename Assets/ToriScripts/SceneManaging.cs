using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void MainGame()
    {
        SceneManager.LoadScene("Exportable");
    }

    public void Win() 
    {
        SceneManager.LoadScene("win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void Defeat()
    {
        SceneManager.LoadScene("Defeat");
    }
}
