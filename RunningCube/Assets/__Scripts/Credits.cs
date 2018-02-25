using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void QuitApp()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void MainMenu()
    {
        Debug.Log("MainMenu");

        SceneManager.LoadScene(00);
    }
}
