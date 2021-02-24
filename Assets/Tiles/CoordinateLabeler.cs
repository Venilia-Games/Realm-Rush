using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying) return;
        DisplayCoordinate();
        UpdateObjName();
    }

    private void DisplayCoordinate()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z/ UnityEditor.EditorSnapSettings.move.z);
        label.text = $"{coordinates.x}, {coordinates.y}";
    }

    private void UpdateObjName()
    {
        transform.parent.name = coordinates.ToString();
    }
}
