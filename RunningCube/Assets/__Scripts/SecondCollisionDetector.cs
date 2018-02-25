using UnityEngine;
using System.Collections;

// Second cube colision detector, not sure if its needed
// Script desorganizado, separar os scripts em menores e seus respectivos funcionamentos.
public class SecondCollisionDetector : MonoBehaviour {

    public Movement movement;
    //blink script
    public Material fadeMaterial;

    private Material originalMaterial;
    private Renderer blink;

    public float invencibleTime = 2f;
    public float blinkWait = 0.1f;

    private Coroutine lastBlinking;
    public bool isInvencible = true;
    //  
    //blink script
    private void Start()
    { 
        Fade();
        Invoke("StopInvencible",invencibleTime); //chama o metodo para desativar a invencibilidade em x segundos
    }

    //Ao colidir verifica se pe um obstaculo, desabilita o movimento e chama o metodo de gameover.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && isInvencible == false)
        {
            movement.isMoveEnable = false;
            FindObjectOfType<GameController>().GameOver(); //chama o metodo de restart pelo gamecontroller
        }
    }
    //Efeito piscando para feedback de invencibilidade
    void Fade()
    {
        blink = GetComponent<MeshRenderer>(); 
        originalMaterial = blink.material; //armazena o amterial original do objeto
        StartCoroutine(Blinking()); //inicia a rotina de piscar
    }

    IEnumerator Blinking()
    {
        blink.material = fadeMaterial; //aplica o material transparente no objeto
        yield return new WaitForSeconds(blinkWait); //aguarda x
        blink.material = originalMaterial; //aplica o original
        yield return new WaitForSeconds(blinkWait); //aguarda x
        yield return lastBlinking = StartCoroutine(Blinking()); //repete o processo, armazenando a ultima instancia de rotina para para-lá no metodo StopInvencible()
    }

    //Desabilita a invencibilidade, para a rotina do efeito de piscar.
    private void StopInvencible()
    {
        isInvencible = false;
        StopCoroutine(lastBlinking);
        blink.material = originalMaterial;
        
    }



}
