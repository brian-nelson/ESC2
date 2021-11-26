using System;
using System.Collections.Generic;
using ESC2.Library.Data.Interfaces;

// This file is generated from the database.  Do not manually edit.
// Generated by: https://github.com/brian-nelson/repo-generator
// To extend the class beyond a POCO, create a additional partial class
// named Implementation.cs

namespace ESC2.Library.Data.DataObjects
{
    public partial class Implementation : IGuidObject
    {
        public Implementation()
        {
        }

        public Guid Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
        public string Summary { get; set; }
        public Guid? AssignedUserId { get; set; }
        public Guid AssetId { get; set; }
        public Guid StigId { get; set; }
    }
}