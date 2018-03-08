using UnityEngine;
using System.Collections;

// Efeito de piscar para feedback de invencibilidade.
public class Blink : MonoBehaviour {

    public bool isInvencible;

    public Material fadeMaterial;
    public float invencibleTime = 2f;
    public float blinkWait = 0.1f;

    private Material originalMaterial;
    private Renderer blink;
    private Coroutine lastBlinking;

    private void Start()
    {
        isInvencible = true;
        Fade();
        // Chama a rotina para desativar a invencibilidade em x segundos.
        Invoke("StopInvencible", invencibleTime);
    }


    void Fade()
    {
        blink = GetComponent<MeshRenderer>();
        // Armazena o material original do objeto.
        originalMaterial = blink.material;
        // Inicia a rotina de piscar.
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        blink.material = fadeMaterial; 
        yield return new WaitForSeconds(blinkWait); 
        blink.material = originalMaterial; 
        yield return new WaitForSeconds(blinkWait); 
        yield return lastBlinking = StartCoroutine(Blinking());
    }

    // Desabilita a invencibilidade, para a rotina do efeito de piscar.
    private void StopInvencible()
    {
        isInvencible = false;
        StopCoroutine(lastBlinking);
        blink.material = originalMaterial;
    }
}
