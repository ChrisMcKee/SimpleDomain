﻿//-------------------------------------------------------------------------------
// <copyright file="JitneyConfiguration.cs" company="frokonet.ch">
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

namespace SimpleDomain.Bus
{
    using Ninject;

    /// <summary>
    /// The Jitney configuration
    /// </summary>
    public class JitneyConfiguration : AbstractJitneyConfiguration
    {
        private readonly IKernel kernel;
        
        /// <summary>
        /// Creates a new instance of <see cref="JitneyConfiguration"/>
        /// </summary>
        /// <param name="kernel">Dependency injection for <see cref="IKernel"/></param>
        public JitneyConfiguration(IKernel kernel) : base(new NinjectTypeResolver(kernel))
        {
            this.kernel = kernel;
            this.kernel.Bind<IHaveJitneyConfiguration>().ToConstant(this).InSingletonScope();

            if (!this.kernel.HasModule(typeof(SimpleDomainModule).FullName))
            {
                this.kernel.Load(new SimpleDomainModule());
            }
        }

        /// <summary>
        /// Subscribes a handler by its type
        /// </summary>
        /// <typeparam name="TMessage">The type of the message</typeparam>
        /// <typeparam name="THandler">The type of the handler</typeparam>
        public void Subscribe<TMessage, THandler>()
            where TMessage : IMessage
            where THandler : IHandleAsync<TMessage>
        {
            this.kernel.Bind<IHandleAsync<TMessage>>().To<THandler>().Named(typeof(THandler).FullName);
        }

        /// <inheritdoc />
        public override void Register<TJitney>()
        {
            this.kernel.Bind<IDeliverMessages, Jitney>().To<TJitney>().InSingletonScope();
        }
    }
}