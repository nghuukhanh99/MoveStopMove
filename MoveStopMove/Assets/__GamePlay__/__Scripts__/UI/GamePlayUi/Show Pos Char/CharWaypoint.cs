using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharWaypoint : MonoBehaviour
{
    public Vector3 offset;
    void FixedUpdate()
    {
        for (int i = 0; i < GameManager.Instance._listCharacter.Count; i++)
        {
            float minX = GUIManager.Instance._imgList[i].GetPixelAdjustedRect().width / 2;

            float maxX = Screen.width - minX;

            float minY = GUIManager.Instance._imgList[i].GetPixelAdjustedRect().height / 2;

            float maxY = Screen.height - minY;

            Vector2 pos = Camera.main.WorldToScreenPoint(GameManager.Instance._listCharacter[i].transform.position + offset);

            if (Vector3.Dot((GameManager.Instance._listCharacter[i].transform.position - transform.position), transform.forward) < 1)
            {
                //target is behind the player
                if (pos.x < Screen.width / 2)
                {
                    pos.x = maxX;
                }
                else
                {
                    pos.x = minX;
                } 
            }

            pos.x = Mathf.Clamp(pos.x, minX, maxX);

            pos.y = Mathf.Clamp(pos.y, minY, maxY);

            GUIManager.Instance._imgList[i].transform.position = pos;         
            
        }
    }
}
