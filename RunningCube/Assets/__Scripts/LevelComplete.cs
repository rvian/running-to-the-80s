using UnityEngine.SceneManagement;
using UnityEngine;

// Carrega o próximo nivel, as cenas tem que estar em ordem no build index, finalizando
// o conjunto de niveis com a cena 'creditos'.

public class LevelComplete : MonoBehaviour {
	public void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
