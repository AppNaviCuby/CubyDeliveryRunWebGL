using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeath : MonoBehaviour
{
    AudioController audioController;
    bool deathflag = false;
    // Start is called before the first frame update
    void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (deathflag)
        {

        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("death");
            audioController.DeathSound();
            StartCoroutine("DeathRetry");
            Time.timeScale = 0.0f;
        }
    }

    IEnumerator DeathRetry()
    {
        //3秒停止


        for (int i = 0; i < 30; i++) { yield return null; }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1.0f;
        yield break;
    }

}
