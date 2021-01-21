using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 2D Graph Template
 * @author Christina Porter (cporterbellarmine)
 * @version 1.5
 * @date 1/21/2021
 * credit to catlikecoding.com
 */
public class LargeGraph : MonoBehaviour
{
    //Transform is what is used to manipulate the size and position of an object.
    //SerializeField creates an editable property in Unity
    [SerializeField]
    Transform pointPrefab = default;

    //The resolution is the number of blocks that exists in my graph.
    //SerializeField creates an editable property in Unity where Range enables a slider between the two given values
    [SerializeField, Range(10, 100)]
    int resolution = 10;

    //The graphRange determines how many blocks wide we want our graph
    //SerializeField creates an editable property in Unity where Range enables a slider between the two given values
    [SerializeField, Range(2, 10)]
    int graphRange = 2;

    //Awake is a pre-built unity function that allows this code to be run when the scene is "started" or "awake"
    void Awake()
    {
        float step = (float)graphRange / resolution; //Divides the number of blocks by the range of values to determine the distance between them
        var scale = Vector3.one * step; //Takes the size of the blocks from (1,1,1) and multiplies it by the step value to impact the size based off distance
        var position = Vector3.zero;

        //determines the position of each block. Remember resolution is the number of blocks in the graph.
        //Unity's axes are a bit backwards from what we usually think they are. X and Z are our "horizontal" axes while Y is a "vertical" axis
        for (int i = 0; i < resolution; i++) //i is used for our x value
        {
            for (int j = 0; j < resolution; j++) //j is used for our z value
            {
                Transform point = Instantiate(pointPrefab);
                position.x = (i + 0.5f) * step - ((float)graphRange / 2); //sets the initial x position
                position.z = (j + 0.5f) * step - ((float)graphRange / 2); //sets the initial y position
                position.y = position.x * position.x + position.z * position.z; //sets the z position based off the x and y position
                point.localPosition = position; //sets the position relative to (0,0,0)
                point.localScale = scale; //sets the scale of each point to the scale size
                point.SetParent(transform); //Places each point under our parent object
            }
        }
    }
}
