﻿// Copyright (c) XRTK. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEditor;
using XRTK.Services;
using XRTK.Definitions.LocomotionSystem;
using UnityEngine;

namespace XRTK.Editor.Profiles.LocomotionSystem
{
    [CustomEditor(typeof(MixedRealityLocomotionSystemProfile))]
    public class MixedRealityLocomotionSystemProfileInspector : MixedRealityServiceProfileInspector
    {
        private SerializedProperty startupBehavior;
        private SerializedProperty teleportProvider;
        private SerializedProperty teleportAction;
        private SerializedProperty movementCancelsTeleport;
        private SerializedProperty movementSpeed;
        private SerializedProperty movementProvider;
        private SerializedProperty moveAction;

        private static readonly GUIContent movementCancelsTeleportLabel = new GUIContent("Cancels Teleport");
        private static readonly GUIContent movementSpeedLabel = new GUIContent("Speed (m/s)");

        protected override void OnEnable()
        {
            base.OnEnable();

            startupBehavior = serializedObject.FindProperty(nameof(startupBehavior));
            teleportProvider = serializedObject.FindProperty(nameof(teleportProvider));
            teleportAction = serializedObject.FindProperty(nameof(teleportAction));
            movementCancelsTeleport = serializedObject.FindProperty(nameof(movementCancelsTeleport));
            movementSpeed = serializedObject.FindProperty(nameof(movementSpeed));
            movementProvider = serializedObject.FindProperty(nameof(movementProvider));
            moveAction = serializedObject.FindProperty(nameof(moveAction));
        }

        public override void OnInspectorGUI()
        {
            RenderHeader("The locomotion system profile defines behaviour for the locomotion system and how your users will be able to move around in your application.");

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(startupBehavior);
            EditorGUI.indentLevel--;

            // Teleporting
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Teleportation", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(teleportProvider);
            EditorGUILayout.PropertyField(teleportAction);
            EditorGUI.indentLevel--;

            // Movement
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Movement", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(movementCancelsTeleport, movementCancelsTeleportLabel);
            EditorGUILayout.PropertyField(movementSpeed, movementSpeedLabel);
            EditorGUILayout.PropertyField(movementProvider);
            EditorGUILayout.PropertyField(moveAction);
            EditorGUI.indentLevel--;

            serializedObject.ApplyModifiedProperties();

            if (EditorGUI.EndChangeCheck() &&
                MixedRealityToolkit.IsInitialized)
            {
                EditorApplication.delayCall += () => MixedRealityToolkit.Instance.ResetProfile(MixedRealityToolkit.Instance.ActiveProfile);
            }

            base.OnInspectorGUI();
        }
    }
}