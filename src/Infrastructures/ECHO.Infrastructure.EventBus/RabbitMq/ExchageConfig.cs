﻿namespace ECHO.Infrastructure.EventBus.RabbitMq
{
    public class ExchageConfig
    {
        public string Name { get; set; } = string.Empty;
        public ExchangeType Type { get; set; } = default!;
        public string DeadExchangeName { get; set; } = string.Empty;
    }
}