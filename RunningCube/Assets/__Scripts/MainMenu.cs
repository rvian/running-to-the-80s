using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void InfiniteMode()
    {
        SceneManager.LoadScene("InfiniteMode");

    }
#if !UNITY_WEBGL
    public void QuitApp()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }
#endif
}
