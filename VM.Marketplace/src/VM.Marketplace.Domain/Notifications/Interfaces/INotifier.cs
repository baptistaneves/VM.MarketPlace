﻿namespace VM.Marketplace.Domain.Notifications.Interfaces;

public interface INotifier
{
    bool HasNotifications();
    List<Notification> GetNotifications();
    void Handle(Notification notification);
}
