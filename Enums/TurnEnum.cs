using System.Text.Json.Serialization;

namespace dotnetapi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TurnEnum
{
    MorningShift,
    AfternoonShift,
    NightShift
}