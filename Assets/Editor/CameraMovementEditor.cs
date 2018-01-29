using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor (typeof (CameraMovement))]
public class CameraMovementEditor : Editor 
{
	void OnSceneGUI() 
	{
        CameraMovement camera = (CameraMovement)target;

        //Draws view reach
        Handles.color = Color.black;
        Handles.DrawWireArc(camera.transform.position, Vector3.forward, Vector3.up, 360, camera.viewRadius);

        //Draws cone of view
        Vector3 viewAngleA = camera.DirFromAngle(-camera.viewAngle / 2, false);
        Vector3 viewAngleB = camera.DirFromAngle(camera.viewAngle / 2, false);
        Handles.DrawLine(camera.transform.position, camera.transform.position + viewAngleA * camera.viewRadius);
        Handles.DrawLine(camera.transform.position, camera.transform.position + viewAngleB * camera.viewRadius);
	}

}