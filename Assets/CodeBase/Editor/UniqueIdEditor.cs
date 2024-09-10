using System;
using System.CodeDom.Compiler;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.Device;
using UniqueId = CodeBase.Logic.UniqueId;

namespace Editor
{
    [CustomEditor(typeof(UniqueId))]
    public class UniqueIdEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueId = (UniqueId)target;

            if (string.IsNullOrEmpty(uniqueId.Id))
                Generate(uniqueId);
        }

        private void Generate(UniqueId uniqueId)
        {
            uniqueId.Id = Guid.NewGuid().ToString();

            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueId);
                EditorSceneManager.MarkSceneDirty(uniqueId.gameObject.scene);
            }
        }
    }
}