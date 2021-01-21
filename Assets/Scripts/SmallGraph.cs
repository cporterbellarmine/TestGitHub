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
public class SmallGraph : MonoBehaviour
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
        for (int i = 0; i < resolution; i++)
        {
            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - ((float)graphRange / 2); //sets the initial x position
            position.y = 1*(position.x*position.x) + 1*position.x + 0; //sets the y position based off the x position
            point.localPosition = position;
            point.localScale = scale;
            point.SetParent(transform); //places all instantiated points as children of the graph object

        }
    }
}