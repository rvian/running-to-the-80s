using UnityEngine;

// Mostra o Score na tela final.
public class ShowFinalScore : MonoBehaviour {
    
    public Score score;
    
    void Start ()
    {
        score.ShowScore();
	}
}
