using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LargeMapPointer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Camera miniMapCam;
    [SerializeField] private GameObject confirmHolder;

    public static LargeMapPointer Instance;
    public int ID;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        Instance = this;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 cursor = new Vector2(0, 0);

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(GetComponent<RawImage>().rectTransform,
            eventData.pressPosition, eventData.pressEventCamera, out cursor))
        {

            Texture texture = GetComponent<RawImage>().texture;
            Rect rect = GetComponent<RawImage>().rectTransform.rect;

            float coordX = Mathf.Clamp(0, (((cursor.x - rect.x) * texture.width) / rect.width), texture.width);
            float coordY = Mathf.Clamp(0, (((cursor.y - rect.y) * texture.height) / rect.height), texture.height);

            float calX = coordX / texture.width;
            float calY = coordY / texture.height;


            cursor = new Vector2(calX, calY);

            CastRayToWorld(cursor);
        }

    }

    private void CastRayToWorld(Vector2 vec)
    {
        Ray MapRay = miniMapCam.ScreenPointToRay(new Vector2(vec.x * miniMapCam.pixelWidth,
            vec.y * miniMapCam.pixelHeight));

        RaycastHit miniMapHit;

        if (Physics.Raycast(MapRay, out miniMapHit, Mathf.Infinity))
        {
            if (miniMapHit.collider.gameObject.CompareTag("Checkpoint"))
            {
                miniMapHit.collider.gameObject.GetComponentInParent<CheckPointScript>().PlayerClick();
                ID = miniMapHit.collider.gameObject.GetComponentInParent<CheckPointScript>().GetID();
            }
            else
            {
                confirmHolder.SetActive(false);
            }

        }

    }
}
