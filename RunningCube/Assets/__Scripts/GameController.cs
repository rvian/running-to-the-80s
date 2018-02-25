using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/*
 * Controle das fases do jogo, pause, gamever, restart, exit etc.
 * */

public class GameController : MonoBehaviour {
    bool gameIsOver = false;

    public bool isInfiniteMode = false;

    public GameObject gameWinUI;
   // public GameObject infiniteWinUI;


	public void GameOver()
    {
        if (gameIsOver == false && isInfiniteMode == false) //just wanna do this on level mode
        {
            gameIsOver = true;
            Invoke("Restart", 2f);
        } else if(isInfiniteMode == true)
        {
            isInfiniteMode = false;
            gameIsOver = true;
            GameWin();
        }
    } 

    public void GameWin() //level pass
    {
        gameWinUI.SetActive(true);
    }

    /*
    public void InfiniteWin() //done infinte mode, collided with something.
    {
        gameWinUI.SetActive(true);
    }*/

     public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
