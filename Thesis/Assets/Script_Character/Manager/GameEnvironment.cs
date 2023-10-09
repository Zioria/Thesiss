using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnvironment
{
    public List<GameObject> Waypoints
    {
        get
        {
            return _waypoints;
        }
    }

    private List<GameObject> _waypoints = new List<GameObject>();
    private static GameEnvironment _instance;

    public static GameEnvironment Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = new GameEnvironment();
            _instance.Waypoints.AddRange(GameObject.FindGameObjectsWithTag("Waypoint"));
            _instance._waypoints = _instance.Waypoints.OrderBy(waypoint => waypoint.name).ToList();

            return _instance;
        }
    }
}
