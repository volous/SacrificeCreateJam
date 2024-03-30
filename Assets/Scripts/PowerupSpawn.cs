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

    private void Start()
    {
        xMin = playArea.transform.position.x - playArea.transform.localScale.x/2;
        xMax = playArea.transform.position.x + playArea.transform.localScale.x/2;
        yMin = playArea.transform.position.y - playArea.transform.localScale.y/2;
        yMax = playArea.transform.position.y + playArea.transform.localScale.y/2;
    }

    private void Update()
    {
        if (_cubeList.Count <= 100)
        {
            MakeNewPoints();
        }
    }

    private void MakeNewPoints()
    {
        var newX = Random.Range(xMin, xMax);
        var newY = Random.Range(yMin, yMax);
        var newPos = new Vector3(newX, newY,0);
        var _newPowerup = Instantiate(_powerupCubePrefab, newPos, Quaternion.identity);
        _cubeList.Add(_newPowerup);
    }
}
