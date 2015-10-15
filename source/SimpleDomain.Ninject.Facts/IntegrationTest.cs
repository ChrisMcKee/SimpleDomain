﻿//-------------------------------------------------------------------------------
// <copyright file="IntegrationTest.cs" company="frokonet.ch">
//   Copyright (c) 2014-2015
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace SimpleDomain
{
    using System.Threading.Tasks;

    using FluentAssertions;

    using Ninject;

    using SimpleDomain.Bus;
    using SimpleDomain.TestDoubles;

    using Xunit;

    public class IntegrationTest
    {
        [Fact]
        public async Task CanConfigureAndCreateAndUseSimpleJitney()
        {
            var kernel = new StandardKernel();

            var configuration = new JitneyConfiguration(kernel);
            configuration.Subscribe<ValueCommand, ValueCommandHandler>();
            configuration.Subscribe<ValueEvent, ValueEventHandler>();
            configuration.Use<SimpleJitney>();
            
            var bus = kernel.Get<IDeliverMessages>();
            
            await bus.SendAsync(new ValueCommand(42));
            await bus.PublishAsync(new ValueEvent(666));

            ValueCommandHandler.Value.Should().Be(42);
            ValueEventHandler.Value.Should().Be(666);
        }
    }
}