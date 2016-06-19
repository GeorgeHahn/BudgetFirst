﻿// BudgetFirst 
// ©2016 Thomas Mühlgrabner
//
// This source code is dual-licensed under:
//   * Mozilla Public License 2.0 (MPL 2.0) 
//   * GNU General Public License v3.0 (GPLv3)
//
// ==================== Mozilla Public License 2.0 ===================
// This Source Code Form is subject to the terms of the Mozilla Public 
// License, v. 2.0. If a copy of the MPL was not distributed with this
// file, You can obtain one at http://mozilla.org/MPL/2.0/.
// ================= GNU General Public License v3.0 =================
// This file is part of BudgetFirst.
//
// BudgetFirst is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// BudgetFirst is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with Budget First.  If not, see<http://www.gnu.org/licenses/>.
// ===================================================================
namespace BudgetFirst.SharedInterfaces.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Domain;

    /// <summary>
    /// Unit of work for aggregates.
    /// Should only be used on a single aggregate per unit of work.
    /// Combine multiple unit of works for multiple aggregates in a saga.
    /// </summary>
    public interface IAggregateUnitOfWork
    {
        /// <summary>
        /// Get all events in this unit of work, from all aggregates.
        /// Event order is only guaranteed per aggregate. You should not use a unit of work over multiple aggregates
        /// </summary>
        /// <returns>All events in the transaction</returns>
        IReadOnlyList<IDomainEvent> GetEvents();

        /// <summary>
        /// Register an aggregate in the unit of work.
        /// Do not register multiple aggregates per unit of work.
        /// </summary>
        /// <param name="aggregate">Aggregate to register in unit of work</param>
        void Register(AggregateRoot aggregate);

        /// <summary>
        /// Retrieve an aggregate from the current unit of work
        /// </summary>
        /// <typeparam name="TAggregate">Aggregate type</typeparam>
        /// <param name="id">Aggregate id</param>
        /// <returns>Aggregate from unit of work, or <c>null</c> if not present in unit of work</returns>
        TAggregate Get<TAggregate>(Guid id) where TAggregate : AggregateRoot;
    }
}
