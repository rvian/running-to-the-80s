using UnityEngine;

// Mantém a música tocando ao recarregar a cena.
// BUG: ao trocar de cena, a música da cena anterior continua a tocar.

// TODO: Checar se a cena atual mudou, se sim, destruir esse objeto.
public class AudioManager : MonoBehaviour
{
    GameObject musicPlayer;

    private void Awake()
    {
        // Singleton.
        musicPlayer = GameObject.FindGameObjectWithTag("GameMusic");
        if (musicPlayer == null)
        {
            gameObject.tag = "GameMusic";
            musicPlayer = gameObject;
            DontDestroyOnLoad(musicPlayer);
        }
        else if (musicPlayer != null)
        {
            Destroy(gameObject);
        }
    }
}
