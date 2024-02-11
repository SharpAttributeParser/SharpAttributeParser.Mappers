﻿namespace SharpAttributeParser.Mappers.Logging.MapperLoggerComponents;

using System;

/// <summary>Handles logging for <see cref="IMapper"/> when related to named parameters.</summary>
public interface INamedParameterLogger
{
    /// <summary>Begins a log scope describing an attempt to map a named parameter to a recorder.</summary>
    /// <typeparam name="TRecorder">The type of the mapped recorders.</typeparam>
    /// <param name="parameterName">The name of the named parameter.</param>
    /// <returns>The <see cref="IDisposable"/> used to close the log scope.</returns>
    public abstract IDisposable? BeginScopeMappingNamedParameter<TRecorder>(string parameterName);

    /// <summary>Logs a message describing a failed attempt to map a named parameter to a recorder.</summary>
    public abstract void FailedToMapNamedParameter();
}
