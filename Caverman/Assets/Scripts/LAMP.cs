using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class LAMP : MonoBehaviour
{
    public Light lamplight;
    private GameObject[] POI;
    private GameObject end;
    private List<Transform> POItransform = new List<Transform>();
    public Transform playertransform;
    public float[] levels = new float[] { 1f, 0.1f, 0.5f, 0.07f, 0.03f, 0.01f };
    private float minlevel = 0.01f;
    private float maxlevel = 1f;
    private float distance;
    private float currentd;
    public float[] checkdistances = new float[] { 2f, 4f, 6f, 8f, 10f, 1000000f };

    void Start()
    {
        POI = GameObject.FindGameObjectsWithTag("pointofinterest");
        List<GameObject> POIlist = new List<GameObject>(POI);
        try { end = GameObject.FindGameObjectWithTag("end"); }
        catch (Exception e) { Debug.Log("no end"); }
        if (end != null)
        {
            POIlist.Add(end);
        }
        playertransform = GetComponent<Transform>();
        foreach (GameObject obj in POIlist)
        {
            //Debug.Log("added:");

            POItransform.Add(obj.GetComponent<Transform>());
        }
    }


    void Update()
    {
        distance = 1000000f;
        //Debug.Log(POItransform);
        foreach (Transform tf in POItransform)
        {
            if (tf == null) continue;
            currentd = Vector3.Distance(tf.position, playertransform.position);
            if (currentd < distance) { distance = currentd; }
        }
        //float level = levels[checkdistances.Length - 1];
        /*
        for (int i = checkdistances.Length - 1; i >= 0; i--)
        {
            
            if (checkdistances[i] >= distance)
            {
                level = levels[i];
            }
        }
        lamplight.intensity=level;*/
        if (checkdistances[0] >= distance)
        {
            lamplight.intensity = maxlevel;
        }
        else if (distance > checkdistances[checkdistances.Length - 2])
        {
            lamplight.intensity = minlevel;
        }
        else
        {
            float interpol = Mathf.InverseLerp(checkdistances[0], checkdistances[checkdistances.Length-2], distance);
            lamplight.intensity = Mathf.Lerp(maxlevel, minlevel, interpol);

        }
        }
    }

