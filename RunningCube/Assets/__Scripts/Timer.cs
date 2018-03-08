using UnityEngine;

public class Timer : MonoBehaviour {

    float timer;

	void Update () {
        timer += Time.deltaTime;
        Debug.Log(timer);
	}
}
