using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.U2D;

[CanEditMultipleObjects]
[CustomEditor(typeof(MapPoint))]
public class MapPointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUI.enabled = !EditorApplication.isPlaying;
        if (GUILayout.Button("Default Location Name"))
        {
            foreach (Object obj in targets)
            {
                MapPoint mp = (MapPoint)obj;
                mp.locationName = mp.gameObject.name;
            }
        }
        if (GUILayout.Button("Default MapArea"))
        {
            foreach (Object obj in targets)
            {
                MapPoint mp = (MapPoint)obj;
                foreach (MapArea ma in FindObjectsOfType<MapArea>())
                {
                    if (ma.GetComponent<Collider2D>().OverlapPoint(mp.transform.position))
                    {
                        mp.mapArea = ma;
                        mp.GetComponent<SpriteRenderer>().color =
                            Color.Lerp(
                                ma.GetComponent<SpriteShapeRenderer>().color,
                                Color.white,
                                0.7f
                                );
                        break;
                    }
                }
            }
        }
    }
}
