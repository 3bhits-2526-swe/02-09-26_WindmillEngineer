using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Muss public sein, damit der Button sie im Inspector sehen kann
    public static void LoadGameScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGame() 
    {
        Application.Quit(); 
        Debug.Log("Spiel wurde beendet!"); 
    }
}