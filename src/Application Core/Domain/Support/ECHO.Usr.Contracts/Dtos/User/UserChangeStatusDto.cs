﻿namespace ECHO.Usr.Contracts.Dtos
{
    public class UserChangeStatusDto : IDto
    {
        public long[] UserIds { get; set; }

        public int Status { get; set; }
    }
}