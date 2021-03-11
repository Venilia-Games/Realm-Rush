using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;
    [SerializeField] private bool isPlaceable;
    public bool IsPlaceable => isPlaceable;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            var isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
       
    }
}
