using UnityEngine.EventSystems;
using UnityEngine;

public class CaroHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Material material;

    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SetHoverAmount(1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        SetHoverAmount(0);
    }

    private void SetHoverAmount(float value)
    {
        material.SetFloat("HoverAmount", value);
    }
}
