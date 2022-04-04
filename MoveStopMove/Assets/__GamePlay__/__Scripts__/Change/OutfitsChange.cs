using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutfitsChange : MonoBehaviour
{
    public SkinnedMeshRenderer bodyPart;

    public Image ItemsOnShop;

    public List<Material> options = new List<Material>();

    public List<Sprite> itemsShop = new List<Sprite>();

    public int currentItemsShop = 0;

    public int currentOption = 0;
    
    public void nextOption()
    {
        currentOption++;

        currentItemsShop++;

        if(currentItemsShop >= itemsShop.Count)
        {
            currentItemsShop = 0;
        }

        if(currentOption >= options.Count)
        {
            currentOption = 0;
        }

        bodyPart.material = options[currentOption];

        ItemsOnShop.sprite = itemsShop[currentItemsShop];
    }

    public void PrevOption()
    {
        currentOption--;

        currentItemsShop--;

        if (currentItemsShop <= 0)
        {
            currentItemsShop = itemsShop.Count - 1;
        }
        if (currentOption <= 0)
        {
            currentOption = options.Count - 1;
        }

        bodyPart.material = options[currentOption];

        ItemsOnShop.sprite = itemsShop[currentItemsShop];
    }
}
