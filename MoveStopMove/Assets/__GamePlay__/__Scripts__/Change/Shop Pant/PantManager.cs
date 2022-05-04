using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PantManager", menuName = "PantManager")]
public class PantManager : ScriptableObject
{
    [SerializeField] public Skin[] skinsPant;

    private const string Prefix = "Pant_";

    private const string SelectedPant = "SelectedPant";

    private const string EquippedPant = "EquippedPant_";

    private const string UnSelectPant = "UnselectPant";
    public void SelectPant(int PantIndex) => PlayerPrefs.SetInt(SelectedPant, PantIndex);

    public Skin GetSelectedPant()
    {
        int pantIndex = PlayerPrefs.GetInt(SelectedPant, 0);

        if(pantIndex >= 0 && pantIndex < skinsPant.Length)
        {
            return skinsPant[pantIndex];
        }
        else
        {
            return null;
        }
    }

    public void Unlock(int PantIndex) => PlayerPrefs.SetInt(Prefix + PantIndex, 1);

    public void UnSelect(int PantIndex) => PlayerPrefs.SetInt(Prefix + PantIndex, 0);

    public bool IsUnSelect(int PanIndex) => PlayerPrefs.GetInt(Prefix + PanIndex, 1) == 0;

    public bool IsUnlocked(int PantIndex) => PlayerPrefs.GetInt(Prefix + PantIndex, 0) == 1;

    public void Equip(int PantIndex) => PlayerPrefs.SetInt(EquippedPant + PantIndex, 1);

    public void ClearEquip(int PantIndex) => PlayerPrefs.DeleteKey(EquippedPant + PantIndex);

    public bool IsEquipped(int PantIndex) => PlayerPrefs.GetInt(EquippedPant + PantIndex, 0) == 1;

}
