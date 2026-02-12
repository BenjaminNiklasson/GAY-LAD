using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    ScenePersist scenePersist;
    public AudioSource audioSource;

    public bool musicOn = true;
    public UIManager UIManager;
   

    public void PlayMusic()
    {
        audioSource.Play();
    }
    public void StopMusic()
    {
        audioSource.Stop();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scenePersist = GameObject.FindGameObjectWithTag("ScenePersist").GetComponent<ScenePersist>();
        if (scenePersist.musicCheck)
        {
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
