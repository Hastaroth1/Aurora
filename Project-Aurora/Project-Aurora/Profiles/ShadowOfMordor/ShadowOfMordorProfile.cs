﻿using Aurora.Devices.Layout;
using Aurora.Devices.Layout.Layouts;
using Aurora.Settings;
using Aurora.Settings.Layers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace Aurora.Profiles.ShadowOfMordor
{
    public class ShadowOfMordorProfile : ApplicationProfile
    {
        public ShadowOfMordorProfile() : base()
        {
            
        }

        [OnDeserialized]
        void OnDeserialized(StreamingContext context)
        {
            if (!Layers.Any(lyr => lyr.Handler.GetType().Equals(typeof(Aurora.Settings.Layers.WrapperLightsLayerHandler))))
                Layers.Add(new Layer("Wrapper Lighting", new Aurora.Settings.Layers.WrapperLightsLayerHandler()));
        }


        public override void Reset()
        {
            base.Reset();
            Layers = new System.Collections.ObjectModel.ObservableCollection<Layer>()
            {
                new Layer("Movement", new SolidColorLayerHandler()
                {
                    Properties = new LayerHandlerProperties()
                    {
                        _PrimaryColor = Color.Blue,
                        _Sequence = new KeySequence(new List<KeyboardKeys> { KeyboardKeys.W, KeyboardKeys.A, KeyboardKeys.S, KeyboardKeys.D, KeyboardKeys.SPACE }.ConvertAll(s => s.GetDeviceLED()))
                    }
                }
                ),
                new Layer("Other Actions", new SolidColorLayerHandler()
                {
                    Properties = new LayerHandlerProperties()
                    {
                        _PrimaryColor = Color.LightBlue,
                        _Sequence = new KeySequence(new List<KeyboardKeys> { KeyboardKeys.LEFT_CONTROL, KeyboardKeys.V, KeyboardKeys.I, KeyboardKeys.K, KeyboardKeys.M }.ConvertAll(s => s.GetDeviceLED()))
                    }
                }),
                new Layer("Wrapper Lighting", new Aurora.Settings.Layers.WrapperLightsLayerHandler()),
            };
        }
    }
}
