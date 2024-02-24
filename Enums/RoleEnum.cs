using System.Text.Json.Serialization;

namespace dotnetapi.Enums;
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RoleEnum
{
    Operational = 1,
    Admin = 2,
    SuperAdmin = 3

}