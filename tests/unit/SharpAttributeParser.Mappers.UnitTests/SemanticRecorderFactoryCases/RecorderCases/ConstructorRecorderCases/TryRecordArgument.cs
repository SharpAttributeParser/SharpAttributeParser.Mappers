﻿namespace SharpAttributeParser.Mappers.SemanticRecorderFactoryCases.RecorderCases.ConstructorRecorderCases;

using Microsoft.CodeAnalysis;

using Moq;

using SharpAttributeParser.SemanticRecorderComponents;

using System;

using Xunit;

public sealed class TryRecordArgument
{
    private static bool Target(ISemanticConstructorRecorder recorder, IParameterSymbol parameter, object? argument) => recorder.TryRecordArgument(parameter, argument);

    [Fact]
    public void NullParameter_ArgumentNullException()
    {
        var context = RecorderContext<object>.Create();

        var exception = Record.Exception(() => Target(context.Recorder, null!, Mock.Of<ITypeSymbol>()));

        Assert.IsType<ArgumentNullException>(exception);
    }

    [Fact]
    public void TrueReturningRecorder_ReturnsTrue() => ValidRecorder_PropagatesReturnValue(true);

    [Fact]
    public void FalseReturningRecorder_ReturnsFalse() => ValidRecorder_PropagatesReturnValue(false);

    [AssertionMethod]
    private static void ValidRecorder_PropagatesReturnValue(bool recorderReturnValue)
    {
        var context = RecorderContext<object>.Create();

        var parameter = Mock.Of<IParameterSymbol>();
        var argument = Mock.Of<object>();

        context.MapperMock.Setup(static (mapper) => mapper.Constructor.MapParameter(It.IsAny<IParameterSymbol>()).TryRecordArgument(It.IsAny<object>(), It.IsAny<object?>())).Returns(recorderReturnValue);

        var outcome = Target(context.Recorder, parameter, argument);

        Assert.Equal(recorderReturnValue, outcome);

        context.MapperMock.Verify((mapper) => mapper.Constructor.MapParameter(parameter).TryRecordArgument(context.DataRecord, argument), Times.Once);
    }
}
