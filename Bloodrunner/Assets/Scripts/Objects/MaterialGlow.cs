using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MaterialGlow : MonoBehaviour
{
    [SerializeField] float _glowDivider;
    Renderer _renderer;
    Material _material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _material = _renderer.material;
        _renderer.material = _material;
    }

    // Update is called once per frame
    void Update()
    {
        _material.SetColor("_EmissionColor", _material.color * (_glowDivider / (transform.position.y - GameObject.FindGameObjectWithTag("Lava").transform.position.y)));
    }
}
