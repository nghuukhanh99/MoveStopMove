using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitsChange : MonoBehaviour
{
    public SkinnedMeshRenderer bodyPart;

    public List<Material> options = new List<Material>();

    public int currentOption = 0;
    
    public void nextOption()
    {
        currentOption++;

        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        bodyPart.material = options[currentOption];
    }

    public void PrevOption()
    {
        currentOption--;
        if(currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }

        bodyPart.material = options[currentOption];
    }
}
