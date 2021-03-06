﻿#region license
// Copyright 2016 Christoph Müller
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LockFreeDoublyLinkedLists;

namespace Test.Tests.Test001_.Operations
{
    internal class InsertBefore : NodeCreationOperation
    {
        public override LinkedListNode<LinkedListItem>
            RunOnLinkedList(
            LinkedListExecutionState state)
        {
            LinkedListNode<LinkedListItem> current = state.Current;
            if (current == null || current == state.List.First)
                return null;
            LinkedListNode<LinkedListItem> successor = current;
            while (successor.Previous.Value.Deleted)
            {
                successor = successor.Previous;
            }
            return state.AddingToKnownNodes(state.List.AddBefore(successor, new LinkedListItem(Value)));
        }

        public override ILockFreeDoublyLinkedListNode<ListItemData> RunOnLfdll(
            LfdllExecutionState state)
        {
            ILockFreeDoublyLinkedListNode<ListItemData> current
                = state.Current;
            if (current == null || current == state.List.Head)
                return null;
            return state.AddingToKnownNodes(current.InsertBefore(Value));
        }

        public InsertBefore(ObjectIdGenerator idGenerator, ListItemData value)
            : base(idGenerator, value)
        { }
    }
}
