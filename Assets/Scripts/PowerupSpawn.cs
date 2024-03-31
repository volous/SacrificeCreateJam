using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PowerupSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _powerupCubePrefab;
    [SerializeField] private GameObject playArea;
    
    private List<GameObject> _cubeList = new List<GameObject>();
    public int _currentAmountOfPowerups = 0;
    private float xMin, xMax, yMin, yMax;

    private void Update()
    {
        UpdatePlayAreaBounds();
    
        // Check if there's a need to spawn new powerups
        if (_cubeList.Count < 10) 
        {
            MakeNewPoints();
        }

        // Iterate through the list of powerups in reverse order
        for (int i = _cubeList.Count - 1; i >= 0; i--)
        {
            // Check if the GameObject still exists
            if (_cubeList[i] != null)
            {
                // Check if the powerup is outside the bounds
                if (_cubeList[i].transform.position.x < xMin)
                {
                    Destroy(_cubeList[i]);
                    _cubeList.RemoveAt(i);
                }
            }
            else
            {
                // Remove reference to destroyed GameObject from the list
                _cubeList.RemoveAt(i);
            }
        }
    }

    public void MakeNewPoints()
    {
        // Generate random position within the bounds
        var newX = Random.Range(xMin, xMax);
        var newY = Random.Range(yMin, yMax);
        var newPos = new Vector3(newX, newY, 0);

        // Instantiate new powerup
        var _newPowerup = Instantiate(_powerupCubePrefab, newPos, Quaternion.identity);
        _cubeList.Add(_newPowerup);
    }

    private void UpdatePlayAreaBounds()
    {
        // Update the bounds based on the play area's position
        xMin = playArea.transform.position.x - 9;
        xMax = playArea.transform.position.x + 18;
        yMin = playArea.transform.position.y - 4;
        yMax = playArea.transform.position.y + 4;
    }
}
