//-------------------------------------------------------------------------------
// <copyright file="IConnectionBuilder.cs" company="frokonet.ch">
//   Copyright (c) 2014-2016
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

namespace SimpleDomain.EventStore
{
    using System.Threading.Tasks;

    using global::EventStore.ClientAPI;

    /// <summary>
    /// The GetEventStore connection buider interface
    /// </summary>
    public interface IConnectionBuilder
    {
        /// <summary>
        /// Builds and returns an instance of <see cref="IEventStoreConnection"/>
        /// </summary>
        /// <returns>An instance of <see cref="IEventStoreConnection"/></returns>
        Task<IEventStoreConnection> BuildAsync();
    }
}