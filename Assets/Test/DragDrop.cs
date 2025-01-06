using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class DragDrop : MonoBehaviour, IDragHandler,IEndDragHandler,IBeginDragHandler{

    [SerializeField]
    private Canvas canvas;
    private RectTransform rectTransform;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData Data){

    }
    public void OnDrag(PointerEventData Data){
        rectTransform.anchoredPosition += Data.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData Data){

    }
}
