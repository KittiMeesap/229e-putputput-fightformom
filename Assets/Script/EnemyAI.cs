using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class EnemyAI : MonoBehaviour
{
    public List<Transform> points;
    public int nextID;
    int idChangeValue = 1;

    private void Reset()
    {

        Inti();
    }

    void Inti()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;

        GameObject root = new GameObject(name + "_Root");

        root.transform.position = transform.position;

        transform.SetParent(root.transform);

        GameObject waypoints = new GameObject("Waypoints");

        waypoints.transform.SetParent(root.transform);

        GameObject p1 = new GameObject("Point 1"); p1.transform.SetParent(waypoints.transform);
        GameObject p2 = new GameObject("Point 2"); p2.transform.SetParent(waypoints.transform);

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
    }
}
