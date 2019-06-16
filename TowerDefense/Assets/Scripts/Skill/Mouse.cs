using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Skill
{
    public static class SceneDrawer
        {
            //[InitializeOnLoadMethod]
            //static void Init()
            //{
            //    SceneView.onSceneGUIDelegate -= OnSceneGUI;
            //    SceneView.onSceneGUIDelegate += OnSceneGUI;
            //}

            //private static void OnSceneGUI(SceneView sceneView)
            //{
            //Debug.Log("ONSCENCEGUI");
            //    Handles.BeginGUI();
            //    {
            //    Debug.Log("ONSCENCEGUI2");
            //    DrawCircleBrush(Color.red, 10f);
            //        //if (EditorWindow.mouseOverWindow is SceneView)
            //        //{
            //        //    if (Event.current.type == EventType.Repaint)
            //        //    {
            //        //        DrawCircleBrush(Color.white, 10f);
            //        //    }
            //        //}
            //    }
            //    Handles.EndGUI();
            //}

            //private static void DrawCircleBrush(Color _color, float _size)
            //{
            //    Handles.color = _color;
            //    // Circle
            //    Handles.CircleHandleCap(0, Event.current.mousePosition, Quaternion.identity, _size, EventType.Repaint);
            //    // Cross Center
            //    Handles.DrawLine(Event.current.mousePosition + Vector2.left, Event.current.mousePosition + Vector2.right);
            //    Handles.DrawLine(Event.current.mousePosition + Vector2.up, Event.current.mousePosition + Vector2.down);
            //}
        }
}
