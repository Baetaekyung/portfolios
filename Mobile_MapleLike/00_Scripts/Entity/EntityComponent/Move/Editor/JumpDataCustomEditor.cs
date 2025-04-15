using Codice.Client.Common.GameUI;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(JumpDataSO))]
public class JumpDataCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        JumpDataSO jumpData = (JumpDataSO)target;

        EditorGUILayout.LabelField("�����͸� �Է��ϱ� ���� �ѹ� �����ÿ�.");
        if (jumpData != null)
        {
            if(GUILayout.Button("������ ĳ�� �ʱ�ȭ."))
            {
                jumpData.JumpCount = 0;
                jumpData.JumpEffectPrefab = null;
            }
        }

        if(jumpData.JumpCount == 0)
        {
            ClearCache();
        }

        for (int i = 0; i < jumpData.JumpCount; i++)
        {
            jumpData.JumpForce.Add(0);
            jumpData.JumpDirection.Add(Vector2.zero);
        }

        for (int i = 0; i < jumpData.JumpCount; i++)
        {
            EditorGUILayout.Space(20);

            EditorGUILayout.LabelField("���� ������");
            jumpData.JumpForce[i] = EditorGUILayout.FloatField("Jump Force", jumpData.JumpForce[i]);
            jumpData.JumpDirection[i] = EditorGUILayout.Vector2Field("Jump Direction", jumpData.JumpDirection[i]);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(jumpData);
        }

        void ClearCache()
        {
            jumpData.JumpForce.Clear();
            jumpData.JumpDirection.Clear();
        }
    }
}
