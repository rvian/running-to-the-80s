using UnityEngine;

// Gerencia as cores dos textos de Score.
public class ScoreColorManager : MonoBehaviour {

    public Score score;
    public Color firstScore;
    public Color secondScore;
    public Color fadedScore;

    bool firstIsSet = false;

    private void Update()
    {
        if (score.player && firstIsSet == false)
        {
            firstIsSet = true;
            score.scoreText.color = firstScore;
        } else if(score.player == false &&
                  GameObject.FindGameObjectWithTag("SecCube"))
        {
            score.fadedText.color = fadedScore;
            score.scoreText.color = secondScore;
        }
    }
}
