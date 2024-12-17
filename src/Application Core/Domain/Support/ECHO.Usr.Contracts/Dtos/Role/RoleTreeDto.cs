﻿namespace ECHO.Usr.Contracts.Dtos;

[Serializable]
public class RoleTreeDto : IDto
{
    public IEnumerable<Node<long>> TreeData { get; set; }
    public IEnumerable<long> CheckedIds { get; set; }
}