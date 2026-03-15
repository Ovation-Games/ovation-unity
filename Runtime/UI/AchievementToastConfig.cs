using UnityEngine;

namespace Ovation.UI
{
    [CreateAssetMenu(fileName = "OvationToastConfig", menuName = "Ovation/Toast Config", order = 2)]
    public class AchievementToastConfig : ScriptableObject
    {
        [Header("Appearance")]
        [Tooltip("Background color of the toast panel.")]
        public Color backgroundColor = new Color(0.12f, 0.12f, 0.16f, 0.92f);

        [Tooltip("Primary text color (achievement name).")]
        public Color titleColor = Color.white;

        [Tooltip("Secondary text color (description).")]
        public Color descriptionColor = new Color(0.75f, 0.75f, 0.78f, 1f);

        [Tooltip("Accent color for the left border strip.")]
        public Color accentColor = new Color(0.38f, 0.71f, 1f, 1f);

        [Header("Layout")]
        [Tooltip("Screen position for the toast.")]
        public ToastPosition position = ToastPosition.TopRight;

        [Tooltip("Width of the toast panel in pixels.")]
        public float width = 360f;

        [Tooltip("Height of the toast panel in pixels.")]
        public float height = 80f;

        [Tooltip("Margin from the screen edge in pixels.")]
        public float margin = 20f;

        [Header("Timing")]
        [Tooltip("How long the toast stays visible (seconds).")]
        public float displayDuration = 3f;

        [Tooltip("Slide-in animation duration (seconds).")]
        public float slideInDuration = 0.3f;

        [Tooltip("Slide-out animation duration (seconds).")]
        public float slideOutDuration = 0.3f;

        [Header("Audio")]
        [Tooltip("Optional sound effect when a toast appears.")]
        public AudioClip sound;

        [Tooltip("Sound volume (0-1).")]
        [Range(0f, 1f)]
        public float soundVolume = 0.5f;
    }

    public enum ToastPosition
    {
        TopRight,
        TopLeft,
        BottomRight,
        BottomLeft,
        TopCenter
    }
}
