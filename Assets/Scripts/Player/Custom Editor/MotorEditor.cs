using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
[CustomEditor(typeof(PlayerMovement))]
public class MotorEditor : Editor
{

    private PlayerMovement myTarget;
    private SerializedObject soTarget;

    public SerializedProperty _Move;
    public SerializedProperty _Grounded;
    public SerializedProperty _Jump;
    public SerializedProperty _Fall;
    public SerializedProperty _FacingRight;

    public SerializedProperty speed;
    public SerializedProperty jumpForce;
    public SerializedProperty movementSmoothing;
    public SerializedProperty groundCheckRadius;
    public SerializedProperty invertFacing;

    public SerializedProperty Rigidbody;
    public SerializedProperty Collider;
    public SerializedProperty Animator;
    public SerializedProperty AudioSource;
    public SerializedProperty groundCheck;
    public SerializedProperty runParticle;
    public SerializedProperty landClip;

    private void OnEnable() {
        myTarget = (PlayerMovement)target;
        soTarget = new SerializedObject(target);

        _Move = soTarget.FindProperty("_Move");
        _Grounded = soTarget.FindProperty("_Grounded");
        _Jump = soTarget.FindProperty("_Jump");
        _Fall = soTarget.FindProperty("_Fall");
        _FacingRight = soTarget.FindProperty("_FacingRight");

        speed = soTarget.FindProperty("speed");
        jumpForce = soTarget.FindProperty("jumpForce");
        movementSmoothing = soTarget.FindProperty("movementSmoothing");
        groundCheckRadius = soTarget.FindProperty("groundCheckRadius");
        invertFacing = soTarget.FindProperty("invertFacing");

        Rigidbody = soTarget.FindProperty("Rigidbody");
        Collider = soTarget.FindProperty("Collider");
        Animator = soTarget.FindProperty("Animator");
        AudioSource = soTarget.FindProperty("AudioSource");
        groundCheck = soTarget.FindProperty("groundCheck");
        runParticle = soTarget.FindProperty("RunParticle");
        landClip = soTarget.FindProperty("LandClip");
    }

    public override void OnInspectorGUI() {
        soTarget.Update();
        var titleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 20, stretchHeight = false, fixedHeight = 40 };
        var littleTitleStyle = new GUIStyle(GUI.skin.label) {alignment = TextAnchor.MiddleCenter, fontSize = 15, stretchHeight = false, fixedHeight = 30 };
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.LabelField("Player Movement System", titleStyle, GUILayout.ExpandWidth(true));   
        GUILayout.Space(10);
        EditorGUILayout.LabelField("by @Carbone_13", littleTitleStyle, GUILayout.ExpandWidth(true));  
        GUILayout.Space(20);
        myTarget.toolbarTab = GUILayout.Toolbar(myTarget.toolbarTab, new string[] {"In-Game", "Settings", "References"});
        GUILayout.Space(10);

        switch(myTarget.toolbarTab){
            case 0:
                myTarget.currentTab = "In-Game";
                break;
            case 1:  
                myTarget.currentTab = "Settings";
                break;
            case 2:
                myTarget.currentTab = "References";  
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
            GUI.FocusControl(null);
        }

        EditorGUI.BeginChangeCheck();

        switch(myTarget.currentTab){
            case "In-Game":
                EditorGUILayout.PropertyField(_Move);
                EditorGUILayout.PropertyField(_Grounded);
                EditorGUILayout.PropertyField(_Jump);
                EditorGUILayout.PropertyField(_Fall);
                EditorGUILayout.PropertyField(_FacingRight); 
                break;
            case "Settings":
                EditorGUILayout.PropertyField(speed);
                EditorGUILayout.PropertyField(jumpForce);
                EditorGUILayout.PropertyField(movementSmoothing);
                EditorGUILayout.PropertyField(groundCheckRadius);
                EditorGUILayout.PropertyField(invertFacing);
                break;
            case "References":
                EditorGUILayout.PropertyField(Rigidbody);
                EditorGUILayout.PropertyField(Collider);
                EditorGUILayout.PropertyField(Animator);
                EditorGUILayout.PropertyField(groundCheck);
                EditorGUILayout.PropertyField(runParticle);
                EditorGUILayout.LabelField("Audio", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(AudioSource);
                EditorGUILayout.PropertyField(landClip);
                break;
        }

        if(EditorGUI.EndChangeCheck()){
            soTarget.ApplyModifiedProperties();
        }   
    }
}
#endif