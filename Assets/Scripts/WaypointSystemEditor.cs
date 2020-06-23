using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WaypointSystem))]
[CanEditMultipleObjects]
public class WaypointSystemEditor : Editor
{
    WaypointSystem m_system;
    Vector3[] m_positions;

    private void OnEnable()
    {
        m_system = target as WaypointSystem;
        SceneView.duringSceneGui += DisplayHandles;
    }
    private void OnDisable()
    {
        SceneView.duringSceneGui -= DisplayHandles;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    void DisplayHandles(SceneView sceneView)
    {
        Undo.RecordObject(m_system, "Waypoint Handles");

        m_positions = m_system.WayPoints;

        if (m_positions == null || m_positions.Length < 2)
        {
            m_positions = new Vector3[2] { Vector3.zero, Vector3.forward * 1 };
        }

        for (int i = 0; i < m_positions.Length; i++)
        {
            m_positions[i] = Handles.PositionHandle(m_positions[i], Quaternion.identity);

            if (i != m_positions.Length - 1)
            {
                Handles.DrawLine(m_positions[i], m_positions[i + 1]);
            }
        }
        m_system.WayPoints = m_positions;
    }
}
