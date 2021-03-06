﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.DocAsCode.Build.Engine
{
    using Microsoft.DocAsCode.Plugins;

    public class BasicXRefMapReader : IXRefContainerReader
    {
        protected XRefMap Map { get; }

        public BasicXRefMapReader(XRefMap map)
        {
            Map = map;
        }

        public virtual XRefSpec Find(string uid)
        {
            if (Map.References == null)
            {
                return null;
            }
            if (Map.Sorted == true)
            {
                var index = Map.References.BinarySearch(new XRefSpec { Uid = uid }, XRefSpecUidComparer.Instance);
                if (index >= 0)
                {
                    return Map.References[index];
                }
                return null;
            }
            else
            {
                return Map.References.Find(x => x.Uid == uid);
            }
        }
    }
}
