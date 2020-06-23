using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Character : MonoBehaviour
{
    [SerializeField] WaypointSystem m_system = null;
    [SerializeField] float m_waypointRange = 1.25f;
    public bool m_cycleWaypoints = true;

    NavMeshAgent m_agent = null;
    int m_waypointProgression = 0;
    int m_progressionDirection = 1;

    void Start()
    {
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (m_system && m_system.WayPoints != null && m_system.WayPoints.Length > 1)
        {
            m_agent.SetDestination(m_system.WayPoints[m_waypointProgression]);

            Vector3 dif = transform.position - m_system.WayPoints[m_waypointProgression];

            if (dif.sqrMagnitude < m_waypointRange * m_waypointRange)
            {
                if (!m_cycleWaypoints) {
                    if (m_waypointProgression + m_progressionDirection < 0 || m_waypointProgression + m_progressionDirection > m_system.WayPoints.Length - 1)
                        m_progressionDirection *= -1;
                }

                m_waypointProgression += m_progressionDirection;

                if (m_cycleWaypoints) {
                    if (m_waypointProgression > m_system.WayPoints.Length - 1)
                        m_waypointProgression = 0;
                    else if (m_waypointProgression < 0)
                        m_waypointProgression = m_system.WayPoints.Length - 1;
                }
            }
        }
    }
}
