using System.ComponentModel;

namespace Didact.Flatify.Enums;

public enum InputMode
{
    [Description("none")] none,
    [Description("text")] text,
    [Description("decimal")] @decimal,
    [Description("numeric")] numeric,
    [Description("tel")] tel,
    [Description("search")] search,
    [Description("email")] email,
    [Description("url")] url
}