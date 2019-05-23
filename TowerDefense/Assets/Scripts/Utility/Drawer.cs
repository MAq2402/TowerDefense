using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Utility
{
    /*
     * Author: Bartłomiej Krasoń
     * Drawer class represents service which draws elements using LineRenderer component of objects
     *  which draw something on main scene
     */
    public static class Drawer
    {

        /* Author: Bartłomiej Krasoń */
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
            float y = 0.075f;
            float z;

            float angle = 20f;

            for (int i = 0; i < (segments + 1); i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
                z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

                line.SetPosition(i, new Vector3(x, y, z));

                angle += (360f / segments);
            }
        }

        /* Author: Bartłomiej Krasoń */
        public static void DrawLaserBeam(LineRenderer line, Vector3 positionFrom, Vector3 positionTo, float width, Color color)
        {
            line.material = new Material(Shader.Find("Particles/Standard Surface"));
            line.positionCount = 2;
            line.useWorldSpace = true;
            line.startWidth = width;
            line.endWidth = width;
            line.startColor = color;
            line.endColor = color;
            line.SetPosition(0, positionFrom);
            line.SetPosition(1, positionTo);
        }

        /* Author: Bartłomiej Krasoń */
        public static void DrawEmpty(LineRenderer line)
        {
            line.positionCount = 0;
        }
    }
}
