using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TextCore.Text;

[CustomEditor(typeof(WalkPoint))]
public class EditWalkPoint : Editor
{
    WalkPoint Walkpoint => target as WalkPoint;

    private void OnSceneGUI()
    {
        Handles.color = Color.cyan;
        for (int i = 0; i < Walkpoint.Point.Length; i++)
        {
            EditorGUI.BeginChangeCheck();

            Vector3 currentWalkpointPoint = Walkpoint.CurrentPosition + Walkpoint.Point[i];
            Vector3 newWalkpointPoint = Handles.FreeMoveHandle(currentWalkpointPoint, 
                Quaternion.identity, 0.7f, new Vector3(0.3f, 0.3f, 0.3f), 
                Handles.SphereHandleCap);

            GUIStyle textStyle = new GUIStyle();
            textStyle.fontStyle = FontStyle.Bold;
            textStyle.fontSize = 16;
            textStyle.normal.textColor = Color.white;
            Vector3 textAlligment = Vector3.down * 0.35f + Vector3.right * 0.35f;
            Handles.Label(Walkpoint.CurrentPosition + Walkpoint.Point[i] + textAlligment, $"{i + 1}", textStyle);
            EditorGUI.EndChangeCheck();

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(target, "Free Move Handle");
                Walkpoint.Point[i] = newWalkpointPoint - Walkpoint.CurrentPosition;
            }
        }
    }
}
