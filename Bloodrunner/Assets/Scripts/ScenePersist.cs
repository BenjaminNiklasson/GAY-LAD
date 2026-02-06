using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    GameObject scenePersist;
    public Vector3 respawnPoint { get; set; }

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
