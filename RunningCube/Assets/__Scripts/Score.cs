using UnityEngine;
using UnityEngine.UI;

// Calcula o Score do jogo e apresenta na tela.
public class Score : MonoBehaviour {

    public GameObject player;
    public Text scoreText;
    public Text fadedText;
    public Text endScoreText;
    public Text firstEndScoreText;
    public Text secondEndScoreText;
    public float divFactor = 1.3f;

    private float firstScore;
    private float secondScore;
    private float endScore;

	void Update ()
    {
        // Se o avatar um estiver ativo, calcula o primeiro score.
        if (player)
        {
            FirstScore();
        }
        // Se o avatar dois estiver ativo, calcula o segundo score.
        else if (GameObject.FindGameObjectWithTag("SecCube"))
        {
            SecondScore();
        }
        // Se nenhum dos avatares estiver ativo, calcula o score final.
        else
        {
            scoreText.text = (firstScore + secondScore).ToString("0");
        }
	}

    public void FirstScore()
    {
        // Calcula o tempo passado.
        firstScore = Time.timeSinceLevelLoad;
        scoreText.text = firstScore.ToString("0");
    }

    public void SecondScore()
    {
       // Ativa o segundo contador de score (do cubo vermelho).
        fadedText.text = firstScore.ToString("0");
       // Calcular o tempo do cubo ativo e divide-o pelo fator.
        secondScore = (Time.timeSinceLevelLoad - firstScore)/divFactor;
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
