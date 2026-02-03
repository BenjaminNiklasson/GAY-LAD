using UnityEngine;

public class LavaLightRot : MonoBehaviour
{
    Transform _playerPos;

    private void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>().currentPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_playerPos);
    }
}
