using UnityEngine;

namespace DingusThings.Behaviours
{
    internal class MyHeartPhysicsProp : PhysicsProp
    {
        public override void ItemActivate(bool used, bool buttonDown = true)
        {
            base.ItemActivate(used, buttonDown);
            if (buttonDown)
            {
                AssetBundle? bundle = DingusThings.Bundle;
                if (bundle == null) 
                {
                    DingusThings.Logger.LogError("Sound failed to play.");
                    return;
                }
                AudioClip audioClip = bundle.LoadAsset<AudioClip>("Assets/DingusThings/Sounds/SheSaid.ogg");
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.PlayOneShot(audioClip, 1F);
            }
        }
    }
}
