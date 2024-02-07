using System.Text.Json.Serialization;

namespace dotnetapi.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DepartmentEnum
{
    HR,
    Financial,
    Purchase,
    Customer,
    Caretaker

}
