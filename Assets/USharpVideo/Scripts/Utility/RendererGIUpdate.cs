
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

namespace UdonSharp.Video
{
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)]
    [AddComponentMenu("Udon Sharp/Video/Utilities/Renderer GI Update")]
    public class RendererGIUpdate : UdonSharpBehaviour
    {
        [Tooltip("Interval in seconds between GI updates. Defaults to 0.1s (~10 Hz) to avoid main-thread stalling.")]
        [SerializeField] private float updateInterval = 0.1f;

        private Renderer targetRenderer;
        private float _lastUpdateTime;

        void Start()
        {
            targetRenderer = GetComponent<Renderer>();
        }

        private void Update()
        {
            float time = Time.time;
            if (time - _lastUpdateTime >= updateInterval)
            {
                _lastUpdateTime = time;
                if (targetRenderer)
                    RendererExtensions.UpdateGIMaterials(targetRenderer);
            }
        }
    }
}
