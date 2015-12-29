﻿using System;
using DependencyInjectionSample.Services;

namespace DependencyInjectionSample.Models
{
    public class Operation : IOperationTransient,
        IOperationScoped,
        IOperationSingleton,
        IOperationInstance
    {
        public Operation() : this(Guid.NewGuid())
        {
        }
        public Operation(Guid id)
        {
            OperationId = id;
        }
        public Guid OperationId { get; private set; }
    }
}