
using UnityEngine;
using UnityEngine.EventSystems;
public class DragDrop : MonoBehaviour, IDragHandler,IEndDragHandler,IBeginDragHandler{

    [SerializeField]
    private LerpConroler lerpConroler;
    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;
    private Vector3 StartPosition;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        StartPosition = rectTransform.position;
    }

    public void OnBeginDrag(PointerEventData eventData){
        lerpConroler.enabled = false;
    }
    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData){
        lerpConroler.enabled = true;
        lerpConroler.StartPos = rectTransform.position;
        lerpConroler.EndPos = StartPosition;
    }  
}
