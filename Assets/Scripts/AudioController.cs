using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    public List<AudioClip> soundList = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FoodGet()
    {
        audioSource.PlayOneShot(soundList[0]);
    }
    public void ItemGet()
    {
        audioSource.PlayOneShot(soundList[1]);
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(soundList[2], 0.2F);
    }

    public void ClearSound()
    {
        audioSource.PlayOneShot(soundList[3], 0.5f);
    }
}
