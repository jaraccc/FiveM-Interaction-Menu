using CitizenFX.Core;
using static CitizenFX.Core.Native.API;
using MenuAPI;
using static Menu.Functions;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Menu.Menus.Garages
{
    public static class SAFR
    {
        public static MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu safrMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Fire & Rescue Vehicle Garage");

            safrMenu.AddMenuItem(new MenuItem("Fire Vehicle Name 1")
            {
                Label = "PATROL",
                RightIcon = MenuItem.Icon.CAR
            });

            safrMenu.AddMenuItem(new MenuItem("Fire Vehicle Name 2")
            {
                Label = "PATROL",
                RightIcon = MenuItem.Icon.CAR
            });

            safrMenu.AddMenuItem(new MenuItem("Go Back"));
            safrMenu.AddMenuItem(new MenuItem("Close"));
            safrMenu.OnItemSelect += new MenuAPI.Menu.ItemSelectEvent(SAFR_OnItemSelect);
            return safrMenu;
        }

        private static async void SAFR_OnItemSelect(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            string text = menuItem.Text;

            switch (text)
            {
                case "Fire Vehicle Name 1":
                    // Pass the vehicle model, livery, and extra configurations (true = enabled, false = disabled)
                    await SpawnSAFRVehicle("safr1", 0, new Dictionary<int, bool>
                    {
                        { 1, false },  // Extra 1 disabled
                        { 2, true },   // Extra 2 enabled
                        { 3, false }   // Extra 3 disabled (example)
                    });
                    break;

                case "Fire Vehicle Name 2":
                    await SpawnSAFRVehicle("safr2", 1, new Dictionary<int, bool>
                    {
                        { 1, true },   // Extra 1 enabled
                        { 2, false },  // Extra 2 disabled
                        { 4, true }    // Extra 4 enabled (example)
                    });
                    break;

                case "Go Back":
                    menu.GoBack();
                    break;

                case "Close":
                    MenuController.CloseAllMenus();
                    break;

                default:
                    break;
            }
        }

        private static async Task SpawnSAFRVehicle(string vehicleModel, int livery, Dictionary<int, bool> extras)
        {
            Vehicle veh = await spawnVehicle(vehicleModel);

            // Set the vehicle livery
            SetVehicleLivery(veh.Handle, livery);

            // Set vehicle extras based on the extras dictionary
            foreach (var extra in extras)
            {
                SetVehicleExtra(veh.Handle, extra.Key, !extra.Value);  // true = disable, false = enable
            }
        }
    }
}