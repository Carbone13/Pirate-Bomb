using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(InputManager))]
public class InputManagerEditor : Editor
{
    private InputManager myTarget;
    private SerializedObject soTarget;

    public SerializedProperty horizontal;
    public SerializedProperty vertical;

    public SerializedProperty jump;
    public SerializedProperty primaryAttack;
    public SerializedProperty secondaryAttack;
    public SerializedProperty submit;

    private void OnEnable() {
        myTarget = (InputManager)target;
        soTarget = new SerializedObject(target);

        horizontal = soTarget.FindProperty("horizontal");
        vertical = soTarget.FindProperty("vertical");

        jump = soTarget.FindProperty("jump");
        primaryAttack = soTarget.FindProperty("primaryAttack");
        secondaryAttack = soTarget.FindProperty("secondaryAttack");
        submit = soTarget.FindProperty("submit");
    }

    public override void OnInspectorGUI() {
        soTarget.Update();
        var titleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 20, stretchHeight = false, fixedHeight = 40 };
        var littleTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 15, stretchHeight = false, fixedHeight = 30 };
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Input Manager", titleStyle, GUILayout.ExpandWidth(true));   
        GUILayout.Space(10);
        EditorGUILayout.LabelField("by @Carbone_13", littleTitleStyle, GUILayout.ExpandWidth(true));  
        GUILayout.Space(20);
        myTarget.toolbarTab = GUILayout.Toolbar(myTarget.toolbarTab, new string[] {"Axis", "Studio 13 Key"});
        GUILayout.Space(10);

        switch(myTarget.toolbarTab){
            case 0:
                myTarget.currentTab = "Axis";
                break;
            case 1:  
                myTarget.currentTab = "Studio 13 Key";
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch(myTarget.currentTab){
            case "Axis":
                EditorGUILayout.PropertyField(horizontal, true);
                EditorGUILayout.PropertyField(vertical, true);
                break;
            case "Studio 13 Key":
                EditorGUILayout.PropertyField(jump, true);
                EditorGUILayout.PropertyField(primaryAttack, true);
                EditorGUILayout.PropertyField(secondaryAttack, true);
                EditorGUILayout.PropertyField(submit, true);
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
        }   
    }
}
#endif