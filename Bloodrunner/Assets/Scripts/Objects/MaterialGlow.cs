using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MaterialGlow : MonoBehaviour
{
    [SerializeField] float _glowDivider;
    [SerializeField] Color _emissionColor;
    Renderer _renderer;
    Material _material;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer = gameObject.GetComponent<Renderer>();
        _material = _renderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        DynamicGI.SetEmissive(_renderer, _material.color * ((transform.position.y - GameObject.FindGameObjectWithTag("Lava").transform.position.y) / _glowDivider));

    }
}
