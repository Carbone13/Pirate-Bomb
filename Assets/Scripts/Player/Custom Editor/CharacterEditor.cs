using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(Characters))]
public class CharacterEditor : Editor
{
    private Characters myTarget;
    private SerializedObject soTarget;

    public SerializedProperty isBomberman;
    public SerializedProperty isBaldPirate;
    public SerializedProperty isCucumber;
    public SerializedProperty isGuy;
    public SerializedProperty isCaptain;
    public SerializedProperty isWhale;

    // Bomberman
    public SerializedProperty bombRate;
    public SerializedProperty bombPrefab;

    private void OnEnable() {
        myTarget = (Characters)target;
        soTarget = new SerializedObject(target);

        isBomberman = soTarget.FindProperty("isBomberman");
        isBaldPirate = soTarget.FindProperty("isBaldPirate");
        isCucumber = soTarget.FindProperty("isCucumber");
        isGuy = soTarget.FindProperty("isGuy");
        isCaptain = soTarget.FindProperty("isCaptain");
        isWhale = soTarget.FindProperty("isWhale");

        bombRate = soTarget.FindProperty("bombRate");
        bombPrefab = soTarget.FindProperty("bombPrefab");
    }

    public override void OnInspectorGUI() {

        #region Toolbar
        soTarget.Update();
        var titleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 20, stretchHeight = false, fixedHeight = 40 };
        var littleTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 15, stretchHeight = false, fixedHeight = 30 };
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Characters System Collections", titleStyle, GUILayout.ExpandWidth(true));   
        GUILayout.Space(10);
        EditorGUILayout.LabelField("by @Carbone_13", littleTitleStyle, GUILayout.ExpandWidth(true));  
        GUILayout.Space(20);
        
        myTarget.toolbar1 = GUILayout.Toolbar(myTarget.toolbar1, new string[] {"Bomber Man", "Bald Pirate", "Cucumber"});
        switch(myTarget.toolbar1){
            case 0:
                myTarget.toolbar2 = 4;
                myTarget.currentTab = "Bomber Man";
                break;
            case 1:  
                myTarget.toolbar2 = 4;
                myTarget.currentTab = "Bald Pirate";
                break;
            case 2:
                myTarget.toolbar2 = 4;
                myTarget.currentTab = "Cucumber";  
                break;
        }

        myTarget.toolbar2 = GUILayout.Toolbar(myTarget.toolbar2, new string[] {"Guy", "Captain", "Whale"});
        switch(myTarget.toolbar2){
            case 0:
                myTarget.toolbar1 = 4;
                myTarget.currentTab = "Guy";
                break;
            case 1:  
                myTarget.toolbar1 = 4;
                myTarget.currentTab = "Captain";
                break;
            case 2:
                myTarget.toolbar1 = 4;
                myTarget.currentTab = "Whale";  
                break;
        }

        // Drawing

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        GUILayout.Space(10);
        switch(myTarget.currentTab){
            case "Bomber Man":
                EditorGUILayout.PropertyField(isBomberman);
                if(myTarget.isBomberman){
                    EditorGUILayout.PropertyField(bombRate);
                    EditorGUILayout.PropertyField(bombPrefab);
                }
                break;
            case "Bald Pirate":
                EditorGUILayout.PropertyField(isBaldPirate);
                break;
            case "Cucumber":
                EditorGUILayout.PropertyField(isCucumber);
                break;
            case "Guy":
                EditorGUILayout.PropertyField(isGuy);
                break;
            case "Captain":
                EditorGUILayout.PropertyField(isCaptain);
                break;
            case "Whale":
                EditorGUILayout.PropertyField(isWhale);
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
        } 

        #endregion  
    }
}
#endif