#if UNITY_EDITOR

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// 날짜 : 2021-03-08 AM 1:38:56
// 작성자 : Rito

namespace Rito.EditorUtilities
{
    public class SceneAutoSaverWindow : EditorWindow
    {
        [MenuItem("Tools/Rito/Scene Auto Saver")]
        private static void Init()
        {
            // 현재 활성화된 윈도우 가져오며, 없으면 새로 생성
            SceneAutoSaverWindow window = (SceneAutoSaverWindow)GetWindow(typeof(SceneAutoSaverWindow));
            window.Show();
            window.titleContent.text = "Scene Auto Saver";

            window.minSize = new Vector2(340f, 150f);
            window.maxSize = new Vector2(400f, 180f);
        }

        void OnGUI()
        {
            Color originColor = EditorStyles.boldLabel.normal.textColor;
            EditorStyles.boldLabel.normal.textColor = Color.yellow;

            EditorGUI.BeginChangeCheck();

            // ============================================================================ Options ==
            GUILayout.Space(10f);
            GUILayout.Label("Options", EditorStyles.boldLabel);

            SceneAutoSaver.Activated = EditorGUILayout.Toggle("On", SceneAutoSaver.Activated);
            SceneAutoSaver.ShowLog = EditorGUILayout.Toggle("Show Log", SceneAutoSaver.ShowLog);
            SceneAutoSaver.SaveInterval = EditorGUILayout.DoubleField("Save Interval (sec)", SceneAutoSaver.SaveInterval);

            // ============================================================================ Logs ==
            GUILayout.Space(10f);
            GUILayout.Label("Logs", EditorStyles.boldLabel);

            // ============================================================================ Last Saved Time ==
            GUILayout.BeginHorizontal();

            GUILayout.Label("Last Saved Time :");
            GUILayout.Label(SceneAutoSaver.LastSavedTimeForLog.ToString("[yyyy-MM-dd] hh : mm : ss"));

            GUILayout.EndHorizontal();

            // ============================================================================ Next Save Remaining ==
            GUILayout.BeginHorizontal();

            GUILayout.Label("Next Save :");
            GUILayout.Label(SceneAutoSaver.NextSaveRemaining.ToString("00.00"));

            GUILayout.EndHorizontal();
            // ============================================================================

            if (EditorGUI.EndChangeCheck())
            {
                SceneAutoSaver.SaveOptions();
            }

            EditorStyles.boldLabel.normal.textColor = originColor;
        }
    }
}

#endif