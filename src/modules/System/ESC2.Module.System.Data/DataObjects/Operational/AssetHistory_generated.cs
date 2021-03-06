using System;
using System.Collections.Generic;
using ESC2.Library.Data.Interfaces;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator
// To extend the class beyond a POCO, create a additional partial class
// named AssetHistory.cs

namespace ESC2.Module.System.Data.DataObjects.Operational
{
    public partial class AssetHistory : IDataObject<Guid>
    {
        public AssetHistory()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime ActionDate { get; set; }
        public string Action { get; set; }
        public Guid UserId { get; set; }
        public Guid AssetId { get; set; }
    }
}
