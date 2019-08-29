using System.Collections.Generic;
using System.Linq;
using Aurora.EffectsEngine;
using Aurora.Profiles.Guild_Wars_2.GSI;

namespace Aurora.Profiles.Guild_Wars_2
{
    public class GameEvent_GW2 : GameEvent_Generic
    {
        public override void ResetGameState()
        {
            _game_state = new GameState_GW2();
        }

        public override void UpdateLights(EffectFrame frame)
        {
            //Queue<EffectLayer> layers = new Queue<EffectLayer>();

            //foreach (var layer in this.Application.Profile.Layers.Reverse().ToArray())
            //{
            //    if (layer.Enabled && layer.LogicPass)
            //        layers.Enqueue(layer.Render(_game_state));
            //}

            ////Scripts
            //this.Application.UpdateEffectScripts(layers);

            //frame.AddLayers(layers.ToArray());
            base.UpdateLights(frame);
        }
    }
}