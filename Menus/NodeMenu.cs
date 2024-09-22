using MenuAPI;
using TrafficManager;

namespace Menu.Menus
{
    public class NodeMenu
    {
        private const string EnterEditor = "Enter Editor";
        private const string EnterSkyEditor = "Enter Sky Editor";
        private const string CloseSkyEditor = "Close Sky Editor";

        public MenuAPI.Menu GetMenu()
        {
            MenuAPI.Menu nodeMenu = new MenuAPI.Menu(Constants.MenuTitle, "~b~Traffic Nodes");

            // Adding menu items with constants
            nodeMenu.AddMenuItem(new MenuItem(EnterEditor));
            nodeMenu.AddMenuItem(new MenuItem(EnterSkyEditor));
            nodeMenu.AddMenuItem(new MenuItem(CloseSkyEditor));

            // Attaching event handler
            nodeMenu.OnItemSelect += HandleNodeMenuSelection;
            return nodeMenu;
        }

        private void HandleNodeMenuSelection(MenuAPI.Menu menu, MenuItem menuItem, int itemIndex)
        {
            switch (menuItem.Text)
            {
                case EnterEditor:
                    NodeEditor.Instance.Enable(false);
                    break;

                case EnterSkyEditor:
                    NodeEditor.Instance.Enable(true);
                    break;

                case CloseSkyEditor:
                    NodeEditor.Instance.Disable();
                    break;

                default:
                    // Handle unknown selection, if needed
                    break;
            }
        }
    }
}
