using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerSizeView : MonoBehaviour
{

    [SerializeField] private TMP_Text _text;
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.sizeChanged += OnSizeChanged;
    }

    private void OnDisable()
    {
        _tower.sizeChanged -= OnSizeChanged;
    }

    private void OnSizeChanged(int size)
    {
        _text.text = size.ToString();
    }
}
