using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerStats)), CanEditMultipleObjects]
public class PlayerStatsEditor : Editor
{
    int maxHealth_Prop,
        strength_Prop,
        defense_Prop,
        spellPower_Prop,
        speed_Prop;


    public SerializedProperty  
        target_Prop,
        type_Prop,
        physicalAttack_Prop,
        magicAttack_Prop;

    void OnEnable()
    {
        //SetUp Default Stats
        maxHealth_Prop      = serializedObject.FindProperty("maxHealth").intValue;
        strength_Prop       = serializedObject.FindProperty("strength").intValue;
        defense_Prop        = serializedObject.FindProperty("defense").intValue;
        spellPower_Prop     = serializedObject.FindProperty("spellPower").intValue;
        speed_Prop          = serializedObject.FindProperty("speed").intValue;

        target_Prop         = serializedObject.FindProperty("target");

        //Setup the SerializedProperties
        type_Prop           = serializedObject.FindProperty("type");
        physicalAttack_Prop = serializedObject.FindProperty("physicalAttack");
        magicAttack_Prop    = serializedObject.FindProperty("magicAttack");
    }

    public override void OnInspectorGUI()
    {
        maxHealth_Prop = EditorGUILayout.IntField("Max Health", maxHealth_Prop);
        strength_Prop = EditorGUILayout.IntField("Strength", strength_Prop);
        defense_Prop = EditorGUILayout.IntField("Defense", defense_Prop);
        spellPower_Prop = EditorGUILayout.IntField("Spell Power", spellPower_Prop);
        speed_Prop = EditorGUILayout.IntField("Speed", speed_Prop);

        EditorGUILayout.ObjectField(target_Prop, new GUIContent("Target"));

        serializedObject.Update();

        EditorGUILayout.PropertyField(type_Prop);

        PlayerStats.PlayerType type = (PlayerStats.PlayerType)type_Prop.enumValueIndex;

        switch (type)
        {
            case PlayerStats.PlayerType.Player:

                EditorGUILayout.ObjectField(physicalAttack_Prop, new GUIContent("Physical Attack"));
                EditorGUILayout.ObjectField(magicAttack_Prop, new GUIContent("Magic Attack"));

                break;

            case PlayerStats.PlayerType.MagicEnemy:
                EditorGUILayout.ObjectField(magicAttack_Prop, new GUIContent("magicAttack"));

                break;

            case PlayerStats.PlayerType.PhysicalEnemy:
                EditorGUILayout.ObjectField(physicalAttack_Prop, new GUIContent("physicalAttack"));

                break;
        }

        serializedObject.ApplyModifiedProperties();
    }
}
