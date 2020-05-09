using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System;
using VRage.Collections;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ObjectBuilders.Definitions;
using VRage.Game;
using VRage;
using VRageMath;

namespace IngameScript
{
    partial class Program : MyGridProgram
    {
        IMyCargoContainer Container1;
        IMyTextPanel SALCD;

        public Program()
        {
            Runtime.UpdateFrequency = UpdateFrequency.Update10;

            Container1 = GridTerminalSystem.GetBlockWithName("cargo") as IMyCargoContainer;

            SALCD = GridTerminalSystem.GetBlockWithName("mon ecran") as IMyTextPanel;

        }


        public void Main(string argument, UpdateType updateSource)
        {

            PrintInventory(Container1, SALCD);
        }

        public void PrintInventory(IMyCargoContainer Container, IMyTextPanel LCD)
        {
            string output = "";

            for (int i = 0; i < Container.GetInventory(0).ItemCount; i++)
            {
                output += Container.GetInventory(0).GetItemAt(i).Value.Amount + "  " + Container.GetInventory(0).GetItemAt(i).Value.Type.SubtypeId + "\n";
            }
            LCD.ContentType = ContentType.TEXT_AND_IMAGE;
            LCD.WriteText(output);
        }
    }
}
