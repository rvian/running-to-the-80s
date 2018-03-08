using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void QuitApp()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
