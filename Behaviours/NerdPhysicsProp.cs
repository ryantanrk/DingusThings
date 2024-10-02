using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class NerdPhysicsProp : PhysicsProp
    {
        private readonly float cooldown = 1.1f;

        float _lastTriggeredTime;

        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            // if still under cooldown do not activate
            if (Time.time - _lastTriggeredTime < cooldown) return;

            base.ItemActivate(used, buttonDown);
            if (buttonDown)
            {
                _lastTriggeredTime = Time.time;
                AssetBundle? bundle = DingusThings.Bundle;
                string itemName = "Nerd";
                if (bundle == null)
                {
                    DingusThings.Logger.LogError($"{itemName}: Sound failed to play.");
                    return;
                }
                AudioClip audioClip = bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/akchually.ogg");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip, 1F);
            }
        }
    }
}
