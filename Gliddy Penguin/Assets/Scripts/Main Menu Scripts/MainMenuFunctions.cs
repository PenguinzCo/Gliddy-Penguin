using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void openInstructions()
    {
        SceneManager.LoadScene(2);
    }
    public void openSettings()
    {
        SceneManager.LoadScene(3);
    }
}
