using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Renderer meshRenderer;
    private float speed = 0.2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset  = offset + new Vector2 (speed * Time.deltaTime, 0);
        meshRenderer.material.mainTextureOffset = offset;

    }
}
