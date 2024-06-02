using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class MyHeartPhysicsProp : PhysicsProp
    {
        private float cooldown = 1.1f;

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
                string itemName = "My Heart";
                if (bundle == null) 
                {
                    DingusThings.Logger.LogError($"{itemName}: Sound failed to play.");
                    return;
                }
                AudioClip audioClip = bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/SheSaid.ogg");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip, 1F);
            }
        }
    }
}
