using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class MaterialGlow : MonoBehaviour
{
    [SerializeField] float _glowDivider;
    Renderer _renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _renderer = gameObject.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
        DynamicGI.SetEmissive(_renderer, _renderer.material.color / ((transform.position.y - GameObject.FindGameObjectWithTag("Lava").transform.position.y)*_glowDivider));
    }
}
