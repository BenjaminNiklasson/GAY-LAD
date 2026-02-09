using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    GameObject scenePersist;
    public Vector3 respawnPoint { get; set; }
    public int deaths { get; set; } = 0;

    private void Awake()
    {
        if (scenePersist == null)
        {
            scenePersist = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
