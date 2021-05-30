﻿// Copyright (c) XRTK. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.﻿

using UnityEditor;
using XRTK.Definitions.LocomotionSystem;

namespace XRTK.Editor.Profiles.LocomotionSystem
{
    [CustomEditor(typeof(MixedRealityBlinkTeleportLocomotionProviderProfile))]
    public class MixedRealityBlinkTeleportLocomotionProviderProfileInspector : BaseMixedRealityProfileInspector
    {
        private SerializedProperty fadeDuration;

        protected override void OnEnable()
        {
            base.OnEnable();

            fadeDuration = serializedObject.FindProperty(nameof(fadeDuration));
        }

        public override void OnInspectorGUI()
        {
            RenderHeader("This profile defines behaviour for the blink teleport locomotion implementation of XRTK.");

            serializedObject.Update();

            EditorGUILayout.PropertyField(fadeDuration);

            serializedObject.ApplyModifiedProperties();
        }
    }
}
