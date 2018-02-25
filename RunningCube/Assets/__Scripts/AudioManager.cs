using UnityEngine;
using UnityEngine.SceneManagement;

// Faz com que a musica n pare ao recarregar no nivel.
    
// BUG: ao trocar de scena, a musica da scena anterior continua a tocar.

public class AudioManager : MonoBehaviour
{
    GameObject musicPlayer;

    private void Awake()
    {
        // TODO: Check if the scene has changed. if true, then destroy this before AudioManager  
        // from the other scene load.
        musicPlayer = GameObject.FindGameObjectWithTag("GameMusic");
        if (musicPlayer == null)
        {
            gameObject.tag = "GameMusic";
            musicPlayer = gameObject;
            DontDestroyOnLoad(musicPlayer);
        }
        else
        if (musicPlayer != null)
                Destroy(gameObject);
    }
}
