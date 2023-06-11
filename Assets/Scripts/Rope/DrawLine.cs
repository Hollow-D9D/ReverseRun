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
	}

	// Update is called once per frame
	void LateUpdate()
	{
		int i = 0;
		lineRenderer.positionCount = points.Count;
		foreach (Transform node in points)
		{
			lineRenderer.SetPosition(i, node.position);
			i++;
		}
	}
}
