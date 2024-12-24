using IPA.Utilities;
using SiraUtil.Affinity;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlqzTweaks
{
    internal class EditorButtonPatch : IAffinity
    {
        [AffinityPatch(typeof(MainMenuViewController), "DidActivate")]
        [AffinityPostfix]
        private void Postfix(ref Button ____beatmapEditorButton)
        {
            if (____beatmapEditorButton != null) ____beatmapEditorButton.interactable = false;
        }
    }
    
    internal class SaberClashPatch : IAffinity
    {
        [AffinityPatch(typeof(SaberClashEffect), "Start")]
        [AffinityPostfix]
        private void Postfix(ref ParticleSystem ____sparkleParticleSystem, ref ParticleSystem ____glowParticleSystem)
        {
            if (____sparkleParticleSystem != null) ____sparkleParticleSystem.Pause();
            if (____glowParticleSystem != null) ____glowParticleSystem.Pause();
        }
    }
    
    internal class WallClashPatch : IAffinity
    {
        [AffinityPatch(typeof(ObstacleSaberSparkleEffectManager), "Start")]
        [AffinityPostfix]
        private void Postfix(ref ObstacleSaberSparkleEffect[] ____effects)
        {
            if (____effects == null || ____effects.Length == 0) return;
            foreach (var effect in ____effects) effect.gameObject.SetActive(false);
        }
    }
    
    internal class DebrisPatch : IAffinity
    {
        [AffinityPatch(typeof(NoteDebrisSpawner), "SpawnDebris")]
        [AffinityPrefix]
        private bool Prefix()
        {
            return false;
        }
    }
    
    internal class CutParticlesPatch : IAffinity
    {
        [AffinityPatch(typeof(NoteCutCoreEffectsSpawner), "Start")]
        [AffinityPostfix]
        private void Postfix(ref NoteCutParticlesEffect ____noteCutParticlesEffect)
        {
            if (____noteCutParticlesEffect != null) ____noteCutParticlesEffect.gameObject.SetActive(false);
        }
    }
    
    internal class BurnMarkAreaPatch : IAffinity
    {
        [AffinityPatch(typeof(SaberBurnMarkArea), "Start")]
        [AffinityPostfix]
        private void Postfix(ref SaberBurnMarkArea __instance)
        {
            if (__instance != null) __instance.gameObject.SetActive(false);
        }
    }
    
    internal class BurnMarkSparklesPatch : IAffinity
    {
        [AffinityPatch(typeof(SaberBurnMarkSparkles), "Start")]
        [AffinityPostfix]
        private void Postfix(ref SaberBurnMarkSparkles __instance)
        {
            if (__instance != null) __instance.gameObject.SetActive(false);
        }
    }
    
    internal class PlayerHeightPatch : IAffinity
    {
        [AffinityPatch(typeof(PlayerHeightSettingsController), "RefreshUI")]
        [AffinityPostfix]
        private void Postfix(ref TextMeshProUGUI ____text, float ____value)
        {
            ____text.text = $"{____value:0.000}";
        }
    }
    
    internal class PlayerSettingsPatch : IAffinity
    {
        private static EnvironmentEffectsFilterPresetDropdown defaultPresetDropdown = null;
        private static EnvironmentEffectsFilterPresetDropdown expertPlusPresetDropdown = null;
        
        [AffinityPatch(typeof(PlayerSettingsPanelController), "SetLayout")]
        [AffinityPrefix]
        private void Prefix(ref EnvironmentEffectsFilterPresetDropdown  ____environmentEffectsFilterDefaultPresetDropdown, ref EnvironmentEffectsFilterPresetDropdown  ____environmentEffectsFilterExpertPlusPresetDropdown, ref FormattedFloatListSettingsController ____noteJumpFixedDurationSettingsController)
        {
            defaultPresetDropdown = ____environmentEffectsFilterDefaultPresetDropdown;
            expertPlusPresetDropdown = ____environmentEffectsFilterExpertPlusPresetDropdown;
            if (defaultPresetDropdown)
            {
                defaultPresetDropdown.didSelectCellWithIdxEvent -= OnLightSettingChanged;
                defaultPresetDropdown.didSelectCellWithIdxEvent += OnLightSettingChanged;
            }
            if (expertPlusPresetDropdown) expertPlusPresetDropdown.transform.parent.gameObject.SetActive(false);

            ____noteJumpFixedDurationSettingsController.values = new[] {0.425f, 0.430f, 0.435f, 0.440f, 0.445f, 0.450f, 0.455f, 0.460f, 0.465f, 0.470f, 0.475f, 0.480f, 0.485f, 0.490f, 0.495f, 0.500f};
            ____noteJumpFixedDurationSettingsController.SetField("_formattingString", "{0:0.000}s");
        }
        
        private static void OnLightSettingChanged(int p_CellIndex, EnvironmentEffectsFilterPreset p_Setting)
        {
            if (!expertPlusPresetDropdown) return;
            expertPlusPresetDropdown.SelectCellWithValue(p_Setting);
        }
    }
}