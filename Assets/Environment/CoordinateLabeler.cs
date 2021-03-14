using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color blockedColor = Color.gray;
    
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    private Waypoint _waypoint;
    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false;
        
        _waypoint = GetComponentInParent<Waypoint>();
        DisplayCoordinate();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinate();
            UpdateObjName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    private void SetLabelColor()
    {
        label.color = _waypoint.IsPlaceable ? defaultColor : blockedColor;
    }

    private void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
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
