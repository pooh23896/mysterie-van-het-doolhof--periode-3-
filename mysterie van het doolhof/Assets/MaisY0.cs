using UnityEditor;
using UnityEngine;

public class AlignColliderToGround : MonoBehaviour
{
    [MenuItem("Tools/Align BoxCollider Bottom To Y = 0 %#y")] // Ctrl+Shift+Y
    private static void AlignBoxColliderToYZero()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            BoxCollider collider = obj.GetComponent<BoxCollider>();
            if (collider != null)
            {
                // Bepaal de wereldpositie van de onderkant van de collider
                Vector3 worldBottom = obj.transform.TransformPoint(collider.center - new Vector3(0, collider.size.y / 2, 0));

                // Bepaal de offset om Y = 0 te bereiken
                float offset = 0f - worldBottom.y;

                // Pas de positie van het object aan
                Undo.RecordObject(obj.transform, "Align BoxCollider Bottom to Y = 0");
                obj.transform.position += new Vector3(0, offset, 0);
            }
        }
    }
}