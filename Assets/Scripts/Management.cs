using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Management : ScriptableObject
{
    private const string SettingFileDirectory = "Assets/Resources";
    private const string SettingFilePath = "Assets/Resources/Management.asset";

    private static Management _instance;
    public static Management Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = Resources.Load<Management>("Management");

#if UNITY_EDITOR
            if (_instance == null)
            {
                if (!AssetDatabase.IsValidFolder(SettingFileDirectory))
                {
                    AssetDatabase.CreateFolder("Assets", "Resources");
                }

                _instance = AssetDatabase.LoadAssetAtPath<Management>(SettingFilePath);

                if (_instance == null)
                {
                    _instance = CreateInstance<Management>();
                    AssetDatabase.CreateAsset(_instance, SettingFilePath);
                }
            }

#endif
            return _instance;
        }
    }

    public float level;

    public bool isStartGame;

}
