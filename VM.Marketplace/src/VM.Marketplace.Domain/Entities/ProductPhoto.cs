﻿namespace VM.Marketplace.Domain.Entities;

public class ProductPhoto : Entity
{
    public Guid ProductId { get; private set; }
    public string Url { get; private set; }
}
