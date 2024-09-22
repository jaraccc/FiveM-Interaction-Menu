using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System;
using System.Collections.Generic;
using Menu.Menus;

namespace Menus
{
    class Commands : BaseScript
    {
        public Commands()
        {
            RegisterCommand("garage", new Action<int, List<object>, string>((source, args, raw) =>
            {
                GarageMainMenu garageMenu = new GarageMainMenu();
                MenuAPI.Menu garageMainMenu = garageMenu.GetMenu();
                MenuController.AddMenu(garageMainMenu);
                garageMainMenu.OpenMenu();
            }), false);
            TriggerEvent("chat:addSuggestion", "/garage", "Open the vehicle garage menu. Usage: /garage");
        }
    }
}
