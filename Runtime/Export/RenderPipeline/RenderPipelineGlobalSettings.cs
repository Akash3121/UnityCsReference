// Unity C# reference source
// Copyright (c) Unity Technologies. For terms of use, see
// https://unity3d.com/legal/licenses/Unity_Reference_Only_License

using System;
using System.Collections.Generic;

namespace UnityEngine.Rendering
{
    public abstract class RenderPipelineGlobalSettings : ScriptableObject
    {
        protected virtual List<IRenderPipelineGraphicsSettings> settingsList
        {
            get
            {
                Debug.LogWarning($"To be able to use {nameof(IRenderPipelineGraphicsSettings)} in your {GetType()} you must override {nameof(settingsList)}");
                Debug.LogWarning($"Create your own '[{nameof(SerializeReference)}] List<{nameof(IRenderPipelineGraphicsSettings)}> m_Settings = new();' in your {GetType()} and override {nameof(settingsList)} returning m_Settings;");
                return null;
            }
        }

        private Dictionary<Type, int> m_SettingsMap = null;

        private Dictionary<Type, int> settingsMap
        {
            get
            {
                if ( m_SettingsMap == null)
                    RecreateSettingsMap();

                return m_SettingsMap;
            }
        }

        private void RecreateSettingsMap()
        {
            if (m_SettingsMap == null)
                m_SettingsMap = new();
            else
                m_SettingsMap.Clear();

            if (settingsList == null)
                return;

            for (int i = 0; i < settingsList.Count; i++)
            {
                var element = settingsList[i];

                if (element == null)
                    continue; //missing script can cause this, preserve data, just not access it

                m_SettingsMap.Add(element.GetType(), i);
            }
        }

        public virtual void Initialize(RenderPipelineGlobalSettings source = null)
        {
        }

        protected internal bool Add(IRenderPipelineGraphicsSettings settings)
        {
            if (settingsList == null || settingsMap.ContainsKey(settings.GetType()))
                return false;

            settingsMap.Add(settings.GetType(), settingsList.Count);
            settingsList.Add(settings);
            MarkDirty();
            return true;
        }

        protected internal bool Remove(IRenderPipelineGraphicsSettings settings)
        {
            if (settingsList == null || !settingsMap.TryGetValue(settings.GetType(), out var index))
                return false;

            settingsList.RemoveAt(index);
            RecreateSettingsMap();
            MarkDirty();
            return true;
        }

        protected internal bool TryGet(Type type, out IRenderPipelineGraphicsSettings settings)
        {
            settings = null;

            if (settingsList == null || !settingsMap.TryGetValue(type, out var index))
                return false;

            settings = settingsList[index];
            return settings != null;
        }

        protected internal bool Contains(Type type)
        {
            return settingsList != null && settingsMap.ContainsKey(type);
        }
    }
}
