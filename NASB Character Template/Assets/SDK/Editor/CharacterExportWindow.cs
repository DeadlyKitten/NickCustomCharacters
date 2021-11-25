using Nick;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;

public class CharacterExportWindow : EditorWindow
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

    // Serialized stuff
    SerializedObject so;
    SerializedProperty propName;
    SerializedProperty propAuthor;
    SerializedProperty propCharacterPrefab;
    SerializedProperty propCharacterSkin;
    SerializedProperty propSmallPortrait;
    SerializedProperty propMediumPortrait;
    SerializedProperty propLargePortrait;
    SerializedProperty propCssBackground;
    SerializedProperty propPlayerSlotBackground;
    SerializedProperty propVsBackground;

    Vector2 scrollPosition = Vector2.zero;
    string saveDataPath = string.Empty;

    [MenuItem("NASB/Character Exporter")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        CharacterExportWindow window = (CharacterExportWindow)EditorWindow.GetWindow(typeof(CharacterExportWindow));
        window.titleContent.text = "Character Exporter";
        window.Show();
    }

    private void OnEnable()
    {
        saveDataPath = Path.Combine("Assets", "SDK", "Editor", "exporter_save.asset");
        Load();

        so = new SerializedObject(this);
        propName = so.FindProperty("characterName");
        propAuthor = so.FindProperty("author");
        propCharacterPrefab = so.FindProperty("characterPrefab");
        propCharacterSkin = so.FindProperty("characterSkin");
        propSmallPortrait = so.FindProperty("smallPortrait");
        propMediumPortrait = so.FindProperty("mediumPortrait");
        propLargePortrait = so.FindProperty("largePortrait");
        propCssBackground = so.FindProperty("cssBackground");
        propPlayerSlotBackground = so.FindProperty("playerSlotBackground");
        propVsBackground = so.FindProperty("vsBackground");
    }

    private void OnDisable()
    {
        Save();
    }

    void Save()
    {
        var saveData = Resources.Load("exporter_save.asset") as EditorSaveData;

        if (saveData == null)
        {
            saveData = ScriptableObject.CreateInstance<EditorSaveData>();
            AssetDatabase.CreateAsset(saveData, saveDataPath);
        }

        saveData.characterName = characterName;
        saveData.author = author;
        saveData.characterPrefab = characterPrefab;
        saveData.characterSkin = characterSkin;
        saveData.smallPortrait = smallPortrait;
        saveData.mediumPortrait = mediumPortrait;
        saveData.largePortrait = largePortrait;
        saveData.cssBackground = cssBackground;
        saveData.playerSlotBackground = playerSlotBackground;
        saveData.vsBackground = vsBackground;

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    void Load()
    {
        var saveData = Resources.FindObjectsOfTypeAll<EditorSaveData>().FirstOrDefault();

        if (saveData == null)
        {
            return;
        }

        characterName = saveData.characterName;
        author = saveData.author;
        characterPrefab = saveData.characterPrefab;
        characterSkin = saveData.characterSkin;
        smallPortrait = saveData.smallPortrait;
        mediumPortrait = saveData.mediumPortrait;
        largePortrait = saveData.largePortrait;
        cssBackground = saveData.cssBackground;
        playerSlotBackground = saveData.playerSlotBackground;
        vsBackground = saveData.vsBackground;
        
        OnValidate();
        Repaint();
    }

    private void OnGUI()
    {
        so.Update();

        GUILayout.Space(5);

        scrollPosition = GUILayout.BeginScrollView(scrollPosition);

        GUILayout.BeginVertical("Metadata", "window");
        EditorGUILayout.PropertyField(propName);
        EditorGUILayout.PropertyField(propAuthor);
        GUILayout.EndVertical();

        GUILayout.Space(5);

        GUILayout.BeginVertical("Prefabs", "window");
        EditorGUILayout.PropertyField(propCharacterPrefab);

        EditorGUILayout.PropertyField(propCharacterSkin);
        GUILayout.EndVertical();

        GUILayout.Space(5);

        GUILayout.BeginVertical("Portraits", "window");
        EditorGUILayout.PropertyField(propSmallPortrait);
        EditorGUILayout.PropertyField(propMediumPortrait);
        EditorGUILayout.PropertyField(propLargePortrait);
        GUILayout.EndVertical();

        GUILayout.Space(5);

        GUILayout.BeginVertical("Backgrounds", "window");
        EditorGUILayout.PropertyField(propCssBackground, new GUIContent("CSS Background"));
        EditorGUILayout.PropertyField(propPlayerSlotBackground);
        EditorGUILayout.PropertyField(propVsBackground, new GUIContent("VS Background"));
        GUILayout.EndVertical();

        GUILayout.EndScrollView();

        //GUILayout.BeginHorizontal();

        //GUI.backgroundColor = Color.red;
        //if (GUILayout.Button("Clear"))
        //{
        //    Clear();
        //}

        //GUI.backgroundColor = Color.yellow;
        //if (GUILayout.Button("Reload"))
        //{
        //    Load();
        //}

        //GUILayout.EndHorizontal();

        GUILayout.Space(3);

        using (new EditorGUI.DisabledScope(!valid))
        {
            GUI.backgroundColor = Color.green;
            if(GUILayout.Button("Export Character", GUILayout.Height(30)))
            {
                ExportCharacter();
            }
        }


        GUILayout.Space(10);

        so.ApplyModifiedProperties();
    }

    void Clear()
    {
        characterName = default;
        author = default;

        characterPrefab = default;
        characterSkin = default;

        smallPortrait = default;
        mediumPortrait = default;
        largePortrait = default;
        cssBackground = default;
        playerSlotBackground = default;
        vsBackground = default;

        OnValidate();
        Repaint();
    }

    bool valid;
    private void OnValidate()
    {
        valid = true;
        if (characterName == string.Empty) valid = false;
        if (author == string.Empty) valid = false;

        if (!characterPrefab || PrefabUtility.IsPartOfPrefabInstance(characterPrefab))
        {
            valid = false;
            characterPrefab = null;
            Repaint();
        }

        if (!characterSkin) valid = false;

        if (!smallPortrait) valid = false;
        if (!mediumPortrait) valid = false;
        if (!largePortrait) valid = false;

        if (!cssBackground) valid = false;
        if (!playerSlotBackground) valid = false;
        if (!vsBackground) valid = false;

        if (exporting)
        {
            valid = false;
            Repaint();
        }

        Save();
    }


    bool exporting;
    void ExportCharacter()
    {
        if (exporting) return;
        exporting = true;

        var currentSceneSetup = EditorSceneManager.GetSceneManagerSetup();
        if(!EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            exporting = false;
            return;
        }

        try
        {
            var exportPath = Path.Combine("Assets", "Export");
            Directory.CreateDirectory(Path.Combine(Application.dataPath, "Export", "images"));

            #region Create Character Scene
            var characterScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            characterScene.name = characterPrefab.gameUniqueIdentifier;

            var loadedAgent = new GameObject("LoadedAgent").AddComponent<LoadedAgent>();
            loadedAgent.agentId = characterPrefab.gameUniqueIdentifier;
            loadedAgent.agentPrefab = characterPrefab;

            var characterScenePath = Path.Combine(exportPath, characterPrefab.gameUniqueIdentifier + ".unity");
            EditorSceneManager.SaveScene(characterScene, characterScenePath);
            #endregion

            #region Create Skin Scene
            var skinScene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            skinScene.name = characterSkin.skinId;

            var loadedSkin = new GameObject("LoadedSkin").AddComponent<LoadedSkin>();
            loadedSkin.skinId = characterSkin.skinId;
            loadedSkin.skin = characterSkin;

            var skinScenePath = Path.Combine(exportPath, characterSkin.skinId + ".unity");
            EditorSceneManager.SaveScene(skinScene, skinScenePath);
            #endregion

            #region Create AssetBundles

            var build = new AssetBundleBuild
            {
                assetNames = new string[] { characterScenePath, skinScenePath },
                assetBundleName = $"{characterPrefab.gameUniqueIdentifier}.assetbundle"
            };

            BuildPipeline.BuildAssetBundles(exportPath, new AssetBundleBuild[] { build }, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

            #endregion

            #region Copy Images

            var smallPortraitPath = Path.Combine("images", "small");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(smallPortrait), Path.Combine(exportPath, smallPortraitPath));

            var mediumPortraitPath = Path.Combine("images", "medium");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(mediumPortrait), Path.Combine(exportPath, mediumPortraitPath));

            var largePortraitPath = Path.Combine("images", "large");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(largePortrait), Path.Combine(exportPath, largePortraitPath));

            var cssBackgroundPath = Path.Combine("images", "CSS Background");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(cssBackground), Path.Combine(exportPath, cssBackgroundPath));

            var playerSlotBackgroundPath = Path.Combine("images", "Player Slot Background");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(playerSlotBackground), Path.Combine(exportPath, playerSlotBackgroundPath));

            var vsBackgroundPath = Path.Combine("images", "VS Background");
            AssetDatabase.CopyAsset(AssetDatabase.GetAssetPath(vsBackground), Path.Combine(exportPath, vsBackgroundPath));
            #endregion

            #region Create package.json
            var package = new PackageJSON
            {
                id = characterPrefab.gameUniqueIdentifier,
                name = characterName,
                author = author,
                filePath = build.assetBundleName,
                charPath = characterScenePath,
                skinPath = skinScenePath,
                skinId = characterSkin.skinId,
                smallPortraitPath = smallPortraitPath,
                mediumPortraitPath = mediumPortraitPath,
                largePortraitPath = largePortraitPath,
                cssBackgroundPath = cssBackgroundPath,
                playerSlotBackgroundPath = playerSlotBackgroundPath,
                vsBackgroundPath = vsBackgroundPath
            };

            var jsonPath = Path.Combine(Application.dataPath, "Export", "package.json");
            var packageJSON = JsonUtility.ToJson(package, true).Replace(@"\\", @"/");

            File.WriteAllText(jsonPath, packageJSON);
            #endregion

            #region Create Zip

            AssetDatabase.OpenAsset(characterPrefab);

            AssetDatabase.DeleteAsset(characterScenePath);
            AssetDatabase.DeleteAsset(skinScenePath);
            AssetDatabase.DeleteAsset(Path.Combine(exportPath, "Export"));
            AssetDatabase.DeleteAsset(Path.Combine(exportPath, "Export.manifest"));
            AssetDatabase.DeleteAsset(Path.Combine(exportPath, $"{build.assetBundleName}.manifest"));

            var initialPath = EditorPrefs.GetString("CHARACTER_EXPORT_PATH", Application.dataPath);

            var savePath = EditorUtility.SaveFilePanel(
            "Save Custom Character",
            initialPath,
            characterName + ".nickchar",
            "nickchar");

            if (savePath.Length == 0) return;

            EditorPrefs.SetString("CHARACTER_EXPORT_PATH", Path.GetDirectoryName(savePath));

            if (File.Exists(savePath)) File.Delete(savePath);
            ZipFile.CreateFromDirectory(Path.Combine(Application.dataPath, "Export"), savePath);

            #endregion

            #region Restore Scene
            //if (currentSceneSetup != null && currentSceneSetup.Length > 0 &&
            //    currentSceneSetup.Any(x => x.isLoaded) && currentSceneSetup.Any(x => x.isActive))
            //    EditorSceneManager.RestoreSceneManagerSetup(currentSceneSetup);
            #endregion

        }
        catch (Exception e)
        {
            Debug.LogError($"{e.Message}\n{e.StackTrace}");
        }
        finally
        {
            exporting = false;
        }
    }
}
