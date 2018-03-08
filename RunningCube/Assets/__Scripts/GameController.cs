using UnityEngine;
using UnityEngine.SceneManagement;

// Controle das fases do jogo, pause, gameover, restart, exit etc.

public class GameController : MonoBehaviour {
    
    // Se o estiver sendo usado no infinite mode, ativar o bool.
    public bool isInfiniteMode = false;
    public GameObject gameWinUI;
    [HideInInspector]
    public Movement movement;
    bool gameIsOver = false;

    public void GameOver()
    {
        // Se o modo de jogo for level, reinicia o nivel apos 2 seg.
        if (gameIsOver == false && isInfiniteMode == false)
        {
            gameIsOver = true;
            movement.enabled = false;
            Invoke("Restart", 2f);
        }
        // Se o modo de jogo for infinito, mostra a UI com o score da partida.
        else if(gameIsOver == false && isInfiniteMode == true)
        {
            isInfiniteMode = false;
            movement.enabled = false;
            gameIsOver = true;
            GameWin();
        }
    } 

    public void GameWin()
    {
        gameWinUI.SetActive(true);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
