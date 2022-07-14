using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode()]
public class DrawLine : MonoBehaviour
{
	public ArrayList points;
	public LineRenderer lineRenderer;

    // Use this for initialization
    private void Awake()
    {

		points = new ArrayList();
		points.Add(transform);
	}

    void Start()
	{
		lineRenderer.positionCount = points.Count;
	}

	// Update is called once per frame
	void Update()
	{
		int i = 0;
		foreach (Transform node in points)
		{
			lineRenderer.SetPosition(i, node.position);
			i++;
		}
	}
}
