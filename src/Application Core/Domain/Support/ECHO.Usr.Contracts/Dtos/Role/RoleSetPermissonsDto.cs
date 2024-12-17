namespace ECHO.Usr.Contracts.Dtos;

public class RoleSetPermissonsDto : IDto
{
    public long RoleId { set; get; }
    public long[] Permissions { get; set; }
}