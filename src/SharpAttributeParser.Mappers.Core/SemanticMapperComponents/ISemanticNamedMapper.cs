﻿namespace SharpAttributeParser.Mappers.SemanticMapperComponents;

using SharpAttributeParser.Mappers.SemanticMappedRecorders;

/// <summary>Maps named attribute parameters to recorders, responsible for recording arguments of that parameter.</summary>
public interface ISemanticNamedMapper
{
    /// <summary>Attempts to map a named parameter to a recorder.</summary>
    /// <param name="parameterName">The name of the named parameter.</param>
    /// <returns>The mapped recorder, or <see langword="null"/> if the attempt was unsuccessful.</returns>
    public abstract ISemanticMappedNamedRecorder? TryMapParameter(string parameterName);
}
