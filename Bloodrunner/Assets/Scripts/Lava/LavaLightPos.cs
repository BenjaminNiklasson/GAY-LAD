using UnityEngine;

public class LavaLightPos : MonoBehaviour
{
    Transform _playerPos;

    private void Start()
    {
        _playerPos = GameObject.FindGameObjectWithTag("Globals").GetComponent<Globals>().currentPlayer.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_playerPos.position.x, transform.position.y, _playerPos.position.z);
    }
}
