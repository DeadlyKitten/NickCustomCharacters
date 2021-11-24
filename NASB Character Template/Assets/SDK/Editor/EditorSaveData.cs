using Nick;
using System;
using UnityEngine;

[Serializable]
class EditorSaveData : ScriptableObject
{
    public string characterName;
    public string author;

    public GameAgent characterPrefab;
    public SkinData characterSkin;

    public Texture smallPortrait;
    public Texture mediumPortrait;
    public Texture largePortrait;
    public Texture cssBackground;
    public Texture playerSlotBackground;
    public Texture vsBackground;
}
