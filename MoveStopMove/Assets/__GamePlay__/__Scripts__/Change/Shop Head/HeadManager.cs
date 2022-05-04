using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeadManager", menuName = "HeadManager")]
public class HeadManager : ScriptableObject
{
    [SerializeField] public SkinHead[] skinsHead;

    private const string Prefix = "Head_";

    private const string SelectedHead = "SelectedHead";

    private const string EquippedHead = "EquippedHead_";

    private const string UnSelectHead = "UnselectHead";
    public void SelectHead(int HeadIndex) => PlayerPrefs.SetInt(SelectedHead, HeadIndex);

    public SkinHead GetSelectedHead()
    {
        int HeadIndex = PlayerPrefs.GetInt(SelectedHead, 0);

        if (HeadIndex >= 0 && HeadIndex < skinsHead.Length)
        {
            return skinsHead[HeadIndex];
        }
        else
        {
            return null;
        }
    }

    public void Unlock(int HeadIndex) => PlayerPrefs.SetInt(Prefix + HeadIndex, 1);

    public void UnSelect(int HeadIndex) => PlayerPrefs.SetInt(Prefix + HeadIndex, 0);

    public bool IsUnSelect(int HeadIndex) => PlayerPrefs.GetInt(Prefix + HeadIndex, 1) == 0;

    public bool IsUnlocked(int HeadIndex) => PlayerPrefs.GetInt(Prefix + HeadIndex, 0) == 1;

    public void Equip(int HeadIndex) => PlayerPrefs.SetInt(EquippedHead + HeadIndex, 1);

    public void ClearEquip(int HeadIndex) => PlayerPrefs.DeleteKey(EquippedHead + HeadIndex);

    public bool IsEquipped(int HeadIndex) => PlayerPrefs.GetInt(EquippedHead + HeadIndex, 0) == 1;



}
