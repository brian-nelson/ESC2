using System;
using System.Collections.Generic;
using ESC2.Library.Data.Interfaces;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator
// To extend the class beyond a POCO, create a additional partial class
// named Adjustment.cs

namespace ESC2.Module.System.Data.DataObjects.Operational
{
    public partial class Adjustment : IDataObject<Guid>
    {
        public Adjustment()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public Guid AdjustmentSetId { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid LastModifiedById { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
