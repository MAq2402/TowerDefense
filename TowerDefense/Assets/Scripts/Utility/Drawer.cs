using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    public static class Drawer
    {
        /*GameObject wich draws Circle needs two components:
            - LineRenderer
            - Maretial with type of Particles / Standard Surface
         */
        public static void DrawCircleOnSurface(LineRenderer line, float radius, float width, Color color)
        {
            int segments = 50;
            line.material = new Material(Shader.Find("Particles/Standard Surface"));
            line.positionCount = segments + 1;
            line.useWorldSpace = false;
            line.startWidth = width;
            line.endWidth = width;
            line.startColor = color;
            line.endColor = color;

            float x;
            float y;
            float z;

            float angle = 20f;

            for (int i = 0; i < (segments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
                z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

                line.SetPosition(i, new Vector3(x, 0.075f, z));

                angle += (360f / segments);
            }
        }

        public static void EraseCircleOnSurface(LineRenderer line)
        {
            line.positionCount = 0;
        }
    }
}
