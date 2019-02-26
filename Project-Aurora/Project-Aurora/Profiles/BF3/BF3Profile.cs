﻿using System.Collections.Generic;
using Aurora.Settings;
using Aurora.Settings.Layers;
using System.Drawing;
using System.Runtime.Serialization;
using System.Linq;
using Aurora.Devices.Layout.Layouts;

namespace Aurora.Profiles.BF3
{
    public class BF3Profile : ApplicationProfile
    {
        public BF3Profile() : base()
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
                        _PrimaryColor = Color.White,
                        _Sequence = new KeySequence(new KeyboardKeys[] { KeyboardKeys.W, KeyboardKeys.A, KeyboardKeys.S, KeyboardKeys.D })
                    }
                }),
                new Layer("Other Actions", new SolidColorLayerHandler()
                {
                    Properties = new LayerHandlerProperties()
                    {
                        _PrimaryColor = Color.Yellow,
                        _Sequence = new KeySequence(new KeyboardKeys[] { KeyboardKeys.SPACE, KeyboardKeys.LEFT_SHIFT, KeyboardKeys.G, KeyboardKeys.E, KeyboardKeys.F, KeyboardKeys.TAB })
                    }
                }),
                new Layer("Wrapper Lighting", new Aurora.Settings.Layers.WrapperLightsLayerHandler()),
            };
        }
    }
}
