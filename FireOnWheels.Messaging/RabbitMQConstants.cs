namespace FireOnWheels.Messaging
{
    public static class RabbitMqConstants
    {
        public static readonly string RabbitMqUri = "rabbitmq://localhost";
        public static readonly string RegisterOrderServiceQueue = "registerorder.service";
        public static readonly string NotificationServiceQueue = "notification.service";
        public static readonly string FinanceServiceQueue = "finance.service";
    }
}
