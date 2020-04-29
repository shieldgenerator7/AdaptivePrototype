using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoutePath : MonoBehaviour
{
    public List<Route> routes = new List<Route>();

    public GameObject pathPrefab;

    public void display(bool show)
    {
        //Destroy currently shown lines
        int childs = transform.childCount;
        for (int i = childs - 1; i > 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        if (show)
        {
            //Make new line objects
            foreach (Route route in routes)
            {
                GameObject line = Instantiate(pathPrefab);
                line.transform.parent = transform;
                line.GetComponent<Line>().setEndPoints(route.startID, route.destinationID);
                Color color = line.GetComponent<SpriteRenderer>().color;
                color.a = 0.5f;
                line.GetComponent<SpriteRenderer>().color = color;
            }
        }
    }
}
