﻿using Aurora.Devices.Layout;
using Aurora.Devices.Layout.Layouts;
using Aurora.Settings;
using Aurora.Settings.Layers;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;

namespace Aurora.Profiles.XCOM
{
    class XCOMProfile : ApplicationProfile
    {
        public XCOMProfile()
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
                new Layer("Camera Movement", new SolidColorLayerHandler()
                {
                    Properties = new LayerHandlerProperties()
                    {
                        _PrimaryColor = Color.Orange,
                        _Sequence = new KeySequence(new List<KeyboardKeys> { KeyboardKeys.W, KeyboardKeys.A, KeyboardKeys.S, KeyboardKeys.D, KeyboardKeys.Q, KeyboardKeys.E, KeyboardKeys.HOME, KeyboardKeys.Z }.ConvertAll(s => s.GetDeviceLED()))
                    }
                }
                ),
                new Layer("Other Actions", new SolidColorLayerHandler()
                {
                    Properties = new LayerHandlerProperties()
                    {
                        _PrimaryColor = Color.DarkOrange,
                        _Sequence = new KeySequence(new List<KeyboardKeys> { KeyboardKeys.ENTER, KeyboardKeys.ESC, KeyboardKeys.V, KeyboardKeys.X, KeyboardKeys.BACKSPACE, KeyboardKeys.F1, KeyboardKeys.R, KeyboardKeys.B, KeyboardKeys.Y }.ConvertAll(s => s.GetDeviceLED()))
                    }
                }),
                new Layer("Wrapper Lighting", new Aurora.Settings.Layers.WrapperLightsLayerHandler()),
            };
        }
    }
}
