﻿using Moq;
using NUnit.Framework;
using Rainbow.ObjectFlow.Engine;
using Rainbow.ObjectFlow.Interfaces;

namespace Objectflow.core.tests.CompositeWorkflows
{
    [TestFixture]
    public class WhenInvokingWorkflows
    {
        [Test]
        public void ShouldStartInnerWorkflow()
        {
            var innerWorkflow = new Mock<IWorkflow<string>>();
            innerWorkflow.Setup(wf => wf.Start("red")).Returns("dd");

            var invoker = new WorkflowInvoker<string>(innerWorkflow.Object);
            invoker.Execute("red");

            innerWorkflow.VerifyAll();
        }
    }
}