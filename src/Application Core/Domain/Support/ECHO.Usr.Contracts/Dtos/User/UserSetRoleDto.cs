namespace ECHO.Usr.Contracts.Dtos
{
    public class UserSetRoleDto : InputDto
    {
        public long[] RoleIds { get; set; }
    }
}