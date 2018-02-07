using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSpaceUI
{

    // Use this for initialization
    /// <summary>
    /// 
    /// </summary>
    /// <param name="worldSpace_Tr : target"></param>
    /// <param name="offSetWorldSpace : offset pos"></param>
    /// <param name="clampSpace : clamp edge of screen"></param>
    /// <param name="wrapAroundScreen : if target goes behind cam, it'll still stay on the edge"></param>
    /// <param name="aspectRatio : clamps to square"></param>
    /// <param name="spherize : clamps into a sphere instead of boxed screen. Uses clampEdge.x only"></param>
    /// <returns></returns>
    static public Vector3 ScreenSpace(Transform worldSpace_Tr, Vector2 offSetWorldSpace, Vector2 clampEdge, bool wrapAroundScreen = false, bool aspectRatio = false, bool spherize = false)
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldSpace_Tr.position + (Camera.main.transform.right * offSetWorldSpace.x) + (worldSpace_Tr.up * offSetWorldSpace.y));

        if (aspectRatio) clampEdge = new Vector2(clampEdge.x * Camera.main.aspect, clampEdge.y);

        //ON SCREEN
        // get the center of the screen and minus the percent of the offset for the left	//	get the center of the screen and minus the border percent for the right
        if (screenPos.z > 0 &&
            screenPos.x > 0 && screenPos.x < Screen.width &&
            screenPos.y > 0 && screenPos.y < Screen.height || (wrapAroundScreen))
        {

            if (spherize) //clamps sphere. uses clampEdge.x
            {
                Vector3 centerPt = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                screenPos = centerPt + Vector3.ClampMagnitude(new Vector3((screenPos - centerPt).x, (screenPos - centerPt).y, 1), clampEdge.x); //prevent z from being negative
            }
            else // clamps at the edges
            {
                screenPos = new Vector3(Mathf.Clamp(screenPos.x, clampEdge.x, Screen.width - clampEdge.x), Mathf.Clamp(screenPos.y, clampEdge.y, Screen.height - clampEdge.y), Mathf.Clamp(screenPos.z, 0, Mathf.Infinity));
            }
            //reverse
            if (screenPos.z < 0) screenPos = new Vector3(screenPos.x * -1, screenPos.y * -1, screenPos.z);

        }
        else
        {
            screenPos = screenPos * 1000;
        }
        return screenPos;
    }
}
