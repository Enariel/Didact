#region Details

//
// -----------------------------------------
// fuchs
// Didact-18
// 12/08/2024

#endregion

using Didact.Flatify.Enums;

namespace Didact.Flatify;

public static class Helpers
{
    public static readonly Dictionary<Size, string> SizeDict = new Dictionary<Size, string>
    {
        { Size.Xs, "size-xs" },
        { Size.Sm, "size-sm" },
        { Size.Md, "size-md" },
        { Size.Lg, "size-lg" },
        { Size.TwoX, "size-2x" },
        { Size.ThreeX, "size-3x" },
        { Size.FourX, "size-4x" },
        { Size.FiveX, "size-5x" }
    };

    public static readonly Dictionary<Size, string> TextSizeDict = new Dictionary<Size, string>
    {
        { Size.Xs, "text-xs" },
        { Size.Sm, "text-sm" },
        { Size.Md, "text-md" },
        { Size.Lg, "text-lg" },
        { Size.TwoX, "text-2x" },
        { Size.ThreeX, "text-3x" },
        { Size.FourX, "text-4x" },
        { Size.FiveX, "text-5x" }
    };

    public static readonly Dictionary<StyleType, string> StyleTypeDict = new Dictionary<StyleType, string>
    {
        { StyleType.BlueLight, "style-blue-light" },
        { StyleType.Blue, "style-blue" },
        { StyleType.GreenLight, "style-green-light" },
        { StyleType.Green, "style-green" },
        { StyleType.YellowLight, "style-yellow-light" },
        { StyleType.Yellow, "style-yellow" },
        { StyleType.OrangeLight, "style-orange-light" },
        { StyleType.Orange, "style-orange" },
        { StyleType.RedLight, "style-red-light" },
        { StyleType.Red, "style-red" },
        { StyleType.PinkLight, "style-pink-light" },
        { StyleType.Pink, "style-pink" },
        { StyleType.PurpleLight, "style-purple-light" },
        { StyleType.Purple, "style-purple" },
        { StyleType.LightLight, "style-light-light" },
        { StyleType.Light, "style-light" },
        { StyleType.DarkLight, "style-dark-light" },
        { StyleType.Dark, "style-dark" }
    };

    public static readonly Dictionary<StateType, string> StateStyleDict = new Dictionary<StateType, string>()
    {
        { StateType.Success, "style-success" },
        { StateType.Info, "style-info" },
        { StateType.Warning, "style-warning" },
        { StateType.Danger, "style-danger" },
    };

    public static string GetStyleType(StyleType styleType, bool isLightStyle = false)
    {
        return StyleTypeDict[styleType] + (isLightStyle ? "-light" : "");
    }
}