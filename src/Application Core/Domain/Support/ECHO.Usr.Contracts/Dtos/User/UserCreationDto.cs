﻿namespace ECHO.Usr.Contracts.Dtos
{
    public class UserCreationDto : UserCreationAndUpdationDto
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
    }
}