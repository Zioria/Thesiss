using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCharacterActive : MonoBehaviour
{
    [SerializeField] private GameObject girlCanvas;
    [SerializeField] private GameObject boyCanvas;

    private CharacterStats[] stats => CharacterStatusUI.Instance.Stats;
    private CharacterStats stat;
    private GameObject _canvas;

    private void Awake()
    {
        _canvas = transform.gameObject;
    }

    private void Start()
    {
        girlCanvas.SetActive(false);
        boyCanvas.SetActive(false);
        _canvas.SetActive(false);
    }

    private void Update()
    {
        if (!_canvas.activeInHierarchy)
        {
            return;
        }
        stat = CharacterStatusUI.Instance.CurrentActive(stats);

        if (stat.name == "Mc_G")
        {
            girlCanvas.SetActive(true);
            boyCanvas.SetActive(false);
            return;
        }

        girlCanvas.SetActive(false);
        boyCanvas.SetActive(true);
    }
}
