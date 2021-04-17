﻿using Jurassic.Library;
using Jurassic;

namespace DisasterAPI
{
    class Engine : ObjectInstance
    {
        public Engine(ScriptEngine engine) : base(engine)
        {
            this.PopulateFunctions();
        }


        [JSProperty(Name = "timescale")]
        public static double timescale
        {
            get
            {
                return Disaster.Program.timescale;
            }
            set
            {
                Disaster.Program.timescale = value < 0 ? 0 : value;
            }
        }


        [JSFunction(Name = "reset")]
        [FunctionDescription("Unload all assets and reset the engine.")]
        public static void Reset()
        {
            Disaster.Assets.UnloadAll();
            Disaster.JS.instance.Reset();
        }

        [JSFunction(Name = "quit")]
        [FunctionDescription("Quit the game.")]
        public static void Quit()
        {
            Disaster.Program.running = false;
        }
    }
}