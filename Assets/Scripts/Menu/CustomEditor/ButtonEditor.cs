using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(MenuButton))]
public class ButtonEditor : Editor
{
    private MenuButton myTarget;
    private SerializedObject soTarget;

    public SerializedProperty menuButtonController;
    public SerializedProperty animator;
    public SerializedProperty animatorFunctions;
    public SerializedProperty fader;

    public SerializedProperty thisIndex;
    public SerializedProperty disableAllOnClick;
    public SerializedProperty sceneToLoad;

    public SerializedProperty OnClick;


    private void OnEnable() {
        myTarget = (MenuButton)target;
        soTarget = new SerializedObject(target);

        menuButtonController = soTarget.FindProperty("menuButtonController");
        animator = soTarget.FindProperty("animator");
        animatorFunctions = soTarget.FindProperty("animatorFunctions");
        fader = soTarget.FindProperty("fader");

        thisIndex = soTarget.FindProperty("thisIndex");
        disableAllOnClick = soTarget.FindProperty("disableAllOnClick");
        sceneToLoad = soTarget.FindProperty("sceneToLoad");

        OnClick = soTarget.FindProperty("OnClick");
    }

    public override void OnInspectorGUI() {
        soTarget.Update();
        var titleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 20, stretchHeight = false, fixedHeight = 40 };
        var littleTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 15, stretchHeight = false, fixedHeight = 30 };
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Custom Button", titleStyle, GUILayout.ExpandWidth(true));   
        GUILayout.Space(10);
        EditorGUILayout.LabelField("by @Carbone_13 and Thomas Brush", littleTitleStyle, GUILayout.ExpandWidth(true));  
        GUILayout.Space(20);
        myTarget.toolbarTab = GUILayout.Toolbar(myTarget.toolbarTab, new string[] {"Settings", "References", "Events"});
        GUILayout.Space(10);

        switch(myTarget.toolbarTab){
            case 0:
                myTarget.currentTab = "Settings";
                break;
            case 1:  
                myTarget.currentTab = "References";
                break;
            case 2:
                myTarget.currentTab = "Events";  
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch(myTarget.currentTab){
            case "Settings":
                EditorGUILayout.PropertyField(thisIndex);
                EditorGUILayout.PropertyField(disableAllOnClick);
                EditorGUILayout.PropertyField(sceneToLoad);
                break;
            case "References":
                EditorGUILayout.PropertyField(menuButtonController);
                EditorGUILayout.PropertyField(animator);
                EditorGUILayout.PropertyField(animatorFunctions);
                EditorGUILayout.PropertyField(fader);
                break;
            case "Events":
                EditorGUILayout.PropertyField(OnClick);
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
        }   
    }
}
#endif