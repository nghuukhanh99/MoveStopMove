using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharWaypoint : MonoBehaviour
{
    public List<Image> charUiPosList = new List<Image>();

    public List<Transform> charPosList = new List<Transform>();
    

    void Update()
    {
        for(int i = 0; i < charPosList.Count; i++)
        {
            charUiPosList[i].transform.position = Camera.main.WorldToScreenPoint(charPosList[i].position);
        }
    }
}
