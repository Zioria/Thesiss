using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmTeleportHolder : MonoBehaviour
{
    [SerializeField] private Text nameText;
    private string _namePos;
    private void Update()
    {
        if (!gameObject.activeInHierarchy)
        {
            return;
        }
        _namePos = LargeMapPointer.Instance.RecieveName;
        TextPositionUpdate(_namePos);
    }

    private void TextPositionUpdate(string posName)
    {
        nameText.text = posName;
    }
}
