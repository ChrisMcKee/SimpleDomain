//-------------------------------------------------------------------------------
// <copyright file="GiftcardOverview.cs" company="frokonet.ch">
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

namespace GiftcardSample.ReadStore
{
    using System;

    public class GiftcardOverview
    {
        public Guid CardId { get; set; }

        public int CardNumber { get; set; }

        public DateTime ValidUntil { get; set; }

        public decimal CurrentBalance { get; set; }

        public GiftcardStatus Status { get; set; }
    }
}