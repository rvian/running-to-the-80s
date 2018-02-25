using UnityEngine;

public class ShowFinalScore : MonoBehaviour {

    // Show the final score after infinite mode ends.

    public Score score;
    
    void Start ()
    {
        score.ShowScore();
	}
}
