using UnityEngine;
using UnityEngine.UI;

// Calcula todo Score do jogo, e apresenta na tela durante a partida e depois

public class Score : MonoBehaviour {

    public GameObject player;
    //private GameObject secondCube;

    public Color redScore;
    public Color yellowScore;
    public Color fadedScore;

    public Text scoreText;
    public Text fadedText;
    public Text endScoreText;
    public Text firstEndScoreText;
    public Text secondEndScoreText;

    private float firstScore;
    private float secondScore;
    private float endScore;

	void Update ()
    {
        if (player != null)
            FirstScore();
        else 
        if (GameObject.FindGameObjectWithTag("SecCube"))
            SecondScore();
        else
            scoreText.text = (firstScore+secondScore).ToString("0");
	}

    public void FirstScore()
    {
       // Calcula o tempo passado.
        firstScore = Time.timeSinceLevelLoad;

        scoreText.color = redScore;
        scoreText.text = firstScore.ToString("0");
    }

    public void SecondScore()
    {
       // Ativa o segundo contador de score (do cubo vermelho).
        fadedText.color = fadedScore;
        fadedText.text = firstScore.ToString("0");

       // Calcular o tempo do cubo ativo e dividi-lo por dois.
       // secondCube = GameObject.FindGameObjectWithTag("SecCube");
        secondScore = (Time.timeSinceLevelLoad - firstScore)/1.3f;

        scoreText.color = yellowScore;
        scoreText.text = secondScore.ToString("0");
    }
    public void ShowScore()
    {
        endScore = secondScore + firstScore;

        firstEndScoreText.text = firstScore.ToString("0");
        secondEndScoreText.text = secondScore.ToString("0");
        endScoreText.text = endScore.ToString("0");
    }
}
