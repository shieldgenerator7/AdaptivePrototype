using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.U2D;
using UnityEditor.SceneManagement;

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
                mp.text.text = mp.locationName;
                EditorUtility.SetDirty(mp);
                EditorUtility.SetDirty(mp.text);
                EditorSceneManager.MarkSceneDirty(mp.gameObject.scene);
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
                        EditorUtility.SetDirty(mp);
                        EditorSceneManager.MarkSceneDirty(mp.gameObject.scene);
                        break;
                    }
                }
            }
        }
        if (GUILayout.Button("Default ID"))
        {
            //Clear current ids
            foreach (Object obj in targets)
            {
                MapPoint mp = (MapPoint)obj;
                mp.id = 0;
            }
            //Find max id
            int maxID = 0;
            foreach (MapPoint mp in FindObjectsOfType<MapPoint>())
            {
                maxID = Mathf.Max(maxID, mp.id);
            }
            //Set current ids
            foreach (Object obj in targets)
            {
                maxID++;
                MapPoint mp = (MapPoint)obj;
                mp.id = maxID; 
                EditorUtility.SetDirty(mp);
                EditorSceneManager.MarkSceneDirty(mp.gameObject.scene);
            }
        }
    }
}
