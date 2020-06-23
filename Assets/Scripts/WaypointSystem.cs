using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    [SerializeField] Vector3[] m_waypoints;

    public Vector3[] WayPoints { get => m_waypoints; set => m_waypoints = value; }

}
