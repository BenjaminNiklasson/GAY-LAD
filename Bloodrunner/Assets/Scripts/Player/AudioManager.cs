using UnityEngine;

public class AudioManager : MonoBehaviour
{
    ScenePersist scenePersist;
    public AudioSource audioSource;

    public bool musicOn = true;

    public void MusicToggleOn()
    {
        musicOn = true;
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (musicOn == true)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
