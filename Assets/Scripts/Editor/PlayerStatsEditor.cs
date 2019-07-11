using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlayerStats)), CanEditMultipleObjects]
public class PlayerStatsEditor : Editor
{
    int maxHealth_Prop,
        strength_Prop,
        defense_Prop,
        spellPower_Prop,
        speed_Prop;


    public SerializedProperty  
        currentAttack_Prop,
        type_Prop,
        physicalAttack_Prop,
        magicAttack_Prop;
 


    public override void OnInspectorGUI()
    {
        serializedObject.Update();


        EditorGUILayout.PropertyField(serializedObject.FindProperty("maxHealth"));       
        EditorGUILayout.PropertyField(serializedObject.FindProperty("strength"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("defense"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("spellPower"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("currentAttack"));


        EditorGUILayout.PropertyField(serializedObject.FindProperty("type"));

        PlayerStats.PlayerType type = (PlayerStats.PlayerType)serializedObject.FindProperty("type").enumValueIndex;

        switch (type)
        {
            case PlayerStats.PlayerType.Player:

                //EditorGUILayout.ObjectField(physicalAttack_Prop, new GUIContent("Physical Attack"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("physicalAttack"));


                //EditorGUILayout.ObjectField(magicAttack_Prop, new GUIContent("Magic Attack"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("magicAttack"));

                break;

            case PlayerStats.PlayerType.MagicEnemy:
                currentAttack_Prop = magicAttack_Prop;
                //EditorGUILayout.ObjectField(magicAttack_Prop, new GUIContent("magicAttack"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("magicAttack"));

                break;

            case PlayerStats.PlayerType.PhysicalEnemy:
                currentAttack_Prop = physicalAttack_Prop;
                EditorGUILayout.PropertyField(serializedObject.FindProperty("physicalAttack"));
                //EditorGUILayout.ObjectField(physicalAttack_Prop, new GUIContent("physicalAttack"));

                break;

        }

                serializedObject.ApplyModifiedProperties();
    }
}
