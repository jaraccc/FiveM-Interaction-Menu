using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using System.Collections.Generic;

namespace Menu.Menus
{
    public static class VehicleMenu
    {
        private const string Engine = "Engine";
        private const string Hood = "Hood";
        private const string Trunk = "Trunk";
        private const string AutoLock = "Auto Lock";
        private const string FlipVehicle = "Flip Vehicle";
        private const string BoatAnchor = "Boat Anchor";
        private const string AutoEngineStartStop = "Auto Engine Start/Stop";
        private const string RollWindows = "Roll Windows";
        private const string Doors = "Doors";
        private const string ShuffleSeats = "Shuffle Seats";

        // Mapping seat and door indexes to commands
        private static readonly string[] doorCommands = { "door 1", "door 2", "door 3", "door 4" };
        private static readonly string[] seatCommands = { "shuffleseat 1", "shuffleseat 2", "shuffleseat 3", "shuffleseat 4" };

        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu vehicleMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Vehicle Toolbox");

            // Add menu items
            vehicleMenu.AddMenuItem(new MenuItem(Engine));
            vehicleMenu.AddMenuItem(new MenuListItem(RollWindows, new List<string> { "Front Windows", "Rear Windows" }, 0));
            vehicleMenu.AddMenuItem(new MenuItem(Hood));
            vehicleMenu.AddMenuItem(new MenuItem(Trunk));
            vehicleMenu.AddMenuItem(new MenuListItem(Doors, new List<string> { "Front Left Door", "Front Right Door", "Rear Left Door", "Rear Right Door" }, 0));
            vehicleMenu.AddMenuItem(new MenuItem(AutoLock));
            vehicleMenu.AddMenuItem(new MenuListItem(ShuffleSeats, new List<string> { "Drivers Seat", "Passengers Seat", "Rear Left Seat", "Rear Right Seat" }, 0));
            vehicleMenu.AddMenuItem(new MenuItem(FlipVehicle));
            vehicleMenu.AddMenuItem(new MenuItem(BoatAnchor));
            vehicleMenu.AddMenuItem(new MenuItem(AutoEngineStartStop));

            // Event listeners
            vehicleMenu.OnItemSelect += VehicleToolboxMenu_OnItemSelect;
            vehicleMenu.OnListItemSelect += VehicleToolboxMenu_OnListItemSelect;

            return vehicleMenu;
        }
        private static void VehicleToolboxMenu_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case Engine:
                    ExecuteCommand("eng");
                    break;
                case Hood:
                    ExecuteCommand("hood");
                    break;
                case Trunk:
                    ExecuteCommand("trunk");
                    break;
                case AutoLock:
                    ExecuteCommand("autolock");
                    break;
                case FlipVehicle:
                    ExecuteCommand("vehflip");
                    break;
                case BoatAnchor:
                    ExecuteCommand("anchor");
                    break;
                case AutoEngineStartStop:
                    BaseScript.TriggerEvent("StartStop");
                    break;
                default:
                    break;
            }
        }

        private static void VehicleToolboxMenu_OnListItemSelect(MenuAPI.Menu menu, MenuListItem listItem, int selectedIndex, int itemIndex)
        {
            switch (listItem.Text)
            {
                case RollWindows:
                    if (selectedIndex == 0)
                        ExecuteCommand("frontwindows");
                    else if (selectedIndex == 1)
                        ExecuteCommand("rearwindows");
                    break;

                case Doors:
                    if (selectedIndex >= 0 && selectedIndex < doorCommands.Length)
                        ExecuteCommand(doorCommands[selectedIndex]);
                    break;

                case ShuffleSeats:
                    if (selectedIndex >= 0 && selectedIndex < seatCommands.Length)
                        ExecuteCommand(seatCommands[selectedIndex]);
                    break;

                default:
                    break;
            }
        }
    }
}
